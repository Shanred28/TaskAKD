using System;
using Items.InteractItem.DropZone;
using PlayerCharacter.AnimationCharacter;
using PlayerCharacter.ControllerCharacter;
using PlayerCharacter.Interaction;
using PlayerCharacter.Triggers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerCharacter
{
    public class PlayerLogic : MonoBehaviour
    {
        [SerializeField] private PlayerInfoHolder playerInfo;
        [SerializeField] private Transform rightHandPoint;
        [SerializeField] private InteractTrigger interactTrigger;
        
        private CharacterInputController _characterInputController;
        private CharacterMovement _characterMovementHuman;
        private CharacterAnimationState _characterAnimationState;
        private InteractionPlayerAction _interactionPlayerAction;
        
        private PlayerInput _playerInput;

        private void Start()
        {
            _characterMovementHuman = new CharacterMovement(playerInfo);
            _characterAnimationState = new CharacterAnimationState(playerInfo,_characterMovementHuman);
            _interactionPlayerAction = new InteractionPlayerAction(playerInfo, interactTrigger);
            
            _characterInputController = new CharacterInputController(_characterMovementHuman, playerInfo.ThirdPersonCamera,_interactionPlayerAction);
            
            Initialize();
        }

        private void OnDestroy()
        {
            Exit();
        }

        private void Initialize()
        {
            _interactionPlayerAction.Enter();
            _characterMovementHuman.Enter();
            _characterInputController.Enter();
            _characterAnimationState.Enter();
        }

        public void EnterTriggerDropZone(DropZoneItemInfo dropZoneInfo)
        {
            playerInfo.IsDropZoneItem = true;
            _interactionPlayerAction.InDropZone(dropZoneInfo);
        }

        public void ExitTriggerDropZone()
        {
            playerInfo.IsDropZoneItem = false;
        }

        private void Exit()
        {
            _interactionPlayerAction.Exit();
            _characterMovementHuman.Exit();
            _characterInputController.Exit();
            _characterAnimationState.Exit();
        }
    }
}
