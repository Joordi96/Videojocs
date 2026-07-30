using UnityEngine;

public class FuenteDeEsferasDestruibles : MonoBehaviour
{
    [SerializeField] GameObject esferaDestruiblePrefab;
    [SerializeField] float esferasPorSegundo = 1f;
    
    float tiempoTranscurrido = 0f;
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= 1f / esferasPorSegundo)
        {
            tiempoTranscurrido = 0f;
            Instantiate(esferaDestruiblePrefab, transform.position, Quaternion.identity);
        }
    }
}
