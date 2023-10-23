using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public InputAction startAction;

    public TMP_Text highscore_txt;

    void Start()
    {
        highscore_txt.text = "High Score: " + GameManager.Instance.highscore;
    }

    void OnEnable()
    {
        startAction.Enable();
        startAction.canceled += OnStart;    // wait to release button
    }

    void OnDisable()
    {
        startAction.canceled -= OnStart;
        startAction.Disable();
    }

    public void OnStart(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene(1);

        // reset the score at level start
        GameManager.Instance.scoreatlevelstart = 0;
    }
}
