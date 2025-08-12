using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputHandler : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    private InputAction cancelAction;
    public static event Action OnCancelPressed;

    private void OnEnable()
    {
        cancelAction = inputActions.FindAction("UI/Cancel");
        cancelAction.Enable();
        cancelAction.performed += OnCancelPerformed;
    }

    private void OnDisable()
    {
        cancelAction.performed -= OnCancelPerformed;
        cancelAction.Disable();
    }

    private void OnCancelPerformed(InputAction.CallbackContext context)
    {
        OnCancelPressed?.Invoke();
    }
}
