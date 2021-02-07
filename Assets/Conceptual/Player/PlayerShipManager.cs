using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipManager : MonoBehaviour
{

    #region --------------------    Public Enumerations



    #endregion

    #region --------------------    Public Events



    #endregion

    #region --------------------    Public Properties
    public static bool shipToggle { get; private set; } = true;
    public PlayerMovement ship;
    public PlayerMovement player;
    public static bool isNearbyPlayer { get; private set; } = false;
    public Transform playerDock;

    public bool canToggle =>
        (GameManager.instance.state.GetGameState() == GameManager.GameState.Gameplay) ||
        
        ((GameManager.instance.state.GetGameState() == GameManager.GameState.Tutorial) 
        && !((Tutorial_GameState)GameManager.instance.state).isTutorialMessageVisible 
        && ((Tutorial_GameState)GameManager.instance.state).dismissIndex > 4
        && ((Tutorial_GameState)GameManager.instance.state).hasDismissed);
    #endregion

    #region --------------------    Public Methods



    #endregion

    #region --------------------    Private Fields



    #endregion

    #region --------------------    Private Methods

    private void Awake()
    {
        shipToggle = true;
        isNearbyPlayer = false;
    }

    private void Update()
    {
        ShipToggle();
        isNearbyPlayer = Vector3.Distance(ship.rb.transform.position, player.rb.transform.position) < 3;
    }

    void ShipToggle()
    {
        if (!canToggle) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            ship.rb.velocity = Vector3.zero; 
            player.PhysicsBrake();
            ship.enabled = (ship.enabled) ? !ship.enabled : ((isNearbyPlayer) ? !ship.enabled : ship.enabled);
            player.enabled = !ship.enabled;
        }
        player.transform.position = (ship.enabled) ? playerDock.position : player.transform.position;
        player.gameObject.SetActive(!ship.enabled);
        shipToggle = ship.enabled;
    }

    #endregion

}