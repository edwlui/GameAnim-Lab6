using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Class by: Edward Lui
public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 20f;
    [SerializeField] int lives = 3;
    [SerializeField] AudioClip hornClip;
    [SerializeField] AudioClip drinkClip;
    [SerializeField] AudioClip winClip;
    [SerializeField] GameController gameController;
    AudioSource audioSource;
    private InputAction moveAction;
    float x, z;
    GUIStyle livesText = new GUIStyle();

    public void Initalize(InputAction moveAction)
    {
        audioSource = GetComponent<AudioSource>();
        livesText.fontSize = 20;
        this.moveAction = moveAction;
    }

    private void FixedUpdate()
    {
        Vector3 move = Vector3.forward * z + Vector3.right * x;
        transform.position += move * speed * Time.deltaTime;
        if(lives <= 0)
        {
            GameOver(false);
        }
    }

    public void OnMoveInput(float x, float z)
    {
        this.x = x;
        this.z = z;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect((Screen.width - 100), 10, 100, 50), "Lives: " + lives, livesText);
    }

    // If collides with powerup, destroy and increment lives
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "EnergyDrink")
        {
            audioSource.PlayOneShot(drinkClip);
            lives++;
            Destroy(collision.collider.gameObject);
        } else if (collision.collider.tag == "Vehicle")
        {
            lives--;
            audioSource.PlayOneShot(hornClip);
            transform.position = spawnPoint.position;
        } else if (collision.collider.tag == "EndGoal")
        {
            GameOver(true);
        }
    }

    private void GameOver(bool win)
    { 
        if (win) {
            audioSource.PlayOneShot(winClip, 0.7f);
            gameController.gameOver.win = true;
        } else if (!win)
        {
            transform.position = spawnPoint.position;
            gameController.gameOver.lost = true;
        }
        gameController.OnDisable();
        StartCoroutine(gameController.reload(win));
        
    }


}
