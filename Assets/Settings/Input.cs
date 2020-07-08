// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Controller"",
            ""id"": ""8601828f-a489-467c-b73f-86c70896bd07"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""e84868b1-e25d-47c3-89fd-3725e8fa57fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Upward Impulse"",
                    ""type"": ""Button"",
                    ""id"": ""fe9ab9a1-7ed1-441b-b73c-31af2ba670f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""a1cb6906-4cce-4001-899d-d9def8bad864"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpawnNewBall"",
                    ""type"": ""Button"",
                    ""id"": ""571c7c1b-05d0-4b1b-9f73-ebad7a93bcdc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f419f9e5-50b7-49cc-b0a4-e2190825ae23"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Upward Impulse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4c7386cc-d212-4b0a-9580-bedae1de76f0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d4f12b61-c1dd-4934-84cd-4eec1b1df8d2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""83909533-1ea3-4186-a1cd-44831f56db92"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b86fe926-83ff-46e0-a3c7-0b936864a906"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""80f9f5c5-b907-4ec9-9c47-d9a93acae390"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1412c00c-8d59-4d15-8cb2-6dc2e6d71a6f"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c26e516-f3d4-480e-a048-f6d60f3659aa"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpawnNewBall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Controller
        m_Controller = asset.FindActionMap("Controller", throwIfNotFound: true);
        m_Controller_Move = m_Controller.FindAction("Move", throwIfNotFound: true);
        m_Controller_UpwardImpulse = m_Controller.FindAction("Upward Impulse", throwIfNotFound: true);
        m_Controller_Sprint = m_Controller.FindAction("Sprint", throwIfNotFound: true);
        m_Controller_SpawnNewBall = m_Controller.FindAction("SpawnNewBall", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Controller
    private readonly InputActionMap m_Controller;
    private IControllerActions m_ControllerActionsCallbackInterface;
    private readonly InputAction m_Controller_Move;
    private readonly InputAction m_Controller_UpwardImpulse;
    private readonly InputAction m_Controller_Sprint;
    private readonly InputAction m_Controller_SpawnNewBall;
    public struct ControllerActions
    {
        private @Input m_Wrapper;
        public ControllerActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Controller_Move;
        public InputAction @UpwardImpulse => m_Wrapper.m_Controller_UpwardImpulse;
        public InputAction @Sprint => m_Wrapper.m_Controller_Sprint;
        public InputAction @SpawnNewBall => m_Wrapper.m_Controller_SpawnNewBall;
        public InputActionMap Get() { return m_Wrapper.m_Controller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerActions set) { return set.Get(); }
        public void SetCallbacks(IControllerActions instance)
        {
            if (m_Wrapper.m_ControllerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnMove;
                @UpwardImpulse.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnUpwardImpulse;
                @UpwardImpulse.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnUpwardImpulse;
                @UpwardImpulse.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnUpwardImpulse;
                @Sprint.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSprint;
                @SpawnNewBall.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSpawnNewBall;
                @SpawnNewBall.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSpawnNewBall;
                @SpawnNewBall.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSpawnNewBall;
            }
            m_Wrapper.m_ControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @UpwardImpulse.started += instance.OnUpwardImpulse;
                @UpwardImpulse.performed += instance.OnUpwardImpulse;
                @UpwardImpulse.canceled += instance.OnUpwardImpulse;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @SpawnNewBall.started += instance.OnSpawnNewBall;
                @SpawnNewBall.performed += instance.OnSpawnNewBall;
                @SpawnNewBall.canceled += instance.OnSpawnNewBall;
            }
        }
    }
    public ControllerActions @Controller => new ControllerActions(this);
    public interface IControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnUpwardImpulse(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnSpawnNewBall(InputAction.CallbackContext context);
    }
}
