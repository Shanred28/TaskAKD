using Items.InteractItem.Interface;
using Outline;
using UnityEngine;

namespace Items.InteractItem
{
    public abstract class InteractItem : MonoBehaviour, IInteractItem
    {
        public EnumTypeItem GetItemType => typeItem;
        public EnumNameItem GetNameItem => itemName;

        [SerializeField] private EnumNameItem itemName;
        [SerializeField] private EnumTypeItem typeItem;
        [SerializeField] private OutlineObject outlineObject;
        
        public void Interact()
        {
            outlineObject.EnableOutline();
        }

        public void DisableInteract()
        {
            outlineObject.DisableOutline();
        }

        public void Take(Transform point)
        {
            outlineObject.DisableOutline();
            SetPointItem(point);
        }

        public void Drop(Transform point)
        {
            SetPointItem(point);
        }

        public virtual void OpenClose()
        {
            outlineObject.DisableOutline();
        }

        private void SetPointItem(Transform point)
        {
            transform.parent = point;
            transform.position = point.position;
        }
    }
}
