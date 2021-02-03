﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    #region --------------------    Public Enumerations



    #endregion

    #region --------------------    Public Events



    #endregion

    #region --------------------    Public Properties

    /// Stores the singleton instance for the class
    public static GameManager instance { get; private set; } = null;

    /// <summary>
    /// The current state of the game
    /// </summary>
    public iGameState state { get; private set; } = new Intro_GameState();

    /// <summary>
    /// The single audio source for the game
    /// </summary>
    public new AudioSource audio => _audio;

    /// <summary>
    /// The sound played whenever text is being typed
    /// </summary>
    public AudioClip typeClip => _typeClip;

    /// <summary>
    /// Returns the game's tutorial panels
    /// </summary>
    public List<GameObject> tutorialPanels => _tutorialPanels;

    #endregion

    #region --------------------    Public Methods

    /// <summary>
    /// Completes the introduction & begins the tutorial
    /// </summary>
    public void CompleteIntro()
    {
        state = state.LeaveState(new Tutorial_GameState());
    }

    /// <summary>
    /// Completes the tutorial & begins the gameplay
    /// </summary>
    public void CompleteTutorial()
    {
        state = state.LeaveState(new Gameplay_GameState());
    }

    /// <summary>
    /// Wins the game
    /// </summary>
    public void Victory()
    {
        state = state.LeaveState(new Victory_GameState());
        _victoryPanel.SetActive(true);
        _victorySpeedLabel.text = TimeSpan.FromSeconds(_gameDuration).ToString("hhh:mm:ss");
    }

    /// <summary>
    /// Loses the game
    /// </summary>
    public void Defeat()
    {
        state = state.LeaveState(new Defeat_GameState());
        _victoryPanel.SetActive(true);
    }

    /// <summary>
    /// Restarts the game
    /// </summary>
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);

    #endregion

    #region --------------------    Private Fields

    [Header("Singleton Configurations")]
    [SerializeField] private bool _isPersistent = false;

    /// <summary>
    /// The play duration of the game
    /// </summary>
    private float _gameDuration = 0f;

    [Header("Audio Configurations")]
    [SerializeField] private AudioSource _audio = null;
    [SerializeField] private AudioClip _typeClip = null;

    [Header("UI Configurations")]
    [SerializeField] private GameObject _victoryPanel = null;
    [SerializeField] private TMP_Text _victorySpeedLabel = null;
    [SerializeField] private GameObject _defeatPanel = null;
    [SerializeField] private List<GameObject> _tutorialPanels = new List<GameObject>();

    #endregion

    #region --------------------    Private Methods

    /// Used to perform configuration for the class
    private void Awake() => _SetSingleton();

    /// Sets the singleton for the class
    private void _SetSingleton()
    {
        instance = instance ?? this;
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        if (_isPersistent) DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Enters the intro state
    /// </summary>
    private void Start() => state.EnterState();

    /// <summary>
    /// Used to track state interactions or updates
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) state.InteractState();
        state.UpdateState();
    }

    #endregion

}