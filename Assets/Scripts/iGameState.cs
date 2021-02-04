using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iGameState
{

    #region --------------------    Public Methods

    GameManager.GameState GetGameState();
    iGameState EnterState();
    void UpdateState();
    void InteractState();
    void InteractState(KeyCode _pKey);
    iGameState LeaveState(iGameState _pNextState);

    #endregion

}