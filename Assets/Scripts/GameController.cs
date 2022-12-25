using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Class by: Edward Lui
[Serializable] public class MoveInputEvent : UnityEvent<float, float> { }
public class GameController : MonoBehaviour
{
    private static GameController instance;
    [SerializeField] LevelGeneration levelGeneration;
    private Lab6Controls lab6Controls;
    [SerializeField] private PlayerController playerController;
    [SerializeField] public GameOver gameOver;
    public MoveInputEvent moveInput;
    public static int roads = 1;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        levelGeneration.numberRoads = roads;
        lab6Controls = new Lab6Controls();
        playerController.Initalize(lab6Controls.Controls.Movement);
    }

    private static GameController Instance
    {
        get { return instance; }
    }

    private void OnEnable()
    {
        var _ = new QuitHandler(lab6Controls.Controls.Quit);
        lab6Controls.Controls.Enable();
        lab6Controls.Controls.Movement.performed += OnMovePerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        Vector2 move = obj.ReadValue<Vector2>();
        moveInput.Invoke(move.x, move.y);
    }

    public void OnDisable()
    {
        lab6Controls.Controls.Disable();
    }

    public IEnumerator reload(bool win)
    {
        if(win)
        {
            roads++;
        }
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Destroy(gameObject);
    }

}
