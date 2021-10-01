using UnityEngine;
using UnityEngine.InputSystem;


[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{

    #region Events
    public delegate void startTouch(Ray position, float time);
    public event startTouch onStartTouch;
    public delegate void endTouch(Ray position, float time);
    public event endTouch onEndTouch;
    #endregion

    public Camera mainCamera;

    private Controls controls;


    private void Awake()
    {
        controls = new Controls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Touch.Tap.started += ctx => Tap(ctx);
    }
    
    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        Ray r = Utils.ScreenToWorld(mainCamera, controls.Touch.PrimaryPosition.ReadValue<Vector2>());
        Debug.DrawRay(r.origin, r.direction);
        Debug.Log("Tap");
        if (onStartTouch != null) onStartTouch(Utils.ScreenToWorld(mainCamera, controls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
        
    }


    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (onEndTouch != null) onStartTouch(Utils.ScreenToWorld(mainCamera, controls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }

    private void Tap(InputAction.CallbackContext context)
    {
        
        if (onStartTouch != null) onStartTouch(Utils.ScreenToWorld(mainCamera, controls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }
}