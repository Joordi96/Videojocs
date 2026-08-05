using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugadorDEMOFisicas : MonoBehaviour
{
    [SerializeField] private InputActionReference movimiento;
    [SerializeField] private float velocidad;

    Vector2 resultadoInputAction = Vector2.zero;

    Rigidbody rbJugador;

    private void Awake()
    {
        rbJugador = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        movimiento.action.Enable();
        movimiento.action.started += OnMove;
        movimiento.action.performed += OnMove;
        movimiento.action.canceled += OnMove;
    }

    void FixedUpdate()
    {
        MoverJugador();
    }

    private void MoverJugador()
    {
        Vector3 direccionMovimiento = transform.right * resultadoInputAction.x + transform.forward * resultadoInputAction.y;
        direccionMovimiento = direccionMovimiento.normalized;

        Vector3 nuevaVelocidad = new Vector3(direccionMovimiento.x * velocidad ,rbJugador.linearVelocity.y ,direccionMovimiento.z * velocidad );

        rbJugador.linearVelocity = nuevaVelocidad;
    }

    private void OnMove(InputAction.CallbackContext moveInputAction)
    {
        resultadoInputAction = moveInputAction.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        movimiento.action.Disable();
        movimiento.action.started -= OnMove;
        movimiento.action.performed -= OnMove;
        movimiento.action.canceled -= OnMove;
    }
}
