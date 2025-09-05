using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _weaponCollider;

    private Vector2 moveInput;
    private bool _isPlayerWalking;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!_isPlayerWalking)
        {
            _isPlayerWalking = true;
            _animator.SetBool(Constants.playerWalk, _isPlayerWalking);
        }
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnAttackClick(InputAction.CallbackContext context)
    {
        _isPlayerWalking = false;
        _animator.SetBool(Constants.playerWalk, _isPlayerWalking);
        _animator.SetTrigger(Constants.attackAnim);
    }
    void Update()
    {
        Vector3 moveVector = new Vector3(moveInput.x, 0, moveInput.y);
        if (moveVector != Vector3.zero)
        {
            _characterController.transform.rotation = Quaternion.Slerp(_characterController.transform.rotation, Quaternion.LookRotation(moveVector), 0.15f);   
        }
        _characterController.Move(moveVector * _speed * Time.deltaTime);
    }

    public void EnableWeaponCollider()
    {
        _weaponCollider.enabled = true;
    }

    public void DisableWeapon()
    {
        _weaponCollider.enabled = false;
    }
}
