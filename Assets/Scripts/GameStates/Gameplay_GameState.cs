using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_GameState : iGameState
{

    #region --------------------    Public Methods

    public iGameState EnterState() => this;

    public void InteractState()
    {
    }

    public iGameState LeaveState(iGameState _pNextState) => _pNextState?.EnterState();

    public void UpdateState()
    {
    }

    #endregion

}