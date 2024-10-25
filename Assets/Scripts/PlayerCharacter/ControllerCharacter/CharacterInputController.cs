using Common.Ticker;
using PlayerCharacter.Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerCharacter.ControllerCharacter
{
    public class CharacterInputController : IUpdateable
    {
        private PlayerInputController _inputKeyBoard;
        private readonly CharacterMovement _characterMovement;
        private readonly ThirdPersonCamera _thirdPersonCamera;
        private readonly InteractionPlayerAction _interactionPlayerAction;
        
        public CharacterInputController(CharacterMovement characterMovement, ThirdPersonCamera thirdPersonCamera, InteractionPlayerAction interactionPlayerAction)
        {
            _interactionPlayerAction = interactionPlayerAction;
            _characterMovement = characterMovement;
            _thirdPersonCamera = thirdPersonCamera;
        }

        public void Enter()
        {
            _inputKeyBoard = new PlayerInputController();
            _inputKeyBoard.Player.Enable();
            _inputKeyBoard.Player.Jump.started += OnJump;
            _inputKeyBoard.Player.Sprint.started += OnSprint;
            _inputKeyBoard.Player.Acion.started += OnAction;
            
            Ticker.RegisterUpdateable(this);
        }
        
        public void OnUpdate()
        {
            _characterMovement.TargetDirectionControl = new Vector3(_inputKeyBoard.Player.Move.ReadValue<Vector2>().x, 0,  _inputKeyBoard.Player.Move.ReadValue<Vector2>().y);
            _thirdPersonCamera.RotationControl = new Vector2(_inputKeyBoard.Player.Look.ReadValue<Vector2>().x, _inputKeyBoard.Player.Look.ReadValue<Vector2>().y);
        }

        private void OnSprint(InputAction.CallbackContext obj)
        {
            _characterMovement.Sprint();
        }

        private void OnJump(InputAction.CallbackContext obj)
        {
            _characterMovement.Jump();
        }
        
        private void OnAction(InputAction.CallbackContext obj)
        {
            _interactionPlayerAction.PerformAction();
        }

        public void Exit()
        {
            Ticker.UnregisterUpdateable(this);
            _inputKeyBoard.Player.Sprint.started -= OnSprint;
            _inputKeyBoard.Player.Jump.started -= OnJump;
            _inputKeyBoard.Player.Acion.started -= OnAction;
        }
    }
}
