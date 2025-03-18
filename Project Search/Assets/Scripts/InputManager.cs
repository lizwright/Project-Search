using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputActions Actions => _inputActions;
    private static InputActions _inputActions;
    private static Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _inputActions = new InputActions();
        _inputActions.Game.Enable();
    }

    public static Vector2 GetMouseWorldPosition()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = _camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, _camera.nearClipPlane));
        return worldPosition;
    }

    public static void EnableGameInput()
    {
        _inputActions.Game.Enable();
    }
    
    public static void DisableGameInput()
    {
        _inputActions.Game.Disable();
    }
}
