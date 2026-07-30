using System.Collections;
using TMPro;
using UnityEngine;

public class ControladorMensajes : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoMensaje;

    private Coroutine coroutineActual;

    private void Awake()
    {
        textoMensaje.gameObject.SetActive(false);
    }

    public void MostrarMensaje(string mensaje, float duracion)
    {
        if (coroutineActual != null)
        {
            StopCoroutine(coroutineActual);
        }

        coroutineActual = StartCoroutine(
            MostrarMensajeCoroutine(mensaje, duracion)
        );
    }

    private IEnumerator MostrarMensajeCoroutine(
        string mensaje,
        float duracion
    )
    {
        textoMensaje.text = mensaje;
        textoMensaje.gameObject.SetActive(true);

        yield return new WaitForSeconds(duracion);

        textoMensaje.gameObject.SetActive(false);
        coroutineActual = null;
    }
}