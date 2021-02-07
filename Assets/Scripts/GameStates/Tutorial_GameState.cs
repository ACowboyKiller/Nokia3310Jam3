using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tutorial_GameState : iGameState
{

    #region --------------------    Public Properties

    /// <summary>
    /// The tutorial steps
    /// </summary>
    public List<TutorialStep> tutorialSteps { get; private set; } = null;

    /// <summary>
    /// Returns whether or not the tutorial message is displayed
    /// </summary>
    public bool isTutorialMessageVisible => _stepIndex != _dismissIndex;

    /// <summary>
    /// Returns the tutorial step index
    /// </summary>
    public int stepIndex => _stepIndex;

    #endregion

    #region --------------------    Public Methods

    public GameManager.GameState GetGameState() => GameManager.GameState.Tutorial;

    /// <summary>
    /// Enable the first tutorial panel
    /// </summary>
    public iGameState EnterState()
    {
        _ConfigureState();
        return this;
    }

    /// <summary>
    /// Attempts to begin the next tutorial step
    /// </summary>
    public void InteractState() => DisplayVisual();

    /// <summary>
    /// Attempts to dismiss the visual of the current tutorial step
    /// </summary>
    public void InteractState(KeyCode _pKey) => DismissVisual();

    /// <summary>
    /// Called on update
    /// </summary>
    public void UpdateState()
    {
        if (_stepIndex < 0) _MoveToNextStep();
        if (_dismissIndex == _stepIndex && tutorialSteps[_stepIndex].CheckStep()) _MoveToNextStep();
    }

    /// <summary>
    /// Leaves the game state and enters the next state
    /// </summary>
    /// <param name="_pNextState"></param>
    /// <returns></returns>
    public iGameState LeaveState(iGameState _pNextState) => _pNextState?.EnterState();

    /// <summary>
    /// Displays the visual prompt for the tutorial step
    /// </summary>
    public void DisplayVisual() => GameManager.instance.tutorialPanels[_stepIndex].SetActive(true);

    /// <summary>
    /// Dismisses the visual prompt for the tutorial step
    /// </summary>
    public void DismissVisual()
    {
        /// Prevent additional E key presses from disrupting the flow of the tutorial
        _dismissIndex = Mathf.Max(_dismissIndex + 1, _stepIndex);
        GameManager.instance.tutorialPanels[_stepIndex].SetActive(false);
    }

    #endregion

    #region --------------------    Private Fields

    /// <summary>
    /// The current tutorial step index
    /// </summary>
    private int _stepIndex = -1;
    private int _dismissIndex = -1;

    #endregion

    #region --------------------    Private Methods

    /// <summary>
    /// Configures the game state
    /// </summary>
    private void _ConfigureState()
    {
        tutorialSteps = new List<TutorialStep>() {
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
    }

    /// <summary>
    /// Moves to the next step index
    /// </summary>
    private void _MoveToNextStep()
    {
        _stepIndex++;
        tutorialSteps[_stepIndex].ConfigureStep();
        if (_stepIndex == 0) return;
        GameManager.instance.audio.PlayOneShot(GameManager.instance.tutorialStepCompleteClip);
        GameManager.instance.onTutorialStepCompleteEvent?.Invoke();
        GameManager.instance.onTutorialStepCompleteEvent = null;
        if (_stepIndex >= tutorialSteps.Count) GameManager.instance.CompleteTutorial();
    }

    #endregion

}