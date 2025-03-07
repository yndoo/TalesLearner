using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, ISuperJumpable
{
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");

    public float DefaultMoveSpeed;
    public float JumpPower;
    public float CurMoveSpeed
    {
        get => _curMoveSpeed;
        set
        {
            if(value > PublicDefinitions.MaxSpeed)
            {
                _curMoveSpeed = PublicDefinitions.MaxSpeed;
            }
            else if(value < DefaultMoveSpeed)
            {
                _curMoveSpeed = DefaultMoveSpeed;
            }
            else
            {
                _curMoveSpeed = value;
            }
        }
    }
    [SerializeField] private float _curMoveSpeed;

    private Vector2 curMovementInput;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private bool isDashMode = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        CurMoveSpeed = DefaultMoveSpeed;   
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (isDashMode && CharacterManager.Instance.Player.condition.CanUseStamina())
        {
            CurMoveSpeed += 0.2f;
            CharacterManager.Instance.Player.condition.UseStamina();
        }
        else
        {
            CurMoveSpeed -= 0.2f;
        }

        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= CurMoveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
            _animator.SetBool(IsRunning, true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            _animator.SetBool(IsRunning, false);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            _animator.SetBool(IsJumping, true);
            _rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && CharacterManager.Instance.Player.condition.CanUseStamina())
        {
            isDashMode = true;
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            isDashMode = false;
        }
    }

    public void SuperJump()
    {
        _rigidbody.AddForce(Vector3.up * JumpPower * 2, ForceMode.Impulse);
    }
}
