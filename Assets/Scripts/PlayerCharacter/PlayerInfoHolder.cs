using System;
using PlayerCharacter.ControllerCharacter;
using UnityEngine;

namespace PlayerCharacter
{
    public class PlayerInfoHolder : MonoBehaviour
    {
        [Serializable]
        public class CharacterAnimatorParametersName
        {
            public string NormolizeMovementX;
            public string NormolizeMovementZ;
            public string Sprint;
            public string Ground;
            public string Jump;
            public string GroundSpeed;
            public string DistanceToGround;
        }

        [Serializable]
        public class AnimationCrossFadeParameters
        {
            public string Name;
            public float Duration;
        }
        
        public CharacterController CharacterController => characterController;
        public Transform PlayerTransform => playerTransform;
        public PlayerLogic PlayerLogic => playerLogic;
        public ThirdPersonCamera ThirdPersonCamera => thirdPersonCamera;
        
        //speed movement
        public float WalkSpeed => walkSpeed;
        public float RunSpeed => runSpeed;
        public float JumpSpeed => jumpSpeed;
        public float AccelerationRate => accelerationRate;
        
        //Setting ray
        public float DistanceForRayToGround => distanceForRayToGround;
        
        //Setting for animation
        
        public Transform HandPoint => handPoint;
        
        public Animator TargetAnimator => targetAnimator;
        public CharacterAnimatorParametersName CharacterAnimatorParameters => characterAnimatorParametersName;
        public AnimationCrossFadeParameters FallFade => fallFade;
        public float MinDistanceToGroundByFall => minDistanceToGroundByFall;
        public AnimationCrossFadeParameters JumpIdleFade => jumpIdleFade;
        
        public AnimationCrossFadeParameters JumpMoveFade => jumpMoveFade;
        
        //For Item
        public bool IsDropZoneItem {get; set; }

        [SerializeField] private CharacterController characterController;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private PlayerLogic playerLogic;
        [SerializeField] private ThirdPersonCamera thirdPersonCamera;
        
        [Header("Player speed")]
        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;
        [SerializeField] private float jumpSpeed;
        [SerializeField] private float accelerationRate;
        
        [Header("Setting for ray")]
        [SerializeField] private float distanceForRayToGround;

        [Header("Setting for animation")]
        [SerializeField] private Animator targetAnimator;

        [SerializeField] private Transform handPoint;
        
        [Header("Animator Parameters Name")]
        [SerializeField] private CharacterAnimatorParametersName characterAnimatorParametersName;
        
        [Header("Animation Cross Fade Parameters")]
        [SerializeField] private AnimationCrossFadeParameters fallFade;
        [SerializeField] private float minDistanceToGroundByFall;
        [SerializeField] private AnimationCrossFadeParameters jumpIdleFade;
        [SerializeField] private AnimationCrossFadeParameters jumpMoveFade;
    }
}
