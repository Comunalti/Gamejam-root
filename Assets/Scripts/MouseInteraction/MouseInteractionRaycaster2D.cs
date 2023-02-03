using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace MouseInteraction
{
    /// <summary>
    /// every game object with a MouseTargetHandler that is in this layer is going to get called on mouse interect
    /// </summary>
    public class MouseInteractionRaycaster2D : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private List<MouseTargetHandler> lastFrameMouseTargetHandlers;
        [SerializeField] private List<MouseTargetHandler> currentFrameMouseTargetHandlers;
        [SerializeField] private List<MouseTargetHandler> recordedMouseTargetHandlers;

        private new Camera camera;

        private void Start()
        {
            camera = Camera.main;
        }

        void Update()
        {
            Vector3 mousePos = Input.mousePosition;

            Vector2 worldPoint = camera.ScreenToWorldPoint(mousePos);

            var raycastHits = Physics2D.RaycastAll(worldPoint, Vector2.zero, 0.0f, layerMask);


            // var hitTransform = raycastHits.transform;
            //
            // if (hitTransform == null)
            // {
            //     currentFrameInteractable = null;
            // }
            // else
            // {
            //     currentFrameInteractable = hitTransform.GetComponent<MouseTargetHandler>();
            // }

            currentFrameMouseTargetHandlers.Clear();

            foreach (var hit in raycastHits)
            {
                var mouseTargetHandler = hit.transform.GetComponent<MouseTargetHandler>();
                currentFrameMouseTargetHandlers.Add(mouseTargetHandler);
            }

            foreach (var lastFrameMouseTargetHandler in lastFrameMouseTargetHandlers)
            {
                if (!currentFrameMouseTargetHandlers.Contains(lastFrameMouseTargetHandler))
                {
                    lastFrameMouseTargetHandler.MouseLeave();
                }
            }

            foreach (var currentFrameMouseTargetHandler in currentFrameMouseTargetHandlers)
            {
                if (!lastFrameMouseTargetHandlers.Contains(currentFrameMouseTargetHandler))
                {
                    currentFrameMouseTargetHandler.MouseEnter();
                }
            }


            // if (lastFrameInteractable != currentFrameInteractable)
            // {
            //     if (lastFrameInteractable != null)
            //     {
            //         lastFrameInteractable.MouseLeave();
            //     }
            //
            //     if (currentFrameInteractable != null)
            //     {
            //         currentFrameInteractable.MouseEnter();
            //     }
            // }



            if (Input.GetMouseButtonDown((int) MouseButton.LeftMouse))
            {
                foreach (var currentFrameMouseTargetHandler in currentFrameMouseTargetHandlers)
                {
                    recordedMouseTargetHandlers.Add(currentFrameMouseTargetHandler);
                    currentFrameMouseTargetHandler.MouseDown();
                }
            }

            if (Input.GetMouseButtonUp((int) MouseButton.LeftMouse))
            {
                foreach (var recordedMouseTargetHandler in recordedMouseTargetHandlers)
                {
                    recordedMouseTargetHandler.MouseUp();
                }

                recordedMouseTargetHandlers.Clear();
            }

            //

            // if (Input.GetMouseButtonDown((int) MouseButton.LeftMouse))
            // {
            //     if (currentFrameInteractable != null)
            //     {
            //         recordedInteractable = currentFrameInteractable;
            //         currentFrameInteractable.MouseDown();
            //     }
            // }
            // if (Input.GetMouseButtonUp((int) MouseButton.LeftMouse))
            // {
            //     if (recordedInteractable != null)
            //     {
            //         recordedInteractable.MouseUp();
            //         recordedInteractable = null;
            //     }
            // }

            lastFrameMouseTargetHandlers.Clear();
            currentFrameMouseTargetHandlers.CopyValuesTo(lastFrameMouseTargetHandlers);


            // lastFrameInteractable = currentFrameInteractable;
        }
    }
}