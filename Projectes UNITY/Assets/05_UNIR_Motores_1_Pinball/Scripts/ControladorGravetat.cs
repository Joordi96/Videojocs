using UnityEngine;

public class ControladorGravetat : MonoBehaviour
{
    [SerializeField] private Vector3 gravedad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Physics.gravity = gravedad;
    }
}
