using UnityEngine;
using UnityEngine.InputSystem;

public class CamaraJugadorDEMOFisicas : MonoBehaviour
{
    [SerializeField] private float sensibilidad;
    [SerializeField] private InputActionReference mirar;
    [SerializeField] private Rigidbody rbJugador;
    [SerializeField] private bool mostrarCursor;

    private float rotacionVertical;
    private float rotacionHorizontal;

    private void OnEnable()
    {
        mirar.action.Enable();
    }

    private void OnDisable()
    {
        mirar.action.Disable();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = mostrarCursor;
        rotacionHorizontal = rbJugador.rotation.eulerAngles.y;
    }

    private void Update()
    {
        Vector2 movimientoRaton = mirar.action.ReadValue<Vector2>();

        rotacionHorizontal += movimientoRaton.x * sensibilidad * Time.deltaTime;
        rotacionVertical -= movimientoRaton.y * sensibilidad * Time.deltaTime;

        rotacionVertical = Mathf.Clamp(rotacionVertical, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionVertical,0f,0f);
    }

    private void FixedUpdate()
    {
        Quaternion nuevaRotacion = Quaternion.Euler(0f, rotacionHorizontal, 0f);

        rbJugador.MoveRotation(nuevaRotacion);
    }
}
