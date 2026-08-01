using UnityEngine;

public class ControladorTrampaSoldado : ClaseAbstractaControladorTrampa
{
    [SerializeField] float velocidadGiro = 1f;
    [SerializeField] Vector3 ejeRotacion = new Vector3(0, 1, 0);

    public void Update()
    {
        Movimiento();
    }
    public override void Movimiento()
    {
        transform.Rotate(ejeRotacion, velocidadGiro * Time.deltaTime);
    }

    public override void Activar(ControladorMovimientoJugador jugador)
    {
        MostrarMensaje();
        jugador.Respawn();
    }
}
