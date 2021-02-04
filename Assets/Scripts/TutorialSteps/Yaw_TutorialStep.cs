using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yaw_TutorialStep : iTutorialStep
{

    #region --------------------    Public Methods

    public bool CheckStep() => (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D));

    public void InteractStep() { }

    #endregion

}