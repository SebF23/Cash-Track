using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

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

    [Header("Other")]
    private float spawnOffest;
    public GameObject nextTrackObject;
    private TrackSegment trackSegment;
    
    private void Awake()
    {
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
            //
        }
    }

    private GameObject chooseFirstTrack()
    {
        // GameObject firstTrack;

        return southEntranceTracks[0];
    }

    private GameObject chooseNextTrack(GameObject currTrack)
    {
        trackSegment = currTrack.GetComponent<TrackSegment>();
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