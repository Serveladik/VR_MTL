// Non-SteamVR VR input/hand controls
//
// Copyright (C) 2019-2021 NextWave Safety Solutions, Inc.
// All Rights Reserved.

/*
https://github.com/NextWaveSafetySolutions/SubCore/blob/e1c8332b33fddb312609df0dba2e87b34b009960/SteamVR/InteractionSystem/Core/Scripts/Hand.cs
*/

#region Defines

//#define VERBOSE_CONTROLLERS
//#define VERBOSE_MODELS
//#define VERBOSE_STATE
//#define VERBOSE_INTERNAL_STATE
//#define VERBOSE_INPUT

//#define SHOW_DEBUG_INFO

//#define VALIDATE_POSES

// Fake custom inspector ;)
#define HIDE_CONTROLLER_INPUT

//#define VERBOSE_UNITY

#if (VERBOSE_CONTROLLERS && VERBOSE_INPUT)
#define VERBOSE_CONTROLLERS_INPUT
#endif  // (VERBOSE_CONTROLLERS && VERBOSE_INPUT)

#if (VERBOSE_CONTROLLERS && VERBOSE_UNITY)
#define VERBOSE_CONTROLLERS_UNITY
#endif  // (VERBOSE_CONTROLLERS && VERBOSE_UNITY)

#endregion Defines

#if SHOW_DEBUG_INFO
using TMPro;
#endif  // SHOW_DEBUG_INFO

