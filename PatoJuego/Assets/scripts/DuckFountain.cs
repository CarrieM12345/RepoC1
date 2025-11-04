using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DuckFountain : MonoBehaviour
{
   public Pooling pool;

    public float force; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LanzaPato();
    }
    void LanzaPato()
    {

       GameObject pato = pool.GetPoolObject();
        if (pato != null) {
        
            pato.transform.position = transform.position;   
            pato.SetActive(true);
            Vector3 direction = new Vector3(Random.Range(-force,force), force, Random.Range(-force,force));
            pato.GetComponent<Rigidbody>().AddForce(direction, ForceMode.VelocityChange);
        
        }




    }


}
