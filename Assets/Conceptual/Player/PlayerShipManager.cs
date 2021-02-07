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
        



    }
    void ShipToggle()
    {

        if (canToggle)
        {
           
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Vector3.Distance(ship.rb.transform.position, player.rb.transform.position) < 3)
                    {
                        shipToggle = !shipToggle;
                    }
                    if (shipToggle)
                    {
                        player.isActive = false;
                        ship.isActive = true;
                    }
                    else
                    {
                        player.isActive = true;
                        ship.isActive = false;
                    }
            }

                
            
        }


    }
    #endregion

}