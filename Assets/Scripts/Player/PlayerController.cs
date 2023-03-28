using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public float speed = 1f;
    public bool invencible = false;

    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 7f;

    public GameObject endScreen;
    public GameObject coinCollector;
    [SerializeField] private BounceHelper _bounceHelper;

    [Header("Text")]
    public TextMeshPro uiTextPowerUp;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    [Header("Particles")]
    public ParticleSystem killParticle;

    [Header("Limites")]
    public Vector2 limit = new Vector2(-4, 5);


    private void OnValidate()
    {
        _bounceHelper = GetComponent<BounceHelper>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _bounceHelper.Bounce();
        ResetSpeed();
    }

    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        if (_pos.x < limit.x) _pos.x = limit.x;
        else if (_pos.x > limit.y) _pos.x = limit.y;

        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
            if (!invencible)
            {
                MoveBack();
                EndGame(AnimatorManager.AnimationType.DEAD);
                if (killParticle != null) killParticle.Play();
            }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
            EndGame();
    }

    public void Bounce()
    {
        _bounceHelper.Bounce();
    }

    private void MoveBack()
    {
        transform.DOMoveZ(-1f, .3f).SetRelative();
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
    }

    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedToAnimation);
    }

    #region POWERUPS
    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);
    }

    public void ChangeCoinCollectorSize(float amount) 
    {
        coinCollector.gameObject.transform.localScale = Vector3.one * amount;
    }
    #endregion
}
