using System.Diagnostics;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Items.InteractItem
{
    public class OpenCloseItem : InteractItem
    {
        [SerializeField] private float durationAnimation;
        [SerializeField] private GameObject target;
        [SerializeField] private GameObject target2;
        [SerializeField] private float moveOffset;
        [SerializeField] private OpenCloseType typeDoor;
        [SerializeField] private Transform endPointRotate;
        [SerializeField] private float angleRotate;

        private bool _isClose = true;
        private float _defaultY;
        private Quaternion _closeRotation;
        private Quaternion _closeRotation2;
        private Quaternion _openRotation;
        private Quaternion _openRotation2;
        private Tweener _animationDoor;

        private void Start()
        {
            switch (typeDoor)
            {
                case OpenCloseType.Open:
                    _defaultY = target.transform.localPosition.y;
                    break;
                case OpenCloseType.Rotate:
                    _closeRotation = target.transform.localRotation;
                    _closeRotation2 = target2.transform.localRotation;
                    _openRotation = target.transform.localRotation * Quaternion.Euler(0, angleRotate, 0);
                    _openRotation2 = target2.transform.localRotation * Quaternion.Euler(0, angleRotate, 0);
                    break;
            }
        }

        public override void OpenClose()
        {
            switch (typeDoor)
            {
                case OpenCloseType.Open:
                    OpenMove();
                    break;
                case OpenCloseType.Rotate:
                    OpenRotate();
                    break;
            }
        }

        private void OpenRotate()
        {
            if(_animationDoor.IsActive()) return;

            if (_isClose)
            {
                _animationDoor = target.transform.DOLocalRotate(_openRotation.eulerAngles, durationAnimation).SetEase(Ease.Linear).OnComplete(() => _isClose = false);
                target2.transform.DOLocalRotate(_openRotation2.eulerAngles, durationAnimation).SetEase(Ease.Linear);
            }
            else
            {
                _animationDoor = target.transform.DOLocalRotate(_closeRotation.eulerAngles, durationAnimation).SetEase(Ease.Linear).OnComplete(() => _isClose = true);
                target2.transform.DOLocalRotate(_closeRotation2.eulerAngles, durationAnimation).SetEase(Ease.Linear);
            }
        }
        
        private void OpenMove()
        {
            if(_animationDoor.IsActive()) return;

            if (_isClose)
            {
                _animationDoor = target.transform.DOLocalMoveY(target.transform.localPosition.y + moveOffset, durationAnimation)
                    .SetEase(Ease.Linear).OnComplete(() => _isClose = false);
            }
            else
            {
                target.transform.DOLocalMoveY(_defaultY,durationAnimation).SetEase(Ease.Linear).OnComplete(() => _isClose = true);
            }
        }

        private enum OpenCloseType
        {
            Open,
            Rotate
        }
    }
}
