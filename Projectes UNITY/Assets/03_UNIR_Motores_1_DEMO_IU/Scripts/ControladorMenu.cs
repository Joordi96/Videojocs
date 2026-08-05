using UnityEngine;

public class Controladormenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup menu;
    enum Resolucion
    {
        Alta, Media, Baja
    }
    public void FadeInOutCanvas(bool activo)
    {
        if (activo)
        {
            MuestraCanvas();
        }
        else
        {
            OcultaCanvas();
        }
    }
    public void MuestraCanvas()
    {
        menu.alpha = 1f;
        Debug.Log("Ejecutando MuestraCanvas");
    }

    public void OcultaCanvas()
    {
        menu.alpha = 0f;
        Debug.Log("Ejecutando OcultaCanvas");

    }

    public void EleccionDropdown(int opcionEscogida)
    {
        switch ((Resolucion)opcionEscogida)
        {
            case Resolucion.Alta:
                Debug.Log("Resolucion alta");
                break;
            case Resolucion.Media:
                Debug.Log("Resolucion media");
                break;
            case Resolucion.Baja:
                Debug.Log("Resolucion baja");
                break;
            default:
                Debug.Log("Caso imposible");
                break;
        }

    }
}
