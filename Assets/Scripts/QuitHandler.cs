using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitHandler : MonoBehaviour
{
    public QuitHandler(InputAction quitAction)
    {
        quitAction.performed += QuitAction_Performed;
        quitAction.Enable();
    }

    private void QuitAction_Performed(InputAction.CallbackContext obj)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
