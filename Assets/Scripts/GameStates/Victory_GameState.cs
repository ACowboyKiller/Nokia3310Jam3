using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory_GameState : iGameState
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
    /// Restarts the game
    /// </summary>
    public void InteractState() => GameManager.instance.Restart();

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