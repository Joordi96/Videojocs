using UnityEngine;

public class DetectarBotonConOverlap : MonoBehaviour
{
    [SerializeField] float radioDeteccion = 3f;
    [SerializeField] LayerMask layerMask;
    private ControladorMensajes controladorMensajes;
    private bool hayBoton;
    private bool textoVisible = false;

    public void Awake()
    {
        controladorMensajes = FindFirstObjectByType<ControladorMensajes>();

        if (controladorMensajes == null)
        {
            Debug.LogError("No se ha encontrado un ControladorMensajes en la escena.");
        }
    }
    public void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioDeteccion, layerMask);

        hayBoton = false;

        for (int i = 0 ; i < colliders.Length ; i++)
        {
            if (colliders[i].CompareTag("Boton"))
            {
                
                hayBoton = true;
                break;
            }
        }

        if (hayBoton && !textoVisible)
        {
            controladorMensajes.MostrarInteraccion("Pulsa [E] para activar");
            textoVisible = true;
        }
        else if (!hayBoton && textoVisible)
        {
            controladorMensajes.OcultarInteraccion();
            textoVisible = false;
        }
    }
}