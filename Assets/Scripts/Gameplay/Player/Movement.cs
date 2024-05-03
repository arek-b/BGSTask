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

        [SerializeField] private Collider2D interactionTriggerDown = null;
        [SerializeField] private Collider2D interactionTriggerUp = null;
        [SerializeField] private Collider2D interactionTriggerRight = null;
        [SerializeField] private Collider2D interactionTriggerLeft = null;

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
                UpdateInteractionTriggerOrientation();
            }
        }

        private void UpdateInteractionTriggerOrientation()
        {
            interactionTriggerDown.enabled = false;
            interactionTriggerUp.enabled = false;
            interactionTriggerRight.enabled = false;
            interactionTriggerLeft.enabled = false;

            if (Mathf.Abs(normalizedDirection.x) >= Mathf.Abs(normalizedDirection.y))
            {
                if (normalizedDirection.x > 0)
                {
                    interactionTriggerRight.enabled = true;
                }
                else
                {
                    interactionTriggerLeft.enabled = true;
                }
            }
            else
            {
                if (normalizedDirection.y < 0)
                {
                    interactionTriggerDown.enabled = true;
                }
                else
                {
                    interactionTriggerUp.enabled= true;
                }
            }
        }
    }
}
