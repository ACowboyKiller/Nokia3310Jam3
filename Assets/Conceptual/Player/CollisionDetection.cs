using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    #region --------------------    Public Enumerations



    #endregion

    #region --------------------    Public Events



    #endregion

    #region --------------------    Public Properties



    #endregion

    #region --------------------    Public Methods



    #endregion

    #region --------------------    Private Fields



    #endregion

    #region --------------------    Private Methods
    public PlayerMovement pm;
    public GameManager gM; 
    private void Awake()
    {
       
    }

    private void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (pm.rb.velocity.magnitude > 1)
        {
            print("BONK");
            pm.enabled = false;
            StartCoroutine(DieWithDelay()); 
        }
    }

    IEnumerator DieWithDelay()
    {
        yield return new WaitForSeconds(1f);
        gM.Defeat(); 
    }
    #endregion

}