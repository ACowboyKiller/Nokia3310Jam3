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
    [SerializeField] [Range(1f, 100f)] private float _freqRatio = 20f;
    [SerializeField] [Range(1f, 100f)] private float _radarRadius = 50f;
    [SerializeField] PlayerShipManager _shipManager = null;
    private float _beepTimer = 0f;

    #endregion

    #region --------------------    Private Methods

    private void Update()
    {
        allParts = (allParts.Count == 0) ? new List<BeaconPart>(FindObjectsOfType<BeaconPart>()) : allParts;
        _radarButton.gameObject.SetActive(_shipManager.shipToggle);
        if (!_shipManager.shipToggle) return;
        if (_beepTimer > 0f)
        {
            _beepTimer -= Time.deltaTime;
            return;
        }
        GameManager.instance.audio.PlayOneShot(GameManager.instance.radarBlip);
        _radarButton.sprite = _radarOn;
        _radarButton.DOColor(Color.white, Mathf.Min(1f, _beepTimer))
            .OnComplete(() => { _radarButton.sprite = _radarOff; });
        float _dist = _FindClosestPart();
        if (_dist > _radarRadius) return;
        _beepTimer = _dist / _freqRatio;
    }

    private float _FindClosestPart()
    {
        float _nearest = 100f;
        for (int i = 0; i < allParts.Count; i ++)
        {
            if (allParts[i] == null) continue;
            float _dist = Vector3.Distance(allParts[i].transform.position, transform.position);
            _nearest = (_dist < _nearest) ? _dist : _nearest;
        }
        return _nearest;
    }

    #endregion

}