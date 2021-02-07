using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconPart : MonoBehaviour
{

    #region --------------------    Public Properties

    public int partIndex => _partIndex;

    #endregion

    #region --------------------    Private Fields

    [SerializeField] private int _partIndex = 0;

    #endregion

}