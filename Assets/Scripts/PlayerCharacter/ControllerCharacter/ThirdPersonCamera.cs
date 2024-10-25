using Common.Ticker;
using UnityEngine;

namespace PlayerCharacter.ControllerCharacter
{
    public class ThirdPersonCamera : MonoBehaviour, IUpdateable
    {
        [HideInInspector] public Vector2 RotationControl;
        
        [SerializeField] private Transform targetCameraFollowPoint;
        [SerializeField] private Transform playerModel;

        [SerializeField] private float rotationSpeedHorizontal, rotationSpeedVertical;
        [SerializeField] private float smoothingRotation;
        [SerializeField] private float minAngle ,maxAngle;

        private void Start()
        {
            Ticker.RegisterUpdateable(this);
        }
        
        private void OnDestroy()
        {
            Ticker.UnregisterUpdateable(this);
        }

        public void OnUpdate()
        {
            //Horizontal
            targetCameraFollowPoint.rotation *= Quaternion.AngleAxis(RotationControl.x * rotationSpeedHorizontal, Vector3.up);

            //Vertical
            targetCameraFollowPoint.rotation *= Quaternion.AngleAxis(-RotationControl.y * rotationSpeedVertical, Vector3.right);

            AngleCameraRotation();
        }
        
        private void AngleCameraRotation()
        {
            Vector3 angles = targetCameraFollowPoint.localEulerAngles;
            angles.z = 0;

            if (angles.x > 180 && angles.x < maxAngle)
            {
                angles.x = maxAngle;
            }
            else if (angles.x < 180 && angles.x > minAngle)
            {
                angles.x = minAngle;
            }

            targetCameraFollowPoint.localEulerAngles = angles;
            
            playerModel.rotation = Quaternion.Slerp(playerModel.rotation, Quaternion.Euler(0, targetCameraFollowPoint.eulerAngles.y, 0), Time.deltaTime * smoothingRotation);

            targetCameraFollowPoint.localEulerAngles = new Vector3(angles.x, 0, 0);
        }
    }
}
