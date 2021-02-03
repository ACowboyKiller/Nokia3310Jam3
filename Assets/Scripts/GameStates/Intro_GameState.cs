using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_GameState : iGameState
{

    #region --------------------    Public Enumerations



    #endregion

    #region --------------------    Public Events



    #endregion

    #region --------------------    Public Properties



    #endregion

    #region --------------------    Public Methods

    public iGameState EnterState() => this;

    /// <summary>
    /// Completes the intro
    /// </summary>
    public void InteractState()
    {
        GameManager.instance.CompleteIntro();
    }

    public iGameState LeaveState(iGameState _pNextState) => _pNextState?.EnterState();

    public void UpdateState()
    {
    }

    #endregion

    #region --------------------    Private Fields



    #endregion

    #region --------------------    Private Methods



    #endregion

}