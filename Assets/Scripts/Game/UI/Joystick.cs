using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    public Vector3 Value => value;
    public bool IsActive => isActive;

    private readonly int ANGLE_OFFSET = -45;
    private Vector3 value;
    private bool isActive = false;

    [SerializeField] private Image positionFocus;

    private void Update() {
        if (isActive) {
            GetJoystickValue();
        }
    }

    public void OnDrag(PointerEventData eventData) {
        var angle = GetAngle(positionFocus.transform.position, eventData.position);
        positionFocus.transform.rotation = Quaternion.Euler(Vector3.forward * (angle + ANGLE_OFFSET));
    }

    private void GetJoystickValue() {
        var forcusAngle = (positionFocus.transform.localRotation.eulerAngles.z - 45) % 360;

        // var directionX = Mathf.Cos(forcusAngle);
        // var directionZ = Mathf.Sin(forcusAngle);
        
        // Debug.Log($"{directionX}, {directionZ}");

        // value.x = directionX;
        // value.z = directionZ;
        value.y = forcusAngle;
    }

    private float GetAngle(Vector2 start, Vector2 end) {
        Vector2 v2 = end - start;
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
    }

    public void OnPointerUp(PointerEventData eventData) {
        positionFocus.gameObject.SetActive(false);

        isActive = false;
        value = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData) {
        isActive = true;
        positionFocus.gameObject.SetActive(true);
    }
}
