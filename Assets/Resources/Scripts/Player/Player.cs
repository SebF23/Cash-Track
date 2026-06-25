using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance {get; private set;}
    public Car playerCar;

    [Header("Player Stats")]
    public int money;

    [Header("Race Stats")]
    public int position;


    void Awake()
    {
        
    }
}