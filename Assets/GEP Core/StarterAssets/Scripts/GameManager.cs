using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {PLAY, PAUSE}
    public GameState currentState;
    public bool stateChange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = GameState.PLAY;
    }

    // Update is called once per frame
    void Update()
    {
        stateChange = false;

        switch (currentState)
        {
            case GameState.PLAY:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentState = GameState.PAUSE;
                    stateChange = true;
                }
                break;
            case GameState.PAUSE:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentState = GameState.PLAY;
                    stateChange = true;
                }
                break;

        }
    }
    private void LateUpdate()
    {
        if (stateChange)
        {
            stateChange = false;

            if (currentState == GameState.PLAY)
            {
                Time.timeScale = 1.0f;
            }
            else if (currentState == GameState.PAUSE)
            {
                Time.timeScale = 0.0f;
            }
        }
    }
}


