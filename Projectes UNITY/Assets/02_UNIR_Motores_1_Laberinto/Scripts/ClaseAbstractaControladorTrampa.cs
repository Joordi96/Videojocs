using UnityEngine;

public abstract class ClaseAbstractaControladorTrampa : MonoBehaviour
{
    [Header("Mensaje")]
    [SerializeField] private string mensaje;
    [SerializeField] private float tiempoMensaje = 3f;

    private ControladorMensajes controladorMensajes;

    protected virtual void Awake()
    {
        controladorMensajes = FindFirstObjectByType<ControladorMensajes>();

        if (controladorMensajes == null)
        {
            Debug.LogError("No se ha encontrado un ControladorMensajes en la escena.");
        }
    }

    protected void MostrarMensaje()
    {
        if (controladorMensajes != null)
        {
            controladorMensajes.MostrarMensaje(mensaje, tiempoMensaje);
        }
    }

    public abstract void Movimiento();

    public abstract void Activar(ControladorMovimientoJugador jugador);
}