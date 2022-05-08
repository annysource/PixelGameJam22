using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capivarias : MonoBehaviour
{

    public AudioSource getCapi;
    public static int tomaCapivara = 1;
    void Start()
    {
        getCapi = GetComponent<AudioSource>();
    }

    IEnumerator Destruir()
    {

        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            
            GameManager.filhas = GameManager.filhas + tomaCapivara;
            getCapi.Play();
            StartCoroutine(Destruir());


        }
    }
}
