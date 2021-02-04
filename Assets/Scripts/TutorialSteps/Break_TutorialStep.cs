using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_TutorialStep : iTutorialStep
{

    #region --------------------    Public Methods

    public bool CheckStep() => Input.GetKeyDown(KeyCode.Space);

    public void InteractStep() { }

    #endregion

}