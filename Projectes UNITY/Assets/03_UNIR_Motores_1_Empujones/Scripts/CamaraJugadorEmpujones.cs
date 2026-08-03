using UnityEngine;
using UnityEngine.InputSystem;

public class CamaraJugadorEmpujones : MonoBehaviour
{
    [SerializeField] private float sensibilidad = 20f;
    [SerializeField] private InputActionReference mirar;
    [SerializeField] private Rigidbody rbJugador;

    private bool puedeMirar = true;
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rotacionHorizontal = rbJugador.rotation.eulerAngles.y;
    }

    private void Update()
    {
        if (!puedeMirar)
        {
            //Debug.Log("Cámara bloqueada Update");
            return;
        }
        //Debug.Log("Cámara DESBLOQUEADA Update");

        Vector2 movimientoRaton = mirar.action.ReadValue<Vector2>();

        float mouseX = movimientoRaton.x * sensibilidad * Time.deltaTime;

        float mouseY = movimientoRaton.y * sensibilidad * Time.deltaTime;

        rotacionHorizontal += mouseX;

        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionVertical, 0f, 0f);
        
    }

    private void FixedUpdate()
    {
        if (!puedeMirar)
        {
            //Debug.Log("Cámara bloqueada FixedUpdate");
            return;
        }
        //Debug.Log("Cámara DESBLOQUEADA FixedUpdate");

        Quaternion nuevaRotacion = Quaternion.Euler(0f, rotacionHorizontal, 0f);

        rbJugador.MoveRotation(nuevaRotacion);
    }

    public void ActivarControlCamara(bool activar)
    {
        puedeMirar = activar;
    }
}