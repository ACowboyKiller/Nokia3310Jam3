using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_GameState : iGameState
{

    #region --------------------    Public Methods

    public GameManager.GameState GetGameState() => GameManager.GameState.Intro;
    public iGameState EnterState() => this;
    public void InteractState() {}
    public void InteractState(KeyCode _pKey) => GameManager.instance.CompleteIntro();
    public iGameState LeaveState(iGameState _pNextState) => _pNextState?.EnterState();
    public void UpdateState() { }

    #endregion

}