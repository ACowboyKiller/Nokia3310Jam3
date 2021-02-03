using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strafe_TutorialStep : iTutorialStep
{

    #region --------------------    Public Methods

    public bool CheckStep() => (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow));

    public void InteractStep() { }

    #endregion

}