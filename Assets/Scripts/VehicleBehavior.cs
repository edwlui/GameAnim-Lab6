using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class by: Brian Dixon 
public class VehicleBehavior : MonoBehaviour
{
    [SerializeField] private GameObject vehicle;
    private float vehicleSpeed;
   

    private Vector3 spawnPoint;

    [SerializeField] private GameObject road;
    void Start()
    {
        vehicle.tag = "Vehicle";
        transform.tag = "Vehicle";
        spawnPoint = vehicle.transform.position;

        int speedVal = UnityEngine.Random.Range(1, 3);

        switch (speedVal)
        {
            case 1:
                vehicleSpeed = 25f;
                break;
            case 2:
                vehicleSpeed = 50f;
                break;
            case 3:
                vehicleSpeed = 75f;
                break;
            default:
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        vehicle.transform.Translate(Vector3.forward * vehicleSpeed * Time.deltaTime);

        if(vehicle.transform.position.x > 30)
        {
            vehicle.transform.position = spawnPoint;
        }

    }
}
