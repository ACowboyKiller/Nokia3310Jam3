using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust_TutorialStep : iTutorialStep
{

    #region --------------------    Public Methods

    public bool CheckStep() => (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow));

    public void InteractStep() { }

    #endregion

}