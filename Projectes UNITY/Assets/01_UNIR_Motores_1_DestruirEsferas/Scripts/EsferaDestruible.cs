using System;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class EsferaDestruible : MonoBehaviour
{
    public static int puntuacionTotal = 0;
    private bool tocaSuelo = false;
    [SerializeField] float startSpeed = 1f;

    Vector3 velocity = Vector3.zero;
    Vector3 gravity = Vector3.down * 9.81f;

    [SerializeField] GameObject particulasDestruccionEsferaPrefab;
    [SerializeField] GameObject particulasDestruccionEsferaSueloPrefab;

    private void Start()
    {
        velocity = Random.onUnitSphere * startSpeed;
    }
    private void Update()
    {
        velocity += gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    public void NotifyHasBeenHit()
    {
        puntuacionTotal += 10;
        DestruccionEsfera();
    }

    private void OnTriggerEnter(Collider triggerSuelo)
    {

        tocaSuelo = true;
        if (triggerSuelo.CompareTag("TriggerSueloEsferas"))
        {
            DestruccionEsfera(); 
            Debug.Log("Esfera destruida");
        }
    }

    private void DestruccionEsfera()
    {
        Destroy(gameObject);
        if (tocaSuelo)
        {
            Instantiate(particulasDestruccionEsferaSueloPrefab, transform.position, particulasDestruccionEsferaSueloPrefab.transform.rotation);
        }
        else
        {
            Instantiate(particulasDestruccionEsferaPrefab, transform.position, Quaternion.identity);
        }
            

        
    }


}
