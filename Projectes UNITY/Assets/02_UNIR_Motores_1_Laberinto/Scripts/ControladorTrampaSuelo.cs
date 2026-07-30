using TMPro;
using UnityEngine;

public class ControladorTrampaSuelo : ClaseAbstractaControladorTrampa
{
    [SerializeField] float velocidad = 0.1f;
    [SerializeField] float alturaFinal = 2f;
    [SerializeField] float alturaInicial = -1f;

    bool estaSubiendo = true;

    void Update()
    {
        Movimiento();
    }

    public override void Movimiento()
    {
        Vector3 posicion = transform.localPosition;
        if (estaSubiendo)
        {
            posicion.y = posicion.y + velocidad * Time.deltaTime;

            if (posicion.y >= alturaFinal)
            {
                estaSubiendo = false;
            }
        }
        else
        {
            posicion.y = posicion.y - velocidad * Time.deltaTime;

            if (posicion.y <= alturaInicial)
            {
                estaSubiendo = true;
            }
        }

        transform.localPosition = posicion;
    }
    public override void Activar(ControladorMovimientoJugador jugador)
    {
        MostrarMensaje();
        jugador.Respawn();
    }

}
