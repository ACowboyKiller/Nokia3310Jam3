using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iTutorialStep
{

    #region --------------------    Public Methods

    void ConfigureStep();
    void InteractStep();
    bool CheckStep();

    #endregion

}