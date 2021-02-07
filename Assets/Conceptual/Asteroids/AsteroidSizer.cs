using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSizer : MonoBehaviour
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

    private void Awake()
    {
        transform.localScale = new Vector3(Random.Range(1, 3f), Random.Range(1, 3f), Random.Range(1, 3f));
        transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f), Random.Range(-.1f, .1f))); 
    }

    private void Update()
    {

    }

    #endregion

}