using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroController : MonoBehaviour
{
    Rigidbody mi_rigBody;

    public float force;
    public float gravity;

    public int score;
    public AudioSource jumpSound;

    void Awake()
    {
        mi_rigBody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola soy el start de este GameObject" + gameObject.name);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mi_rigBody.AddForce(Vector3.down * gravity); 
       
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {

            
            mi_rigBody.velocity = Vector3.zero;
            mi_rigBody.AddForce(Vector3.up * force, ForceMode.VelocityChange); 
            jumpSound.Play();
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("He chocado con" + collision.gameObject.name);
        Time.timeScale = 0.0f;

    }




}
