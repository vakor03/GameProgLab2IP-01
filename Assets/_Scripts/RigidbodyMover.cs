using System;
using UnityEngine;

namespace _Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyMover : MonoBehaviour
    {
        [SerializeField] private InputReader inputReader;
        [SerializeField] private GroundChecker groundChecker;

        [SerializeField][Min(0)] private float speed;
        [SerializeField][Min(0)] private float jumpForce;
        
        
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            inputReader.OnJump += InputReaderOnJump;
        }

        private void InputReaderOnJump()
        {
            if (groundChecker.IsGrounded())
            {
                Jump();
            }
        }

        private void Jump()
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private void Update()
        {
            Vector2 inputVectorNormalized = inputReader.GetMovementVector().normalized;

            Move(inputVectorNormalized);
        }

        private void Move(Vector2 movementVectorNormalized)
        {
            var finalSpeed = speed;
            _rigidbody.velocity = new Vector3(movementVectorNormalized.x * finalSpeed, _rigidbody.velocity.y,
                movementVectorNormalized.y * finalSpeed);
        }
    }
}