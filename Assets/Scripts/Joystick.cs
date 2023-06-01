using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform joystickBackground;
    [SerializeField] private RectTransform joystickHandle;
    private Vector3 inputDirection;

    public delegate void JoystickInputDelegate(Vector3 inputDirection);
    public event JoystickInputDelegate OnJoystickInputChanged;

    public delegate void JoystickUpDelegate();
    public event JoystickUpDelegate OnJoystickUpDelegate;

    public void OnDrag(PointerEventData eventData)
    {
        StartMove(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopMove();
    }

    public void StartMove(PointerEventData eventData)
    {
        Vector2 position = RectTransformUtility.WorldToScreenPoint(null, joystickBackground.position);
        inputDirection = (eventData.position - position).normalized;

        float radius = joystickBackground.sizeDelta.x * 0.5f;
        joystickHandle.anchoredPosition = inputDirection * radius;

        OnJoystickInputChanged?.Invoke(inputDirection);
    }

    public void StopMove()
    {
        inputDirection = Vector3.zero;
        joystickHandle.anchoredPosition = Vector3.zero;
        OnJoystickUpDelegate?.Invoke();
    }
}