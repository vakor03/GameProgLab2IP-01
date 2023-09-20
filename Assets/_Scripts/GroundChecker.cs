using UnityEngine;

namespace _Scripts
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private BoxCollider boxCollider;
        
        private readonly Collider[] _collidersBuffer = new Collider[1];

        public bool IsGrounded()
        {
            int count = Physics.OverlapBoxNonAlloc(transform.position + boxCollider.center, boxCollider.size / 2,
                _collidersBuffer, Quaternion.identity, groundLayerMask);

            return count > 0;
        }
    }
}

public enum SceneName
{
    Scene1,
    Scene2,
}
