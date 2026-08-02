using Unity.Cinemachine;
using UnityEngine;

public class OnTriggerDetecarSoldadoConRaycast : MonoBehaviour
{
    [SerializeField] Camera vistaJugador;
    [SerializeField] LayerMask layermask;
    [SerializeField] float distanciaMaxima;
    void Update()
    {
        Ray rayo = vistaJugador.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0f));


        if (Physics.Raycast(rayo, out RaycastHit hit, distanciaMaxima))
        {
            if (hit.collider.transform.root.CompareTag("TrampaSoldado"))
            {
                Debug.Log("Estas apuntando a un soldado!");
            }
        }
    }
}
