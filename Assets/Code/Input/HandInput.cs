using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandInput : MonoBehaviour
{
    private XRIDefaultInputActions m_XRIDefaultInputActions;
    private enum Hand { left, right };
    [SerializeField] private Hand m_Hand;

    public event Action<InputAction.CallbackContext> OnGripPressed;
    public event Action<float> OnGripHeld;
    public event Action<InputAction.CallbackContext> OnGripReleased;

    public event Action<InputAction.CallbackContext> OnTriggerPressed;
    public event Action<float> OnTriggerHeld;
    public event Action<InputAction.CallbackContext> OnTriggerReleased;

    public event Action<Vector2> OnStickMoved;
    public event Action OnSecondaryButtonPressed;

    public float GripValue;
    public float TriggerValue;
    // Start is called before the first frame update
    void Start()
    {
        m_XRIDefaultInputActions = new XRIDefaultInputActions();
        m_XRIDefaultInputActions.Enable();

        if (m_Hand == Hand.left)
        {
            SubscribeLeftHand();
        }
        else
        {
            SubscribeRightHand();
        }
    }

    private void SubscribeLeftHand()
    {
        m_XRIDefaultInputActions.CustomLeftHand.Grip.performed += GripPressed;
        m_XRIDefaultInputActions.CustomLeftHand.Grip.canceled += GripReleased;
        m_XRIDefaultInputActions.CustomLeftHand.Trigger.performed += TriggerPressed;
        m_XRIDefaultInputActions.CustomLeftHand.Trigger.canceled += TriggerReleased;
    } 

    private void SubscribeRightHand()
    {
        m_XRIDefaultInputActions.CustomRightHand.Grip.performed += GripPressed;
        m_XRIDefaultInputActions.CustomRightHand.Grip.canceled += GripReleased;
        m_XRIDefaultInputActions.CustomRightHand.Trigger.performed += TriggerPressed;
        m_XRIDefaultInputActions.CustomRightHand.Trigger.canceled += TriggerReleased;
    }

    private void GripPressed(InputAction.CallbackContext context)
    {
        OnGripPressed?.Invoke(context);
    }

    private void GripReleased(InputAction.CallbackContext context)
    {
        OnGripReleased?.Invoke(context);
    }

    private void TriggerPressed(InputAction.CallbackContext context)
    {
        OnTriggerPressed?.Invoke(context);
    }

    private void TriggerReleased(InputAction.CallbackContext context)
    {
        OnTriggerReleased?.Invoke(context);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Hand == Hand.left)
        {
            HandleLeftInputs();
        }
        else
        {
            HandleRightInputs();
        }
    }
    private void HandleLeftInputs()
    {
        GripValue = m_XRIDefaultInputActions.CustomLeftHand.Grip.ReadValue<float>();
        TriggerValue = m_XRIDefaultInputActions.CustomLeftHand.Trigger.ReadValue<float>();

        if (m_XRIDefaultInputActions.CustomLeftHand.Grip.IsPressed())
        {
            OnGripHeld?.Invoke(GripValue);
        }

        if (m_XRIDefaultInputActions.CustomLeftHand.Trigger.IsPressed())
        {
            OnTriggerHeld?.Invoke(TriggerValue);
        }

        if (m_XRIDefaultInputActions.CustomLeftHand.SecondaryButton.ReadValue<float>() > 0.95)
        {
            OnSecondaryButtonPressed?.Invoke();
        }

        Vector2 moveInput = m_XRIDefaultInputActions.CustomLeftHand.StickMoved.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            OnStickMoved?.Invoke(moveInput);
        }
    }

    private void HandleRightInputs()
    {
        GripValue = m_XRIDefaultInputActions.CustomRightHand.Grip.ReadValue<float>();
        TriggerValue = m_XRIDefaultInputActions.CustomRightHand.Trigger.ReadValue<float>();

        if (m_XRIDefaultInputActions.CustomRightHand.Grip.IsPressed())
        {
            OnGripHeld?.Invoke(GripValue);
        }

        if (m_XRIDefaultInputActions.CustomRightHand.Trigger.IsPressed())
        {
            OnTriggerHeld?.Invoke(TriggerValue);
        }

        if (m_XRIDefaultInputActions.CustomRightHand.SecondaryButton.ReadValue<float>() > 0.95)
        {
            OnSecondaryButtonPressed?.Invoke();
        }

        Vector2 moveInput = m_XRIDefaultInputActions.CustomRightHand.StickMoved.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            OnStickMoved?.Invoke(moveInput);
        }
    }

    
}
