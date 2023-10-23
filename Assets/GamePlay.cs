using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public TMP_Text lives_txt;
    public TMP_Text score_txt;
    public TMP_Text highscore_txt;
    public TMP_Text timer_txt;
    public TMP_Text gamestatus_txt;

    private Rigidbody ball; // reference to the rigid body of the ball

    public int lives = 3;
    public bool gameover = false;
    public int score = 0;
    public int maxscore;
    public float roundtime = 0;

    public InputAction nextAction;

    Camera m_cam;
    void OnEnable()
    {
        nextAction.Enable();
        nextAction.canceled += OnNext;  // release button
    }

    void OnDisable()
    {
        nextAction.canceled -= OnNext;
        nextAction.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

        // How many of this type
        maxscore = GameObject.FindObjectsByType<BallDetected>(FindObjectsSortMode.None).Length + GameManager.Instance.scoreatlevelstart;
        UpdateTxt();
        gamestatus_txt.text = "";
        m_cam = Camera.main;

        score = GameManager.Instance.scoreatlevelstart;

        ResetBall();
    }

    void UpdateTxt()
    {
        lives_txt.text = "Lives: " + lives;
        score_txt.text = "Score: " + score + "/" + maxscore;
        timer_txt.text = "Time: " + (int)roundtime;
        highscore_txt.text = "High Score: " + GameManager.Instance.highscore;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover) return;
        UpdateTxt();

        Vector3 pos = m_cam.transform.position;
        pos.x = ball.transform.position.x + 2;

        m_cam.transform.position = Vector3.Lerp(m_cam.transform.position, pos, Time.deltaTime);

        roundtime += Time.deltaTime;

    }

    private void FixedUpdate()
    {
        if (gameover)
        {
            return;
        }

        if (ball.transform.position.y < -10)
        {
            lives--;
            UpdateTxt();

            if (lives <= 0)
            {
                gameover = true;
                gamestatus_txt.text = "You lose - Game Over";
                return;
            }
            else
            {
                ResetBall();
            }
        }
    }

    void ResetBall()
    {
        ball.transform.position = new Vector3(1, 1, 0);
        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;
    }

    // Task 5
    public void IncScore()
    {
        score++;

        // Update the highscore if the current score is greater than the stored highscore
        if (score > GameManager.Instance.highscore)
        {
            GameManager.Instance.highscore = score;
        }
    }
    public void OnNext(InputAction.CallbackContext ctx)
    {
        if (!gameover) return;

        SceneManager.LoadScene(0);
    }

    // Need to be on end tile with max score to win
    public void CheckForWin()
    {
        // Game won
        if (score >= maxscore)
        {
            // Are there more levels
            if (SceneManager.GetActiveScene().buildIndex<SceneManager.sceneCountInBuildSettings +-1 )
            {
                // score at the start of the level
                GameManager.Instance.scoreatlevelstart = score;

                Debug.Log("scence " + SceneManager.GetActiveScene().buildIndex + " " + SceneManager.sceneCountInBuildSettings);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                return;
            }

            gamestatus_txt.text = "You Win - Game Over";
            gameover = true;
        }
    }
}
