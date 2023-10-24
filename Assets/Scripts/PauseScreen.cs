using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public bool isPaused;
    private void Awake()
    {
        GameManager.Instance.IsPaused = false;
        GameManager.Instance.IsGameOver = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused)
            {
                ResumeGame();
            }
            else {
                PauseGame();            
            }
        }
    }

    public void PauseGame() {
        GameManager.Instance.IsPaused = true;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame() {

        GameManager.Instance.IsPaused = false;
        pauseMenu.SetActive(false);
        isPaused = false;
    }



}
