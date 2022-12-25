using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class by: Brian Dixon
public class WallTexture : MonoBehaviour
{
    [SerializeField] Texture[] wallTexture;
    Renderer wallRenderer;
    void Start()
    {
        wallRenderer = GetComponent<Renderer>();
        wallRenderer.material.mainTexture = wallTexture[Random.Range(0, wallTexture.Length)];
    }
}
