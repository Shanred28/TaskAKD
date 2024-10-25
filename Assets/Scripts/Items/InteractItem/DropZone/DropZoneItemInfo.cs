using UnityEngine;
using UnityEngine.Serialization;

namespace Items.InteractItem.DropZone
{
    public class DropZoneItemInfo : MonoBehaviour
    {
        public Transform PointForBox => pointForBox;
        public Transform PointForSaw => pointForSaw;
        public Transform PointForEngine => pointForEngine;
        
        [FormerlySerializedAs("pointFoxBox")] [SerializeField] private Transform pointForBox;
        [FormerlySerializedAs("pointFoxSaw")] [SerializeField] private Transform pointForSaw;
        [SerializeField] private Transform pointForEngine;
    }
}
