using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene("InstructionsScreen");
    }

    public void SceneLoader(int ScreenIndex)
    {
        SceneManager.LoadScene(ScreenIndex);
    }

    public void Exit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Sale del modo Play en el editor de Unity
        #endif
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
