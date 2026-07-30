using UnityEngine;
using UnityEngine.Playables;

public class ControladorInicioNivel : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private ControladorMovimientoJugador controladorJugador;
    [SerializeField] private ControladorCamaraJugador controladorCamara;

    private void Start()
    {
        controladorJugador.ActivarControl(false);
        controladorCamara.ActivarControlCamara(false);

        director.stopped += FinTimeline;
    }

    private void FinTimeline(PlayableDirector director)
    {
        controladorJugador.ActivarControl(true);
        controladorCamara.ActivarControlCamara(true);
    }
}
