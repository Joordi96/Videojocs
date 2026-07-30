using UnityEngine;
using UnityEngine.Playables;
using Unity.Cinemachine;

public class OnTriggerEnterAnimacionVictoria : MonoBehaviour
{
    [SerializeField] GameObject animacionVictoria;
    [SerializeField] ControladorMovimientoJugador controladorJugador;
    [SerializeField] ControladorCamaraJugador controladorCamara;

    [SerializeField] private PlayableDirector director;
    [SerializeField] private CinemachineCamera camaraJugador;
    [SerializeField] private CinemachineCamera camaraVistaFinal;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("El objeto que entró en el trigger es el jugador.");
            controladorJugador.ActivarControl(false);
            controladorCamara.ActivarControlCamara(false);
            animacionVictoria.SetActive(true);
        }
        else
        {
            Debug.Log("El objeto que entró en el trigger no es el jugador.");
        }
    }
    private void OnEnable()
    {
        director.stopped += FinTimeline;
    }

    private void OnDisable()
    {
        director.stopped -= FinTimeline;
    }

    private void FinTimeline(PlayableDirector directorFinalizado)
    {
        camaraJugador.Priority = 0;
        camaraVistaFinal.Priority = 20;
    }
}
