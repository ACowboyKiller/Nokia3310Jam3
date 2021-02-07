using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class PlayerMovement : MonoBehaviour
{

    #region --------------------    Public Enumerations



    #endregion

    #region --------------------    Public Events



    #endregion

    #region --------------------    Public Properties
    public GameObject player;
    public Rigidbody rb;
    public float impulseSpeed = 1;
    public bool isActive;
    public bool isPlayer; 
    public CinemachineVirtualCamera cam;
    public PlayerShipManager playerShipManager; 
    #endregion

    #region --------------------    Public Methods



    #endregion

    #region --------------------    Private Fields



    #endregion

    #region --------------------    Private Methods

    private void Awake()
    {
        rb = player.GetComponent<Rigidbody>(); 
    }
    void CameraControl()
    {
        if (isActive)
        {
            cam.Priority = 10; 
        } else
        {
            cam.Priority = 0; 
        }
    }
    void PhysicsRotation()
    {
        if (isPlayer)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddTorque(player.transform.right * impulseSpeed / 10, ForceMode.Force);
            }
            //
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddTorque(player.transform.right * -impulseSpeed / 10, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddTorque(player.transform.up * -impulseSpeed / 10, ForceMode.Force);
            }
            //
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddTorque(player.transform.up * impulseSpeed / 10, ForceMode.Force);
            }
        } else
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddTorque(player.transform.right * impulseSpeed / 3, ForceMode.Force);
            }
            //
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddTorque(player.transform.right * -impulseSpeed / 3, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddTorque(player.transform.up * -impulseSpeed / 3, ForceMode.Force);
            }
            //
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddTorque(player.transform.up * impulseSpeed / 3, ForceMode.Force);
            }
        }
          
      
    }
    public void PhysicsBrake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.drag = 4;
            rb.angularDrag = 8;
        }
        else
        {
            rb.angularDrag = 5f;
            rb.drag = .3f;
        }
    }
    void PhysicsMovement()
    {

 

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(player.transform.forward * (impulseSpeed), ForceMode.Impulse);
        }
        //
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.AddForce(player.transform.forward * (-impulseSpeed), ForceMode.Impulse);
        }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(player.transform.forward * impulseSpeed/10, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(player.transform.forward * -impulseSpeed / 10, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(player.transform.right * -impulseSpeed / 10, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(player.transform.right * impulseSpeed / 10, ForceMode.Impulse);
            }
       
          
   

    }

    private void Update()
    {
        CameraControl();
        PhysicsBrake(); 
        if (isActive)
        {
          
            if (isPlayer)
            {
                if (rb.angularVelocity.magnitude <= (impulseSpeed * 2))
                {
                    PhysicsRotation();
                }
            } else
            {
                if (rb.angularVelocity.magnitude <= (impulseSpeed * 3))
                {
                    PhysicsRotation();
                }
            }
          
            if (rb.velocity.magnitude <= (impulseSpeed * 5))
            {
                PhysicsMovement();
            }
            if (isPlayer)
            {
                if (rb.gameObject.activeInHierarchy == false)
                {
                    rb.gameObject.SetActive(true);
                    rb.transform.position = playerShipManager.playerDock.position; 
                    rb.transform.rotation = playerShipManager.playerDock.rotation;
                }
                rb.isKinematic = false;
            }
        } else
        {
            if (isPlayer)
            {
                rb.transform.position = playerShipManager.ship.rb.transform.position;
                rb.isKinematic = true;
                rb.gameObject.SetActive(false);
            }
        }

        //

    }

    #endregion

}