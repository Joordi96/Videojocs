using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorMovimientoJugador : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private float multiplicadorCaida = 2f;

    [Header("Comprobación del suelo")]
    [SerializeField] private Transform comprobadorSuelo;
    [SerializeField] private float radioComprobacion = 0.2f;
    [SerializeField] private LayerMask capaSuelo; 

    [Header("Input Actions")]
    [SerializeField] private InputActionReference movimiento;
    [SerializeField] private InputActionReference salto;
    [SerializeField] private InputActionReference disparo;

    [SerializeField] Transform puntoRespawn;


    private Rigidbody rb;
    private RigidbodyConstraints restriccionesOriginales;

    private Vector2 rawMove = Vector2.zero;

    private bool quiereSaltar = false;
    private bool estaDisparando = false;
    private bool estaEnElSuelo = false;
    private bool puedeMoverse = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        restriccionesOriginales = rb.constraints;
    }

    private void OnEnable()
    {
        movimiento.action.Enable();
        salto.action.Enable();
        disparo.action.Enable();

        movimiento.action.started += OnMove;
        movimiento.action.performed += OnMove;
        movimiento.action.canceled += OnMove;

        salto.action.started += OnJump;

        disparo.action.started += OnShoot;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        comprobarSuelo();
        if (!puedeMoverse)
            return;
        moverJugador();
        saltarJugador();

        // Acelerado la caída del jugador para que se sienta más natural
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (multiplicadorCaida - 1) * Time.fixedDeltaTime;
        }
    }

    private void saltarJugador()
    {
        if (!puedeMoverse)
        {
            quiereSaltar = false;
            return;
        }

        if (quiereSaltar && estaEnElSuelo)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                fuerzaSalto,
                rb.linearVelocity.z
            );

            //Debug.Log("El jugador está saltando");
        }

        quiereSaltar = false;
    }

    private void moverJugador()
    {
        if (!puedeMoverse)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            return;
        }

        if (!estaEnElSuelo)
        {
            return;
        }

        Vector3 direccionMovimiento = transform.right * rawMove.x + transform.forward * rawMove.y;

        direccionMovimiento = direccionMovimiento.normalized;

        rb.linearVelocity = new Vector3(direccionMovimiento.x * velocidad, rb.linearVelocity.y, direccionMovimiento.z * velocidad);
    }

    private void OnDisable()
    {
        movimiento.action.started -= OnMove;
        movimiento.action.performed -= OnMove;
        movimiento.action.canceled -= OnMove;

        salto.action.started -= OnJump;

        disparo.action.started -= OnShoot;

        movimiento.action.Disable();
        salto.action.Disable();
        disparo.action.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.ReadValue<Vector2>();
        //Debug.Log($"Movimiento: {rawMove}");
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        quiereSaltar = true;
        Debug.Log("Salto");
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        estaDisparando = context.ReadValueAsButton();
        Debug.Log("Disparo");
    }

    private void comprobarSuelo()
    {
        estaEnElSuelo = Physics.CheckSphere(comprobadorSuelo.position, radioComprobacion, capaSuelo);
    }

    private void OnDrawGizmosSelected()
    {
        if (comprobadorSuelo == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(comprobadorSuelo.position, radioComprobacion);
    }

    public void ActivarControl(bool activar)
    {
        puedeMoverse = activar;
        if (!activar)
        {
            quiereSaltar = false;
            rawMove = Vector2.zero;

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rb.constraints = restriccionesOriginales;
        }
    }

    public void Respawn()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = puntoRespawn.position;
        transform.rotation = puntoRespawn.rotation;
    }

}
