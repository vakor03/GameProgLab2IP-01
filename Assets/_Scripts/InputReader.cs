using System;
using UnityEngine;

namespace _Scripts
{
    public class InputReader : MonoBehaviour
    {
        public Vector2 GetMovementVector()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        
        public event Action OnJump;
        
        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                OnJump?.Invoke();
            }
        }
    }
}
