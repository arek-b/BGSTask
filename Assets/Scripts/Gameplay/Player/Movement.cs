using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Gameplay.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private Vector2 normalizedDirection = Vector2.zero;

        [SerializeField] private Animator animator;
        private readonly int horizontalDirectionHash = Animator.StringToHash("HorizontalDirection");
        private readonly int verticalDirectionHash = Animator.StringToHash("VerticalDirection");
        private readonly int movementSpeedHash = Animator.StringToHash("MovementSpeed");

        [SerializeField] private Rigidbody2D myRigidbody = null;

        private void FixedUpdate()
        {
            myRigidbody.MovePosition(myRigidbody.position + speed * Time.fixedDeltaTime * normalizedDirection);
        }

        public void OnMove(CallbackContext callbackContext)
        {
            normalizedDirection = callbackContext.ReadValue<Vector2>().normalized;
            float movementSpeed = normalizedDirection.sqrMagnitude;
            animator.SetFloat(movementSpeedHash, movementSpeed);
            if (movementSpeed > 0)
            {
                animator.SetFloat(horizontalDirectionHash, normalizedDirection.x);
                animator.SetFloat(verticalDirectionHash, normalizedDirection.y);
            }
        }
    }
}
