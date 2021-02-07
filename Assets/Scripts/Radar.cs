using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Radar : MonoBehaviour
{

    #region --------------------    Public Enumerations



    #endregion

    #region --------------------    Public Events



    #endregion

    #region --------------------    Public Properties

    public List<BeaconPart> allParts { get; set; } = new List<BeaconPart>();

    #endregion

    #region --------------------    Public Methods



    #endregion

    #region --------------------    Private Fields

    [SerializeField] private Image _radarButton = null;
    [SerializeField] private Sprite _radarOn = null;
    [SerializeField] private Sprite _radarOff = null;
    [SerializeField] [Range(1f, 30f)] private float _freqRatio = 5f;
    [SerializeField] [Range(1f, 500f)] private float _radarRadius = 300f;
    [SerializeField] [Range(0f, 5f)] private float _minFreq = 0.5f;
    [SerializeField] PlayerShipManager _shipManager = null;
    private float _beepTimer = 0f;
    private bool _setup = false;

    #endregion

    #region --------------------    Private Methods

    private void Update()
    {
        allParts = (!_setup) ? new List<BeaconPart>(FindObjectsOfType<BeaconPart>()) : allParts;
        _setup = true;
        if (allParts.Count == 0) return;
        _radarButton.enabled = _shipManager.shipToggle;
        if (!_shipManager.shipToggle) return;
        float _dist = _FindClosestPart();
        float _freq = Mathf.Max((_dist / _radarRadius) * _freqRatio, _minFreq);
        if (_beepTimer > 0f)
        {
            _beepTimer = (_beepTimer < _freq) ? _beepTimer : _freq;
            _beepTimer -= (_dist >= _radarRadius)? 0f : Time.deltaTime;
            return;
        }
        else
        {
            _beepTimer = _radarRadius;
            GameManager.instance.audio.PlayOneShot(GameManager.instance.radarBlip);
            _radarButton.sprite = _radarOn;
            _radarButton.DOColor(Color.white, Mathf.Min(_minFreq, _beepTimer))
                .OnComplete(() => { _radarButton.sprite = _radarOff; });
        }
    }

    private float _FindClosestPart()
    {
        float _nearest = _radarRadius;
        for (int i = 0; i < allParts.Count; i ++)
        {
            if (allParts[i] == null) continue;
            float _dist = Vector3.Distance(allParts[i].transform.position, _shipManager.ship.transform.position);
            _nearest = (_dist < _nearest) ? _dist : _nearest;
        }
        return _nearest;
    }

    #endregion

}