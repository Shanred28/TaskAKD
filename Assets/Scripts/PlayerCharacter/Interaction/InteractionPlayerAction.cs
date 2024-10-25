using Items;
using Items.InteractItem;
using Items.InteractItem.DropZone;
using PlayerCharacter.Triggers;
using UnityEngine;

namespace PlayerCharacter.Interaction
{
    public class InteractionPlayerAction
    {
        private readonly Transform _handPoint;
        private readonly InteractTrigger _interactionTrigger;
        private readonly PlayerInfoHolder _infoHolder;
        private InteractItem _interactItem;
        private bool _isItemHand;
        private Transform _pointDropItem;
        private DropZoneItemInfo _dropZoneInfo;


        public InteractionPlayerAction(PlayerInfoHolder infoHolder, InteractTrigger interactionTrigger)
        {
            _interactionTrigger = interactionTrigger;
            _infoHolder = infoHolder;
            _handPoint = _infoHolder.HandPoint;
        }

        public void Enter()
        {
            _interactionTrigger.OnInteractItem += OnInteractItem;
            _interactionTrigger.OnNonInteractItem += OnNonInteractItem;
        }

        public void PerformAction()
        {
            if(!_interactItem) return;
            
            var type = _interactItem.GetItemType;
            
            switch (type)
            {
                case EnumTypeItem.Pickup:
                    ItemHand();
                    break;
                case EnumTypeItem.OpenClose:
                    _interactItem.OpenClose();
                    _interactionTrigger.CleanItem();
                    _interactItem = null;
                    break;
            }
        }

        public void InDropZone(DropZoneItemInfo dropZoneInfo)
        {
            _dropZoneInfo = dropZoneInfo;
        }

        private Transform GetPointDropItem()
        {
            return _pointDropItem = _interactItem.GetNameItem switch
            {
                EnumNameItem.Box => _dropZoneInfo.PointForBox,
                EnumNameItem.Saw => _dropZoneInfo.PointForSaw,
                EnumNameItem.Engine => _dropZoneInfo.PointForEngine,
                _ => _pointDropItem
            };
        }

        private void ItemHand()
        {
            if (_isItemHand && _infoHolder.IsDropZoneItem)
            {
                _interactItem.Drop(GetPointDropItem());
                _interactionTrigger.CleanItem();
                _interactItem = null;
                _isItemHand = false;
                return;
            }
            
            if(_isItemHand) return;
            
            _interactItem.Take(_handPoint);
            _isItemHand = true;
        }

        private void OnNonInteractItem()
        {
            if(_isItemHand) return;
            _interactItem = null;
        }

        private void OnInteractItem(InteractItem obj)
        {
            if(_interactItem || _isItemHand) return;
            _interactItem = obj;
        }

        public void Exit()
        {
            _interactionTrigger.OnInteractItem -= OnInteractItem;
            _interactionTrigger.OnNonInteractItem -= OnNonInteractItem;
        }
    }
}
