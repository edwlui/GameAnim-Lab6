using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class by: Edward Lui
public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject winGameText;
    public bool lost = false;
    public bool win = false;
    void Start()
    {
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(lost)
        {
            gameOverText.SetActive(true);
        } else if(win)
        {
            winGameText.SetActive(true);
        } else
        {
            gameOverText.SetActive(false);
            winGameText.SetActive(false);
        }
    }


}