using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Hand : MonoBehaviour
{
    [Header("Setup variables")]
    private bool _isAssigned;


    private Transform _transform;

#if SHOW_DEBUG_INFO
    private TextMeshPro _debugText;
#endif  // SHOW_DEBUG_INFO

#region Unity

    /// <summary>
    ///
    /// </summary>
    protected void Awake()
    {

        InitializeComponents();

        _isAssigned = false;


    #if SHOW_DEBUG_INFO

        _debugText = GetComponentInChildren<TextMeshPro>(true);
        _debugText.gameObject.SetActive(false);

    #endif  // SHOW_DEBUG_INFO

    }

    /// <summary>
    ///
    /// </summary>
    protected void OnEnable()
    {

    #if VERBOSE_CONTROLLERS_UNITY
        LogFile.Log(this.GetCaller(gameObject.name));
    #endif  // VERBOSE_CONTROLLERS_UNITY

        Application.onBeforeRender += OnBeforeRender;
    }

    /// <summary>
    ///
    /// </summary>
    protected void OnDisable()
    {

    #if VERBOSE_CONTROLLERS_UNITY
        LogFile.Log(this.GetCaller(gameObject.name));
    #endif  // VERBOSE_CONTROLLERS_UNITY

        Application.onBeforeRender -= OnBeforeRender;
    }

#endregion Unity

#region Initialization

    /// <summary>
    /// Initialize hand components
    /// </summary>
    private void InitializeComponents()
    {
        _transform = transform;


        //LogFile.Log($"{this.GetCaller(gameObject.name)} UserPointer: {UserPointer?.name}");

    }

    /// <summary>
    /// Assign controller model to device
    /// </summary>
    /// <param name="device">Input device</param>
    public void AssignController(InputDevice device)
    {
        if (_isAssigned)
        {
            return;
        }

        _isAssigned = true;
        _inputDevice = device;

    }




#endregion Initialization

#region XR Interaction Toolkit

    [SerializeField] private XRNode _xrNode;                   // Select hand controllers
    private InputDevice _inputDevice;
    private List<InputDevice> _xrInputDevices = new List<InputDevice>();
    private XRBaseInteractor _interactor;

    /// <summary>
    /// Checks valid XR devices
    /// </summary>
    private void CheckValidXRDevice()
    {
        if (!_inputDevice.isValid)
        {
            _inputDevice = GetXRDevice();
        }
    }

    /// <summary>
    /// Find connected devices
    /// </summary>
    private InputDevice GetXRDevice()
    {
        InputDevices.GetDevicesAtXRNode(_xrNode, _xrInputDevices);

        return _xrInputDevices.FirstOrDefault();
    }

    /// <summary>
    /// Sets XR interactor state
    /// </summary>
    /// <param name="interactorState">TRUE: Enable interactor (if valid)</param>
    public void SetXRInteractorState(bool interactorState)
    {
        _interactor = GetComponent<XRBaseInteractor>();
        if (_interactor == null)
        {
            return;
        }

        _interactor.enabled = interactorState;
    }

#endregion XR Interaction Toolkit

#region Update

    // Trigger
    public float TriggerThreshold = 0.5f;                       // Not used - see previous functionality

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public float Trigger;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool TriggerButton;

    private bool _lastTriggerButton;
#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool TriggerButtonUp;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool TriggerButtonDown;

    // Menu button
#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool MenuButton;
    private bool _lastMenuButton;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool MenuButtonUp;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool MenuButtonDown;

    // Primary button (Vive: ???, Quest: A/X)
#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool PrimaryButton;
    private bool _lastPrimaryButton;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool PrimaryButtonUp;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool PrimaryButtonDown;

    // Secondary button (Vive: sandwich button (above trackpad), Quest: B/Y)
#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool SecondaryButton;
    private bool _lastSecondaryButton;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool SecondaryButtonUp;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool SecondaryButtonDown;

    // Grip button (Vive: ??? (above trackpad), Quest: Grip)
    public float GripThreshold = 0.5f;                          // Not used - see previous trigger functionality

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public float Grip;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool GripButton;
    private bool _lastGripButton;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool GripButtonUp;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool GripButtonDown;

    // Touchpad/trackpad
#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool TouchpadTouch;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public Vector2 Touchpad;

    public class Vectorized
    {
        public Vector2Int Current;
        public Vector2Int Last;
        public Vector2Int Up;
        public Vector2Int Down;
    }

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public Vectorized TouchpadVectors = new Vectorized();

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public Vectorized TouchpadClickDownVectors = new Vectorized();

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool TouchpadButton;
    private bool _lastTouchpadButton;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool TouchpadButtonUp;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public bool TouchpadButtonDown;

#if HIDE_CONTROLLER_INPUT
    [HideInInspector]
#endif  // HIDE_CONTROLLER_INPUT
    public Vector3 Velocity;

    /// <summary>
    ///
    /// </summary>
    protected void OnBeforeRender()
    {

        if (_inputDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position))
        {
            _transform.localPosition = position;
        }

        if (_inputDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation))
        {
            _transform.localRotation = rotation;
        }

        _inputDevice.TryGetFeatureValue(CommonUsages.trigger, out Trigger);

        _inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out TriggerButton);
        TriggerButtonUp = ((TriggerButton != _lastTriggerButton) && !TriggerButton);
        TriggerButtonDown = ((TriggerButton != _lastTriggerButton) && TriggerButton);
        _lastTriggerButton = TriggerButton;

        if (_inputDevice.TryGetFeatureValue(CommonUsages.menuButton, out MenuButton))
        {
            MenuButtonUp = ((MenuButton != _lastMenuButton) && !MenuButton);
            MenuButtonDown = ((MenuButton != _lastMenuButton) && MenuButton);
            _lastMenuButton = MenuButton;
        }

        _inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out PrimaryButton);
        PrimaryButtonUp = ((PrimaryButton != _lastPrimaryButton) && !PrimaryButton);
        PrimaryButtonDown = ((PrimaryButton != _lastPrimaryButton) && PrimaryButton);
        _lastPrimaryButton = PrimaryButton;

        _inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out SecondaryButton);
        SecondaryButtonUp = ((SecondaryButton != _lastSecondaryButton) && !SecondaryButton);
        SecondaryButtonDown = ((SecondaryButton != _lastSecondaryButton) && SecondaryButton);
        _lastSecondaryButton = SecondaryButton;

        _inputDevice.TryGetFeatureValue(CommonUsages.grip, out Grip);

        _inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out GripButton);
        GripButtonUp = ((GripButton != _lastGripButton) && !GripButton);
        GripButtonDown = ((GripButton != _lastGripButton) && GripButton);
        _lastGripButton = GripButton;

        _inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out TouchpadButton);
        TouchpadButtonUp = ((TouchpadButton != _lastTouchpadButton) && !TouchpadButton);
        TouchpadButtonDown = ((TouchpadButton != _lastTouchpadButton) && TouchpadButton);
        _lastTouchpadButton = TouchpadButton;

        _inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out TouchpadTouch);
        _inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Touchpad);

        _inputDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out Velocity);
    }

 

    /// <summary>
    ///
    /// </summary>
    protected void Update()
    {
        CheckValidXRDevice();                                   // Get the devices at the XR node (check status)
    }

#endregion Update


    private GameObject _currentModelContainer;
    private bool _warnFirstTime = true;

    private const float CONTROLLER_DEAD_ZONE    = 0.01f;

    /// <summary>
    /// Get current hand model/pose
    /// </summary>
    /// <returns>Model/pose</returns>

  }
