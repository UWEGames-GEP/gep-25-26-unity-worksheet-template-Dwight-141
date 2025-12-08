using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {PLAY, PAUSE}
    public GameState currentState;
    public bool stateChange = false;
    public GameObject inventoryUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = GameState.PLAY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (stateChange)
        {
            stateChange = false;

            if (currentState == GameState.PLAY)
            {
                inventoryUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1.0f;
            }
            else if (currentState == GameState.PAUSE)
            {
                inventoryUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0.0f;
            }
        }
    }

    public void PausingFunc()
    {
        stateChange = false;

        switch (currentState)
        {
            case GameState.PLAY:
                    currentState = GameState.PAUSE;
                    stateChange = true;
                break;
            case GameState.PAUSE:
                    currentState = GameState.PLAY;
                    stateChange = true;
                break;

        }
    }
}


