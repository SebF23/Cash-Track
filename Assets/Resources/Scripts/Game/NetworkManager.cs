using NUnit.Framework.Internal;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public int maxPlayerCount = 4;
    public static NetworkManager instance {get; private set;}
    public struct playerStats
    {
        public string name;
        public int money;
        public Car playerCar;
        public int playerRacePosition;
    }

    void Awake()
    {
        playerStats[] players = new playerStats[maxPlayerCount]; //0 for host
    }
}
