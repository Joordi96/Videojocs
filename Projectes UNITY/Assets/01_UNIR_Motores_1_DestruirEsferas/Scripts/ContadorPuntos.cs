using UnityEngine;
using TMPro;

public class ContadorPuntos : MonoBehaviour
{
    TextMeshProUGUI texto;

    private void Awake()
    {
        texto = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = "Puntos: " + EsferaDestruible.puntuacionTotal;
    }
}
