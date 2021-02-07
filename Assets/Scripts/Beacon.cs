using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Beacon : MonoBehaviour
{

    #region --------------------    Public Enumerations



    #endregion

    #region --------------------    Public Events



    #endregion

    #region --------------------    Public Properties

    public List<bool> collected { get; set; } = new List<bool>() { false, false, false, false, false };

    #endregion

    #region --------------------    Public Methods



    #endregion

    #region --------------------    Private Fields

    private PlayerInventory _inv = null;

    #endregion

    #region --------------------    Private Methods

    private void OnTriggerEnter(Collider other) => _inv = other.GetComponentInChildren<PlayerInventory>();

    private void OnTriggerExit(Collider other) => _inv = null;

    private void Update()
    {
        if (GameManager.instance.state.GetGameState() != GameManager.GameState.Gameplay) return;
        if (_inv != null && Input.GetKeyDown(KeyCode.E))
        {
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