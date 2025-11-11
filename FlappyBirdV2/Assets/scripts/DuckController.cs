using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class DuckController : MonoBehaviour
{
     private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Floor") 
        {


            GameManager.instance.n_patos++;
            gameObject.SetActive(false);

        }

    } 
    
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
