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

    [SerializeField] GameObject Feet;

    //Cache
    float horizontalMove = 0f;
    int _numberOfJumps;
    bool _jump = false;
    bool _canJump = true;
    Vector2 _transformFeet;
    RunnerAction _action;

    public void Init()
    {
        _action = new RunnerAction();
        _action.Enable();

        _numberOfJumps = _maxNumberOfJumps;

        _animator.SetBool("walk", true);
    }

    void Update()
    {
        if (_action.Runner.Jump.triggered && _canJump)
        {
            _jump = true;
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * _speed * Time.fixedDeltaTime;

        Collider2D coll = Physics2D.OverlapCircle(UpdateFeetTransform(), 0.1f, _layer);

        if (_jump)
        {
            rb.velocity = new Vector2(0, _jumpForce);
            _jump = false;
            _numberOfJumps--;
        }

        if (coll && _jump == false)
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
            _animator.SetBool("jump", true);
            _canJump = false;
        }
    }



    Vector2 UpdateFeetTransform()
    {
        _transformFeet.x = Feet.transform.position.x;
        _transformFeet.y = Feet.transform.position.y;
        return _transformFeet;
    }
}
