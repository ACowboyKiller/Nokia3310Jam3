using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Beacon : MonoBehaviour
{

    #region --------------------    Public Enumerations



    #endregion

    #region --------------------    Public Events



    #endregion

    #region --------------------    Public Properties

    public static bool isNearby => _inv != null;
    public static bool isInteracted { get; private set; } = false;
    public List<bool> collected { get; set; } = new List<bool>() { false, false, false, false, false };

    #endregion

    #region --------------------    Public Methods



    #endregion

    #region --------------------    Private Fields

    private static PlayerInventory _inv = null;

    #endregion

    #region --------------------    Private Methods

    private void Awake()
    {
        isInteracted = false;
        _inv = null;
    }

    private void OnTriggerEnter(Collider other) => _inv = other.GetComponentInChildren<PlayerInventory>();

    private void OnTriggerExit(Collider other) => _inv = null;

    private void Update()
    {
        if (_inv != null && Input.GetKeyDown(KeyCode.E) && 
            ((GameManager.instance.state.GetGameState() == GameManager.GameState.Tutorial && ((Tutorial_GameState)GameManager.instance.state).hasDismissed) || 
            GameManager.instance.state.GetGameState() == GameManager.GameState.Gameplay))
        {
            isInteracted = true;
            if (GameManager.instance.state.GetGameState() != GameManager.GameState.Gameplay) return;
            GameManager.instance.audio.PlayOneShot(GameManager.instance.turnInClip);
            for (int i = 0; i < _inv.collected.Count; i ++)
            {
                collected[i] = collected[i] || _inv.collected[i];
                _inv.collected[i] = false;
            }
            if (!collected.Exists(p => false)) GameManager.instance.Victory();
        }
    }

    #endregion

}