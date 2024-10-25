using System;
using Items.InteractItem;
using UnityEngine;

namespace PlayerCharacter.Triggers
{
    public class InteractTrigger : MonoBehaviour
    {
        public event Action<InteractItem> OnInteractItem;
        public event Action OnNonInteractItem;
        
        private Collider _collider;
        private InteractItem _item;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Interact")) return;
            
            InteractionItemTrigger(other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Interact"))
            {
                OnNonInteractItem?.Invoke();
                TryDisableItem();
            }
        }

        public void CleanItem()
        {
            TryDisableItem();
        }

        private void InteractionItemTrigger(Collider other)
        {
            if (other.transform.parent.TryGetComponent(out InteractItem item))
            {
                TryDisableItem();
                _item = item;
                OnInteractItem?.Invoke(_item);
                _item.Interact();
            }
        }

        private void TryDisableItem()
        {
            if (_item)
            {
                _item.DisableInteract();
                _item = null;
            }
        }
    }
}
