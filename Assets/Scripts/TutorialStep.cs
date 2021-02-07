using UnityEngine;
using DG.Tweening;

public class TutorialStep
{

    #region --------------------    Public Methods

    /// <summary>
    /// Performs internal configurations such as auto-scheduling future tutorial steps
    /// </summary>
    /// <returns></returns>
    public virtual void ConfigureStep() => _AutoScheduleNextStep(3f);

    /// <summary>
    /// Used to check if the step is complete
    /// </summary>
    /// <returns></returns>
    public virtual bool CheckStep() => false;

    #endregion

    #region --------------------    Protected Methods

    /// <summary>
    /// Schedules future tutorial steps after the provided delay
    /// </summary>
    /// <param name="_pDelay"></param>
    protected void _AutoScheduleNextStep(float _pDelay) =>
        GameManager.instance.onTutorialStepCompleteEvent += () => { DOTween.To(() => _tmr, x => _tmr = x, 1f, _pDelay).OnComplete(() => GameManager.instance.state.InteractState()); };

    #endregion

    #region --------------------    Private Fields

    /// <summary>
    /// The timer used for the tutorial step scheduling delay
    /// </summary>
    private float _tmr = 0f;

    #endregion

}



/// <summary>
/// Teaches the player to adjust pitch
/// </summary>
public class Pitch_TutorialStep : TutorialStep
{
    public override void ConfigureStep()
    {
        /// Displays the prompt for the state (because this state is immediately triggered)
        _AutoScheduleNextStep(3f);
        GameManager.instance.state.InteractState();
    }
    public override bool CheckStep() => (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S));
}



/// <summary>
/// Teaches the player to adjust yaw
/// </summary>
public class Yaw_TutorialStep : TutorialStep
{
    public override bool CheckStep() => (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D));
}



/// <summary>
/// Teaches the player to strafe
/// </summary>
public class Strafe_TutorialStep : TutorialStep
{
    public override bool CheckStep() => (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow));
}



/// <summary>
/// Teaches the player to thrust
/// </summary>
public class Thrust_TutorialStep : TutorialStep
{
    public override bool CheckStep() => (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow));
}



/// <summary>
/// Teaches the player to break
/// </summary>
public class Break_TutorialStep : TutorialStep
{
    public override bool CheckStep() => Input.GetKeyDown(KeyCode.Space);
}



/// <summary>
/// Teaches the player to exit the ship
/// </summary>
public class Exit_TutorialStep : TutorialStep
{
    /// TODO:   Check to see if player is out of ship
}



/// <summary>
/// Instructs the player to approach the beacon
/// </summary>
public class Approach_TutorialStep : TutorialStep
{
    public override void ConfigureStep() => _AutoScheduleNextStep(1f);
    public override bool CheckStep() => Beacon.isNearby;
    /// TODO:   Check to see if player is near the beacon
}



/// <summary>
/// Teaches the player to interact with objects
/// </summary>
public class Interact_TutorialStep : TutorialStep
{
    public override void ConfigureStep() => _AutoScheduleNextStep(0f);
    public override bool CheckStep() => Beacon.isInteracted;
    /// TODO:   Check to see if player has interacted with the beacon
}



/// <summary>
/// Instructs the player to return to their ship
/// </summary>
public class Return_TutorialStep : TutorialStep
{
    public override void ConfigureStep() => _AutoScheduleNextStep(1f);
    /// TODO:   Check to see if player is near the ship
}



/// <summary>
/// Teaches the player how to board their ship
/// </summary>
public class Board_TutorialStep : TutorialStep
{
    /// TODO:   Check to see if player has boarded the ship
}



/// <summary>
/// Teaches the player how the radar works
/// </summary>
public class Radar_TutorialStep : TutorialStep
{
    /// <summary>
    /// Automatically completes because it is a message
    /// </summary>
    /// <returns></returns>
    public override bool CheckStep() => true;
}