using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class by: Edward Lui
public class LevelGeneration : MonoBehaviour
{
    [SerializeField] public float zPlacementMult;
    public GameObject road;
    public GameObject endGoal;
    public GameObject powerUp;
    [SerializeField] public int numberRoads = 0;
    private float vehicleSpeed;
    void Start()
    {
        vehicleSpeed = Random.Range(1.0f, 10.0f);
        int i;
        for (i = 1; i <= numberRoads; i++)
        {
            var newRoad = Instantiate(road, new Vector3(0, 0, i * zPlacementMult), Quaternion.identity);
            newRoad.transform.parent = gameObject.transform;
            if (Random.Range(0.0f, 1.0f) < 0.5)
            {
                var newPU = Instantiate(powerUp, new Vector3(Random.Range(-24.0f, 24.0f), 0, i * zPlacementMult), Quaternion.identity);
                newPU.transform.parent = newRoad.transform;
            }
            
        }
        var newEG = Instantiate(endGoal, new Vector3(0, 0, i * zPlacementMult), Quaternion.identity);
        newEG.transform.parent = gameObject.transform;
     }
}
