using UnityEngine;
using UnityEngine.InputSystem;

public class EmpujarConEspacio : MonoBehaviour
{
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private float radioEmpuje;

    [SerializeField] private InputActionReference empujarEspacio;

    private void OnEnable() {
        empujarEspacio.action.Enable();
        empujarEspacio.action.started += OnEmpujar;
    }

    private void OnEmpujar(InputAction.CallbackContext pulsacion)
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, radioEmpuje))
        {
            Rigidbody RBObjetoApuntado = hit.rigidbody;

            if(RBObjetoApuntado != null)
            {
                Debug.Log("Fuerza aplicada");
                RBObjetoApuntado.AddForce(Vector3.up * fuerzaImpulso, ForceMode.Impulse);
            }
        }
    }

    private void OnDisable()
    {
        empujarEspacio.action.Disable();
        empujarEspacio.action.started -= OnEmpujar;
    }
}
