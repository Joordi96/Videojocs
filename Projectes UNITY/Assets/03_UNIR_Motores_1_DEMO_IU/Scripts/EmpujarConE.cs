using UnityEngine;
using UnityEngine.InputSystem;

public class EmpujarConE : MonoBehaviour
{
    [SerializeField] private float velocidadFuerza;
    [SerializeField] private float fuerzaEmpuje;
    [SerializeField] LayerMask layermask;
    [SerializeField] private InputActionReference empujar;

    private void OnEnable()
    {
        empujar.action.Enable();

        empujar.action.started += OnEmpujar;
    }

    private void OnDisable()
    {
        empujar.action.started -= OnEmpujar;
        empujar.action.Disable();
    }

    private void OnEmpujar(InputAction.CallbackContext ctx)
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 3f, layermask))
        {
            //Con el raycast y el out hit puedo conseguir componentes del objeto que he tocado
            Rigidbody rbObjetoApuntado = hit.collider.GetComponent<Rigidbody>();

            // Rigidbody rbObjetoApuntado = hit.rigidbody;
            if (rbObjetoApuntado != null)
            {
                // Opcion 1 para afectar al otro rigidbody
                //rbObjetoApuntado.linearVelocity = transform.forward * velocidadFuerza;

                // Con el ForceMode.Acceleration estamos aplicando una aceleracion
                //rbObjetoApuntado.AddForce(Vector3.down * fuerzaEmpuje, ForceMode.Acceleration);

                // Con el ForceMode.Impulse estamos aplicando un golpe de un frame al otro
                rbObjetoApuntado.AddForce(Vector3.up * fuerzaEmpuje, ForceMode.Impulse);

                //rbObjetoApuntado.AddForce(transform.forward * fuerzaEmpuje);
            }
        }
    }
}
