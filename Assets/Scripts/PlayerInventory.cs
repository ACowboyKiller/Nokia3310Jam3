﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerInventory : MonoBehaviour
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

    private BeaconPart _nearbyPart = null;

    #endregion

    #region --------------------    Private Methods

    private void OnTriggerEnter(Collider other) => _nearbyPart = other.GetComponent<BeaconPart>();

    private void OnTriggerExit(Collider other) => _nearbyPart = null;

    private void Update()
    {
        if (GameManager.instance.state.GetGameState() != GameManager.GameState.Gameplay) return;
        if (_nearbyPart != null && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.audio.PlayOneShot(GameManager.instance.pickupClip);
            collected[_nearbyPart.partIndex] = true;
            Destroy(_nearbyPart.gameObject);
        }
    }

    #endregion

}