using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar_TutorialStep : iTutorialStep
{

    #region --------------------    Public Methods

    /// <summary>
    /// TODO:   Complete this tutorial step
    /// </summary>
    /// <returns></returns>
    public bool CheckStep() => _isDismissed;

    public void InteractStep() => _isDismissed = true;

    #endregion

    #region --------------------    Private Fields

    private bool _isDismissed = false;

    #endregion

}