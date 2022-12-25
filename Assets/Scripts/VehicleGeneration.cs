using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class by: Brian Dixon 
public class VehicleGeneration : MonoBehaviour
{

    private int randomVehicle;
    //public float zPlacementMultiplier = 6.25f;

    [SerializeField] private GameObject road;
    [SerializeField] private GameObject bus;

    // Start is called before the first frame update
    void Start()
    {
        //randomVehicle = UnityEngine.Random.Range(1, 4);
        
        Quaternion spawnRotation = Quaternion.Euler(0, 90, 0);
        transform.tag = "Vehicle";
        var newBus = Instantiate(bus, new Vector3(-Random.Range(20.0f, 35.0f), 0, road.transform.localPosition.z - 1f), spawnRotation);
        newBus.transform.parent = road.transform;
    }

    private void Update()
    {
        
    }


}
