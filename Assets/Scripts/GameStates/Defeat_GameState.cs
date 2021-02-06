using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat_GameState : iGameState
{

    #region --------------------    Public Methods

    public GameManager.GameState GetGameState() => GameManager.GameState.Defeat;
    public iGameState EnterState() => this;
    public void InteractState() {}
    public void InteractState(KeyCode _pKey) => GameManager.instance.Restart();
    public iGameState LeaveState(iGameState _pNextState) => _pNextState?.EnterState();
    public void UpdateState() {}

    #endregion

}