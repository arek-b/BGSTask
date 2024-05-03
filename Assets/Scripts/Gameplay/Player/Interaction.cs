using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Gameplay.Player
{
    public class Interaction : MonoBehaviour
    {
        private readonly HashSet<GameObject> gameObjectsInTrigger = new();

        public void OnInteract(CallbackContext callbackContext)
        {
            if (callbackContext.performed == false)
            {
                return;
            }

            foreach (GameObject go in gameObjectsInTrigger)
            {
                if (go.TryGetComponent(out IInteractable interactable))
                { 
                    interactable.Interact();
                    return;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            gameObjectsInTrigger.Add(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            gameObjectsInTrigger.Remove(collision.gameObject);
        }
    }
}