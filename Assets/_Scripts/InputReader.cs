using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class InputReader : MonoBehaviour, IDisposable
    {
        private PlayerInputActions _playerInputActions;

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
            _playerInputActions.Player.Jump.performed += PlayerOnJump;
        }

        private void PlayerOnJump(InputAction.CallbackContext obj)
        {
            OnJump?.Invoke();
        }

        public Vector2 GetMovementVectorNormalized()
        {
            return _playerInputActions.Player.Movement.ReadValue<Vector2>().normalized;
        }

        public event Action OnJump;

        public void Dispose()
        {
            _playerInputActions.Player.Jump.performed -= PlayerOnJump;
            _playerInputActions?.Dispose();
        }
    }
}