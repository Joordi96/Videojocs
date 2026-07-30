using UnityEngine;

public class OnTriggerTrampa : MonoBehaviour
{
    [SerializeField] ClaseAbstractaControladorTrampa trampa;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Choque con trampa");

            trampa.Activar(other.GetComponent<ControladorMovimientoJugador>());
        }
    }
}
