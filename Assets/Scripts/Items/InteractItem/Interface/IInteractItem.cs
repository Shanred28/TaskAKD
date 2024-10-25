using UnityEngine;

namespace Items.InteractItem.Interface
{
    public interface IInteractItem
    {
        public void Interact();

        public void DisableInteract();

        public void Take(Transform point);
        
        public void Drop(Transform point);
        
    }
}