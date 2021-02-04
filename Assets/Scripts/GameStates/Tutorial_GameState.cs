using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tutorial_GameState : iGameState
{

    #region --------------------    Public Enumerations



    #endregion

    #region --------------------    Public Events



    #endregion

    #region --------------------    Public Properties

    /// <summary>
    /// The tutorial steps
    /// </summary>
    public List<iTutorialStep> tutorialSteps = new List<iTutorialStep>()
    {
        new Pitch_TutorialStep(),
        new Yaw_TutorialStep(),
        new Strafe_TutorialStep(),
        new Thrust_TutorialStep(),
        new Break_TutorialStep(),
        new Exit_TutorialStep(),
        new Approach_TutorialStep(),
        new Interact_TutorialStep(),
        new Return_TutorialStep(),
        new Board_TutorialStep(),
        new Radar_TutorialStep()
    };

    #endregion

    #region --------------------    Public Methods

    /// <summary>
    /// Enable the first tutorial panel
    /// </summary>
    public iGameState EnterState()
    {
        GameManager.instance.tutorialPanels[_stepIndex].SetActive(true);
        return this;
    }

    /// <summary>
    /// Attempts to interact with the tutorial step (mostly used to dismiss messages)
    /// </summary>
    public void InteractState() => tutorialSteps[_stepIndex].InteractStep();

    public iGameState LeaveState(iGameState _pNextState) => _pNextState?.EnterState();

    /// <summary>
    /// Called on update
    /// </summary>
    public void UpdateState()
    {
        if (tutorialSteps[_stepIndex].CheckStep()) _MoveToNextStep();
    }

    #endregion

    #region --------------------    Private Fields

    /// <summary>
    /// The current tutorial step index
    /// </summary>
    private int _stepIndex = 0;
    private float _panelDelayTimer = 0f;

    #endregion

    #region --------------------    Private Methods

    /// <summary>
    /// Moves to the next step index
    /// </summary>
    private void _MoveToNextStep()
    {
        GameManager.instance.tutorialPanels[_stepIndex].SetActive(false);
        _stepIndex++;
        if (_stepIndex < tutorialSteps.Count)
        {
            DOTween.To(() => _panelDelayTimer, x => _panelDelayTimer = x, 1f, 3f).OnComplete(() => GameManager.instance.tutorialPanels[_stepIndex].SetActive(true));
        }
        else
        {
            GameManager.instance.CompleteTutorial();
        }
    }

    #endregion

}