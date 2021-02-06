using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MessagePanel : MonoBehaviour
{

    #region --------------------    Private Fields

    [Header("Panel Configurations")]
    [SerializeField] private TMP_Text _messageText = null;
    private string _cachedMessageText = "";

    #endregion

    #region --------------------    Private Methods

    /// <summary>
    /// Cache the desired text and then begin the text display animation
    /// </summary>
    private void OnEnable()
    {
        _cachedMessageText = _messageText.text;
        _messageText.text = ""; 
        _messageText.DOText(_cachedMessageText, _cachedMessageText.Length / 10f)
            .SetDelay(1f)
            .OnUpdate(_CheckForTypeClipAudio)
            .SetEase(Ease.Linear)
            .OnComplete(() => GameManager.instance.audio.Stop());
    }

    /// <summary>
    /// Checks to see if the audio source is playing a sound and if not, adjust the pitch slightly and plays the typing sound
    /// </summary>
    private void _CheckForTypeClipAudio()
    {
        if (GameManager.instance.audio.isPlaying || !gameObject.activeInHierarchy) return;
        GameManager.instance.audio.pitch = 1f + Random.Range(-0.1f, 0.1f);
        GameManager.instance.audio.PlayOneShot(GameManager.instance.typeClip);
    }

    #endregion

}