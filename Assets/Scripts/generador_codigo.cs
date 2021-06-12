using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador_codigo : MonoBehaviour
{
    public float timer = 0, turnSpeed, maxTime = 4;
    public GameObject shark, exclamation, faro, player;
    private Vector3 posIni;

    //Función que se ejecuta una sola vez al comienzo.
    void Start()
    {
        //Instanica Tiburones
        StartCoroutine(firstInstance());
    }

    //Función que se ejecuta múltiples veces (cada frame) todo el tiempo
    void Update()
    {
        //Gira el objeto invisible entorno al player en el que se instancia un tiburon.
        this.transform.RotateAround(faro.transform.position, Vector3.forward, turnSpeed * Time.deltaTime);
    }

    IEnumerator firstInstance()
	{
        yield return new WaitForSeconds(5f);
        StartCoroutine(sharkInstance());
    }

    IEnumerator sharkInstance()
	{
        Vector3 posIni = this.transform.position;
        //Instanciamos el signo de exclamacion
        yield return new WaitForSeconds(0.1f);
        GameObject newexcla = Instantiate(exclamation);
        newexcla.transform.position = this.transform.GetChild(0).transform.position;
        Destroy(newexcla, 1);

        //Esperamos 1 segundo antes de instanciar un tiburon
        yield return new WaitForSeconds(1f);
        GameObject newshark = Instantiate(shark);
        newshark.transform.position = posIni;
        Destroy(newshark, 10);

        yield return new WaitForSeconds(Random.Range(-3f,3f));
        StartCoroutine(sharkInstance());
    } 
    
}
