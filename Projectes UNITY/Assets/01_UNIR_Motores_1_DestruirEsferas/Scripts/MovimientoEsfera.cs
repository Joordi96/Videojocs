using UnityEngine;

public class MovimientoEsfera : MonoBehaviour
{
    public float gradosPorSegundo = 90f;
    private void Start()
    {
    }
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, gradosPorSegundo * Time.deltaTime);
    }
}
