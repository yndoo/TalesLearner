using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, ISuperJumpable
{
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    private static readonly int IsDoubleJump = Animator.StringToHash("IsDoubleJump");

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
    public LayerMask groundLayerMask;

    // 캐릭터 & 카메라 회전 관련
    [Header("Rotation")]
    public Transform CameraContainer;
    public Transform MeshTransform;

    private Vector2 curMovementInput;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 curDir;
    private ParticleSystem dashVFX; 

    private bool isDashMode = false;
    private bool isJumping = false;
    private bool isDoubleJumping = false;
    [HideInInspector] public bool isDamaged = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        dashVFX = GetComponentInChildren<ParticleSystem>();
    }
    private void Start()
    {
        CurMoveSpeed = DefaultMoveSpeed;
        dashVFX.Stop();
    }
    private void FixedUpdate()
    {
        Move();

        if(isJumping && IsGround()) // 공중에 있지 않으면 되돌리기. 공중에 있는 동안 애니메이션 Falling Idle로 가있음. 
        {
            isJumping = false;
            isDoubleJumping = false;
            _animator.SetBool(IsJumping, false);
            _animator.SetBool(IsDoubleJump, false);
        }
    }

    private void Move()
    {
        // 대쉬 적용
        if (isDashMode && CharacterManager.Instance.Player.condition.CanUseStamina())
        {
            CurMoveSpeed += 0.2f;
            CharacterManager.Instance.Player.condition.UseStamina();
        }
        else
        {
            CurMoveSpeed -= 0.2f;
        }

        // 속도 이펙트
        if (CurMoveSpeed >= 22)
        {
            UIManager.Instance.SpeedLineEffect.SetActive(true);
        }
        else
        {
            UIManager.Instance.SpeedLineEffect.SetActive(false);
        }

        // 방향 적용
        curDir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        if (curDir.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(curDir);
            MeshTransform.rotation = Quaternion.Slerp(MeshTransform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // 이동 속도 적용
        if(!isDamaged)
        {
            curDir *= CurMoveSpeed;
        }
        curDir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = curDir;

        // 카메라 회전 적용
        // TODO : minCamXRot~max 범위 넘어가면 카메라 돌려주는 코드 추가하기?

        // 애니메이션 속도 적용
        _animator.speed = CurMoveSpeed / DefaultMoveSpeed;
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
        if (context.phase == InputActionPhase.Started)
        {
            if (isDamaged || isDoubleJumping) return;

            if(isJumping && !IsGround()) // 2단 점프
            {
                isDoubleJumping = true;
                _animator.SetBool(IsDoubleJump, true);
                _rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
                return;
            }
            // 1단 점프
            isJumping = true;
            _animator.SetBool(IsJumping, true);
            transform.position += transform.up;
            _rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && CharacterManager.Instance.Player.condition.CanUseStamina())
        {
            isDashMode = true;
            if((isJumping || isDamaged) && IsAlmostGround())
            {
                // 착지 대쉬
                CurMoveSpeed = PublicDefinitions.MaxSpeed;
                CharacterManager.Instance.Player.condition.AddStamina(20);
                StartCoroutine(SpeedEffect());
            }
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            isDashMode = false;
        }
    }

    public void OnManual (InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            UIManager.Instance.manualUI.ManualToggle();
        }
    }

    public void SuperJump()
    {
        isJumping = true;
        isDoubleJumping = true;

        _rigidbody.AddForce(Vector3.up * JumpPower * 2, ForceMode.Impulse);
    }

    private bool IsGround()
    {
        Ray ray = new Ray(transform.position + transform.up * 0.01f, Vector3.down);
        return Physics.Raycast(ray, 0.5f, groundLayerMask);
    }

    private bool IsAlmostGround()
    {
        Ray ray = new Ray(transform.position + transform.up * 0.01f, Vector3.down);
        return Physics.Raycast(ray, 5f, groundLayerMask);
    }

    IEnumerator SpeedEffect()
    {
        dashVFX.Play();

        yield return new WaitForSeconds(1f);

        dashVFX.Stop();
    }

    public void DamageModeActive()
    {
        isDamaged = true;
        CurMoveSpeed = DefaultMoveSpeed;
        _rigidbody.velocity = Vector3.zero;
    }
}
