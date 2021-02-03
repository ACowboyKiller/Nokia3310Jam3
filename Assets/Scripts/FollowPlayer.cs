using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
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

    /// <summary>
    /// The player transform to follow
    /// </summary>
    [SerializeField] private Transform _player = null;

    /// <summary>
    /// The starting offset from the follow transform
    /// </summary>
    private Vector3 _offset = Vector3.zero;

    #endregion

    #region --------------------    Private Methods

    /// <summary>
    /// Set the offset
    /// </summary>
    private void Start() => _offset = _player.position - transform.position;

    /// <summary>
    /// Update the offset
    /// </summary>
    private void LateUpdate() => transform.position = _player.position + _offset;

    #endregion

}