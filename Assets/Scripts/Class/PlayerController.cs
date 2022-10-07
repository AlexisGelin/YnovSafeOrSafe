using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController>
{
    [SerializeField] int _speed = 10;
    [SerializeField] int _jumpForce = 10;
    [SerializeField] int _maxNumberOfJumps = 2;

    [SerializeField] LayerMask _layer;

    [SerializeField] SpriteRenderer _sprite;

    [SerializeField] Animator _animator;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] GameObject _feet,_front;

    //Cache
    int _numberOfJumps;
    bool _jump = false;
    bool _canJump = true;
    Vector2 _transformFeet,_tranformFront;
    RunnerAction _action;

    GameManager _gameManager;
    PlayerData _playerData;
    UIManager _uiManager;

    public void Init()
    {
        _action = new RunnerAction();
        _action.Enable();

        _numberOfJumps = _maxNumberOfJumps;

        _animator.SetBool("walk", true);

        _gameManager = GameManager.Instance;
        _playerData = PlayerData.Instance;
        _uiManager = UIManager.Instance;
    }

    void Update()
    {
        _playerData.Score = Mathf.RoundToInt(transform.position.x);

        _uiManager.RunningScreen.UpdateDistText();

        if (_action.Runner.Jump.triggered && _canJump)
        {
            _jump = true;
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * _speed * Time.fixedDeltaTime;

        Collider2D collFeet = Physics2D.OverlapCircle(UpdateTransform(_feet,_transformFeet), 0.1f, _layer);
        Collider2D collFront = Physics2D.OverlapCircle(UpdateTransform(_front, _tranformFront), 0.1f, _layer);


        if (collFront)
        {
            _gameManager.EndGame();
        }

        if (collFeet && _jump == false)
        {
            _animator.SetBool("jump", false);
            _canJump = true;

            _numberOfJumps = _maxNumberOfJumps;
        }
        else if (_numberOfJumps > 0)
        {
            _canJump = true;
        }
        else
        {
            _canJump = false;
        }

        if (_jump)
        {
            _animator.SetBool("jump", true);

            rb.velocity = new Vector2(0, _jumpForce);
            _jump = false;
            _numberOfJumps--;
        }
    }
    
    Vector2 UpdateTransform(GameObject GO,Vector2 transform)
    {
        transform.x = GO.transform.position.x;
        transform.y = GO.transform.position.y;
        return transform;
    }

    private void OnBecameInvisible()
    {
        if (_gameManager) _gameManager.EndGame();
    }
}
