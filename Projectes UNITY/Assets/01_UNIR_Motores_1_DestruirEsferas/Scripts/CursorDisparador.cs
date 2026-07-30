using UnityEngine;
using UnityEngine.InputSystem;

public class CursorDisparador : MonoBehaviour
{
    private Camera mainCamera;
    private RaycastHit hit;

    private void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("No s'ha trobat cap càmera amb el tag MainCamera.");
        }
    }

    private void Update()
    {
        if (mainCamera == null || Mouse.current == null)
        {
            return;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = mainCamera.ScreenPointToRay(
                Mouse.current.position.ReadValue()
            );

            Debug.DrawRay(
                ray.origin,
                ray.direction * 100f,
                Color.royalBlue,
                1f
            );

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("Golpeaste a: " + hit.collider.name);

                if (hit.collider.TryGetComponent(
                    out EsferaDestruible esferaDestruible))
                {
                    esferaDestruible.NotifyHasBeenHit();
                }
            }
        }
    }
}