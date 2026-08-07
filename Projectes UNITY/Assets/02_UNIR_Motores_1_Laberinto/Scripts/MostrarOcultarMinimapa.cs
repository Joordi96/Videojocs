using UnityEngine;
using UnityEngine.InputSystem;

public class MostrarOcultarMinimapa : MonoBehaviour
{
    [SerializeField] private InputActionReference boton;
    private Camera minimapa;

    private bool mapaVisible = false;
    private void Awake()
    {
        minimapa = GetComponent<Camera>();
        minimapa.enabled = false;
    }

    private void OnEnable()
    {
        boton.action.Enable();
        boton.action.started += OnPulsar;
    }

    private void OnPulsar(InputAction.CallbackContext pulsacion)
    {
        if (!mapaVisible)
        {            
            minimapa.enabled = true;
            mapaVisible = true;
        }
        else
        {
            minimapa.enabled = false;
            mapaVisible = false;
        }
    }

    private void OnDisable()
    {
        boton.action.started -= OnPulsar;
        boton.action.Disable();
    }
}
