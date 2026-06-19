using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }
    public Direction entryDirection, exitDirection;
}
