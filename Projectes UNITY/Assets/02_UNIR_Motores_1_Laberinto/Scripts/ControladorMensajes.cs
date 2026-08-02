using System.Collections;
using TMPro;
using UnityEngine;

public class ControladorMensajes : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoMensaje;

    [SerializeField] private CanvasGroup canvasGroupInteraccion;
    [SerializeField] private TextMeshProUGUI textoInteraccion;

    private Coroutine coroutineActual;

    private void Awake()
    {
        textoMensaje.gameObject.SetActive(false);
        textoInteraccion.gameObject.SetActive(true);

        canvasGroupInteraccion.alpha = 0f;

        canvasGroupInteraccion.interactable = false;
        canvasGroupInteraccion.blocksRaycasts = false;
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

    public void MostrarInteraccion(string mensaje)
    {
        textoInteraccion.text = mensaje;
        canvasGroupInteraccion.alpha = 1f;
    }

    public void OcultarInteraccion()
    {
        canvasGroupInteraccion.alpha = 0f;
    }
}