using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameManager is null.");
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance)
            Destroy(gameObject);
        else
            _instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    public bool IsGameOver { get{return this.IsGameOver;} set{this.IsGameOver = value; Time.timeScale = value ? 0: 1;} }
    public bool IsPaused { get{return this.IsPaused;} set{this.IsPaused = value; Time.timeScale = value ? 0: 1;} }
    public bool MoveBackground { get; set; }
    public bool Player1Swap { get; set; }
    public bool Player2Swap { get; set; }
    public bool PlayerVulnerable {get; set;}
    public Transform TorchPlayer { get; set; }

}
