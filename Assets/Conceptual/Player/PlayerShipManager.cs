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
    public PlayerMovement ship;
    public PlayerMovement player;
    public bool shipToggle;
    public bool canToggle;
    public Transform playerDock;
    #endregion

    #region --------------------    Public Methods



    #endregion

    #region --------------------    Private Fields



    #endregion

    #region --------------------    Private Methods

    private void Awake()
    {

    }

    private void Update()
    {
        ShipToggle(); 
        if (GameManager.instance.state.GetGameState() == GameManager.GameState.Tutorial && ((Tutorial_GameState)GameManager.instance.state).isTutorialMessageVisible)
        {
            ship.PhysicsBrake();
            player.PhysicsBrake();
            ship.isActive = false; 
        } else if (GameManager.instance.state.GetGameState() == GameManager.GameState.Tutorial && ((Tutorial_GameState)GameManager.instance.state).isTutorialMessageVisible == false)
        {
            if (shipToggle)
            {
                ship.isActive = true; 
            }
        }



    }
    void ShipToggle()
    {

        if (canToggle)
        {
           
                if (Input.GetKeyDown(KeyCode.E))
                {
                ship.rb.velocity = Vector3.zero; 
                    player.PhysicsBrake(); 
                    if (shipToggle)
                    {
                        shipToggle = !shipToggle;
                    } else
                    {
                        if (Vector3.Distance(ship.rb.transform.position, player.rb.transform.position) < 3)
                        {
                            shipToggle = !shipToggle;
                        }
                    }
                    
                   
                }
            if (shipToggle)
            {
                player.isActive = false;
                ship.isActive = true;
                player.transform.position = playerDock.position;
                player.gameObject.SetActive(false);
            }
            else
            {
                player.gameObject.SetActive(true); 
                player.isActive = true;
                ship.isActive = false;
            }


        }


    }
    #endregion

}