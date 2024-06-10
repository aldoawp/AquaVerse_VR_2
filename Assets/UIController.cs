using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class UIController : MonoBehaviour
{
    public GameObject uiPanel;

    private XRDeviceSimulator xrDeviceSimulator;
    private InputAction primaryButtonAction;

    void Start()
    {
        xrDeviceSimulator = FindObjectOfType<XRDeviceSimulator>();
        if (xrDeviceSimulator == null)
        {
            Debug.LogError("XRDeviceSimulator not found in the scene.");
            return;
        }

        // Assign the primary button action
        primaryButtonAction = xrDeviceSimulator.primaryButtonAction;
    }

    void OnEnable()
    {
        if (primaryButtonAction != null)
        {
            primaryButtonAction.performed += OnPrimaryButtonPressed;
        }
    }

    void OnDisable()
    {
        if (primaryButtonAction != null)
        {
            primaryButtonAction.performed -= OnPrimaryButtonPressed;
        }
    }

    private void OnPrimaryButtonPressed(InputAction.CallbackContext context)
    {
        CloseUI();
    }

    public void CloseUI()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
    }
}
