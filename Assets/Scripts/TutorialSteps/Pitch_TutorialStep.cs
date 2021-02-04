using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch_TutorialStep : iTutorialStep
{

    #region --------------------    Public Methods

    public bool CheckStep() => (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S));

    public void InteractStep() { }

    #endregion

}