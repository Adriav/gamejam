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

    private bool _isGameOver;
    public bool IsGameOver
    {
        get { return _isGameOver; }
        set { _isGameOver = value; Time.timeScale = value ? 0 : 1; }
    }
    private bool _isPaused;
    public bool IsPaused
    {
        get { return _isPaused; }
        set { _isPaused = value; Time.timeScale = value ? 0 : 1; }
    }

    public bool InMenu
    {
        get { return IsGameOver || IsPaused; }
    }
    public bool MoveBackground { get; set; }
    public bool Player1Swap { get; set; }
    public bool Player2Swap { get; set; }
    public bool InSwapAnimation { get; set; }
    public bool PlayerVulnerable { get; set; }
    public Transform TorchPlayer { get; set; }

}
