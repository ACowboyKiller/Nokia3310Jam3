using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_GameState : iGameState
{

    #region --------------------    Public Methods

    public GameManager.GameState GetGameState() => GameManager.GameState.Gameplay;
    public iGameState EnterState() => this;
    public void InteractState() {}
    public void InteractState(KeyCode _pKey) {}
    public iGameState LeaveState(iGameState _pNextState) => _pNextState?.EnterState();
    public void UpdateState() {}

    #endregion

}