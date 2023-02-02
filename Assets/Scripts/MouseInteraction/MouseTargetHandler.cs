using KevinCastejon.MoreAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace MouseInteraction
{
    [RequireComponent(typeof(Collider2D),typeof(Rigidbody2D))]
    public class MouseTargetHandler : MonoBehaviour
    {
        public UnityEvent onMouseEnterEvent;
        public UnityEvent onMouseLeaveEvent;
        public UnityEvent onMouseDownEvent;
        public UnityEvent onMouseUpEvent;

        public void MouseLeave()
        {
            onMouseLeaveEvent.Invoke();
        }

        public void MouseEnter()
        {
            onMouseEnterEvent.Invoke();
        }

        public void MouseDown()
        {
            onMouseDownEvent.Invoke();
        }

        public void MouseUp()
        {
            onMouseUpEvent.Invoke();
        }
    }
}