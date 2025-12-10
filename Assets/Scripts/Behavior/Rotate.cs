using UnityEngine;
using UnityEngine.EventSystems;

namespace Behavior
{
    public class Rotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private Vector3 rotationAxes = new Vector3(0, 1, 0); 
        [SerializeField] private float rotationSpeed = 100f;

        private bool _isDragging;

        public void OnPointerDown(PointerEventData eventData)
        {
            _isDragging = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isDragging = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isDragging)
            {
                float deltaX = eventData.delta.x;
                float deltaY = eventData.delta.y;
            
                Vector3 rotation = new Vector3(
                    rotationAxes.x * -deltaY,
                    rotationAxes.y * deltaX,
                    rotationAxes.z * deltaX
                );

                transform.Rotate(rotation * rotationSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}