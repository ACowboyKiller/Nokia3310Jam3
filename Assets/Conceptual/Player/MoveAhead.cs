using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAhead : MonoBehaviour
{

    #region --------------------    Public Enumerations



    #endregion

    #region --------------------    Public Events



    #endregion

    #region --------------------    Public Properties
    public PlayerMovement pm; 


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
        transform.localPosition = pm.rb.velocity.normalized * 2; 
    }

    #endregion

}