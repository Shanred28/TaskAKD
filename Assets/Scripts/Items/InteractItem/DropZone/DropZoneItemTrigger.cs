using System;
using PlayerCharacter;
using UnityEngine;

namespace Items.InteractItem.DropZone
{
    public class DropZoneItemTrigger : MonoBehaviour
    {
        public event Action<PlayerLogic> OnEnterPlayerDropZone;
        public event Action OnExitPlayerDropZone;
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                OnEnterPlayerDropZone?.Invoke(other.GetComponent<PlayerLogic>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                OnExitPlayerDropZone?.Invoke();
            }
        }
    }
}
