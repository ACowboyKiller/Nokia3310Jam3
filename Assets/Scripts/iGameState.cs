using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iGameState
{

    #region --------------------    Public Methods

    iGameState EnterState();
    void UpdateState();
    void InteractState();
    iGameState LeaveState(iGameState _pNextState);

    #endregion

}