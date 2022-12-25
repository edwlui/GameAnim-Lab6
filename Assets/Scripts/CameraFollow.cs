using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class by: Edward Lui
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
