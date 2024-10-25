using PlayerCharacter;
using UnityEngine;

namespace Items.InteractItem.DropZone
{
    public class DropZoneItem : MonoBehaviour
    {
        [SerializeField] private DropZoneItemInfo dropZoneItemInfo;
        [SerializeField] private DropZoneItemTrigger dropZoneItemTrigger;

        private PlayerLogic _playerLogic;

        private void Start()
        {
            dropZoneItemTrigger.OnEnterPlayerDropZone += OnEnterPlayer;
            dropZoneItemTrigger.OnExitPlayerDropZone += OnExitPlayer;
        }

        private void OnDestroy()
        {
            dropZoneItemTrigger.OnEnterPlayerDropZone -= OnEnterPlayer;
            dropZoneItemTrigger.OnExitPlayerDropZone -= OnExitPlayer;
        }

        private void OnEnterPlayer(PlayerLogic obj)
        {
            _playerLogic = obj;
            _playerLogic.EnterTriggerDropZone(dropZoneItemInfo);
        }

        private void OnExitPlayer()
        {
            _playerLogic.ExitTriggerDropZone();
        }
    }
}
