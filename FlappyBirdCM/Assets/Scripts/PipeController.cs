using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float xPosition;
    public float yPosition;
    public float yVariance;
    public float yVariance2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime;
        if (transform.position.x < -11.0f)
        {
            transform.position = new Vector3(11.0f, Random.Range(-5.0f, 3.0f), 0.0f);
            
        }

    }
}
