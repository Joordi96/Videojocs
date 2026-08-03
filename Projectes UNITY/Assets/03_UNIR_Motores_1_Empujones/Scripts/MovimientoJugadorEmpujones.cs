using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugadorEmpujones : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 10f;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference movimiento;

    private Rigidbody rbJugador;

    private Vector2 resultadoInputAction = Vector2.zero;

    private bool puedeMoverse = true;

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
        //Debug.Log($"OnEnable");

    }

    private void FixedUpdate()
    {
        if (puedeMoverse)
        {
            //Debug.Log($"Llamando MoverJugador");

            MoverJugador();
        }
    }

    private void MoverJugador()
    {
        //Debug.Log($"Ejecutando MoverJugador");
        //Debug.Log($"Input actual: {resultadoInputAction}");
        //Debug.Log($"Velocidad configurada: {velocidad}");
        //Debug.Log($"Forward: {transform.forward}");
        //Debug.Log($"Right: {transform.right}");

        Vector3 direccionMovimiento = transform.right * resultadoInputAction.x + transform.forward * resultadoInputAction.y;

        direccionMovimiento = direccionMovimiento.normalized;

        Vector3 nuevaVelocidad = new Vector3(direccionMovimiento.x * velocidad, rbJugador.linearVelocity.y, direccionMovimiento.z * velocidad);


        //Debug.Log($"Velocidad configurada: {velocidad}");
        //Debug.Log($"Nueva velocidad: {nuevaVelocidad}");

        rbJugador.linearVelocity = nuevaVelocidad;
    }

    private void OnDisable()
    {
        movimiento.action.started -= OnMove;
        movimiento.action.performed -= OnMove;
        movimiento.action.canceled -= OnMove;

        movimiento.action.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        resultadoInputAction = context.ReadValue<Vector2>();

        //Debug.Log($"OnMove ejecutado: {context.phase}");
        //Debug.Log($"Movimiento recibido: {resultadoInputAction}");
    }

}
