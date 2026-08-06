using UnityEngine;
using UnityEngine.InputSystem;

public class DisparadorBolas : MonoBehaviour
{
    [SerializeField] private InputActionReference dispararBola;
    [SerializeField] private Vector3 dimensionesDisparador;
    [SerializeField] private LayerMask layerBolas;
    [SerializeField] private float impulsoFuerza;

    private void OnEnable()
    {
        dispararBola.action.Enable();
        dispararBola.action.started += OnDisparar;
    }

    private void OnDisparar(InputAction.CallbackContext pulsado)
    {
        Collider[] posiblesBolas = Physics.OverlapBox(transform.position, dimensionesDisparador/2f, transform.rotation, layerBolas);
        
        for (int i = 0 ; i < posiblesBolas.Length ; i++)
        {
            Rigidbody rbBola = posiblesBolas[i].attachedRigidbody;

            if (rbBola != null)
            {
                rbBola.AddForce(transform.forward * impulsoFuerza, ForceMode.Impulse);
                Debug.Log("Bola disparada!");
            }
        }        
    }

    private void OnDisable()
    {
        dispararBola.action.started -= OnDisparar;
        dispararBola.action.Disable();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Aplicamos la posición y la rotación del objeto
        Gizmos.matrix = Matrix4x4.TRS(
            transform.position,
            transform.rotation,
            Vector3.one
        );

        // Dibujamos el cubo en el origen de esa nueva matriz
        Gizmos.DrawWireCube(
            Vector3.zero,
            dimensionesDisparador
        );

        // Restauramos la matriz para no afectar a otros Gizmos
        Gizmos.matrix = Matrix4x4.identity;
    }
}
