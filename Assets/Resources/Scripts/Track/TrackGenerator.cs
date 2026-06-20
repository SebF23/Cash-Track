using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrackGenerator : MonoBehaviour
{
    [Header("Track Info")]
    public int trackLength;
    public Vector3 spawnPos = new Vector3(0, 0, 0);
    public GameObject[] allTracks;
    private List<GameObject> southEntranceTracks = new List<GameObject>();
    private List<GameObject> eastEntranceTracks = new List<GameObject>();
    private List<GameObject> westEntranceTracks = new List<GameObject>();
    private List<GameObject> northEntranceTracks = new List<GameObject>();
    public bool isFinished;

    [Header("Spawning")]
    private float spawnOffest;
    private GameObject nextTrackObject;
    private TrackSegment trackSegment;
    private int listCount;
    private int trackSelection;
    public Transform trackFolder;
    
    private void Awake()
    {
        trackLength = 50; //for testing purposes

        spawnOffest = 50f;
        transform.position = new Vector3(0,0,0);
        isFinished = false;

        loadPrefabs();
        generateTrack();
        isFinished = true;
    }

    private void generateTrack()
    {
        //spawn first track. First track will always be a south entrance so we only pick from that list randomly
        spawnPos.z += spawnOffest; //Z is North
        nextTrackObject = chooseFirstTrack();
        Instantiate(nextTrackObject, spawnPos, quaternion.identity);
    
        for(int i = 0; i < trackLength; i++)
        {
            nextTrackObject = chooseNextTrack(nextTrackObject);
            if(!nextTrackObject){break;}
            Instantiate(nextTrackObject, spawnPos, quaternion.identity, trackFolder);
        }
    }

    private GameObject chooseFirstTrack()
    {
        listCount = southEntranceTracks.Count;
        trackSelection = Random.Range(0, listCount);
        return southEntranceTracks[trackSelection];
    }

    private GameObject chooseNextTrack(GameObject currTrack)
    {
        trackSegment = currTrack.GetComponent<TrackSegment>();

        switch (trackSegment.exitDirection)
            {
                case TrackSegment.Direction.North: //exits north so we enter from the south
                listCount = southEntranceTracks.Count;
                trackSelection = Random.Range(0, listCount);
                spawnPos.z += spawnOffest; //move north
                return southEntranceTracks[trackSelection];

                case TrackSegment.Direction.East: //exits east so we enter from the west
                listCount = westEntranceTracks.Count;
                trackSelection = Random.Range(0, listCount);
                spawnPos.x += spawnOffest; //move east
                return westEntranceTracks[trackSelection];

                case TrackSegment.Direction.South: //exits south so we enter from the north
                listCount = northEntranceTracks.Count;
                trackSelection = Random.Range(0, listCount);
                spawnPos.z -= spawnOffest; //move south
                return northEntranceTracks[trackSelection];

                case TrackSegment.Direction.West: //exits west so we enter from the east
                listCount = eastEntranceTracks.Count;
                trackSelection = Random.Range(0, listCount);
                spawnPos.x -= spawnOffest; //move east
                return eastEntranceTracks[trackSelection];
            }
            return null;
    }

    private void loadPrefabs()
    {
        allTracks = Resources.LoadAll<GameObject>("Tile Prefabs");

        foreach(GameObject track in allTracks)
        {
            switch (track.GetComponent<TrackSegment>().entryDirection)
            {
                case TrackSegment.Direction.North:
                Debug.Log("Added" + track + " to North List");
                northEntranceTracks.Add(track);
                break;

                case TrackSegment.Direction.East:
                Debug.Log("Added" + track + " to East List");
                eastEntranceTracks.Add(track);
                break;

                case TrackSegment.Direction.South:
                Debug.Log("Added" + track + " to South List");
                southEntranceTracks.Add(track);
                break;

                case TrackSegment.Direction.West:
                Debug.Log("Added" + track + " to West List");
                westEntranceTracks.Add(track);
                break;
            }
        }
    }


    //.count to get amount of items in a list
    //then int choice = Random.Range(0, N) where N is the count. This gets a random item from a list.
}