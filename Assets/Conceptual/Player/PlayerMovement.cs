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
    public bool isPlayer;
    public bool blockInput; 
    public CinemachineVirtualCamera cam;
    public PlayerShipManager playerShipManager;

    public bool isInputUnlocked =>
        (GameManager.instance.state.GetGameState() == GameManager.GameState.Gameplay) ||

        ((GameManager.instance.state.GetGameState() == GameManager.GameState.Tutorial)
        && !((Tutorial_GameState)GameManager.instance.state).isTutorialMessageVisible);
    #endregion

    #region --------------------    Public Methods



    #endregion

    #region --------------------    Private Fields



    #endregion

    #region --------------------    Private Methods

    private void Awake() => rb = player.GetComponent<Rigidbody>();

    void CameraControl() => cam.Priority = (enabled) ? 10 : 0;

    void PhysicsRotation()
    {
        float _val = (isPlayer) ? 10f : 1f; 
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddTorque(player.transform.right * impulseSpeed / _val, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddTorque(player.transform.right * -impulseSpeed / _val, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(player.transform.up * -impulseSpeed / _val, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(player.transform.up * impulseSpeed / _val, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(player.transform.forward * impulseSpeed / _val, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(player.transform.forward * -impulseSpeed / _val, ForceMode.Force);
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

    public void PhysicsStop() => rb.velocity = Vector3.zero;

    void PhysicsMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(player.transform.forward * (impulseSpeed), ForceMode.Impulse);
        }
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
    }

    private void Update()
    {
        CameraControl();
        PhysicsBrake(); 
        if (isInputUnlocked)
        {
            float _val = (isPlayer) ? 2f : 3f;
            if (rb.angularVelocity.magnitude <= (impulseSpeed * _val))
            {
                PhysicsRotation();
            }
          
            if (rb.velocity.magnitude <= (impulseSpeed * 5))
            {
                PhysicsMovement();
            }

            if (isPlayer)
            {
                if (rb.gameObject.activeInHierarchy == false)
                {
                    rb.transform.position = playerShipManager.playerDock.position; 
                    rb.transform.rotation = playerShipManager.playerDock.rotation;
                }
                rb.isKinematic = false;
            }
        }
    }

    #endregion

}