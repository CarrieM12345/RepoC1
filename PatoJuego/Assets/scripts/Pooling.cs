using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour


{
public GameObject goPrefab;
public int poolMaxSize;
List<GameObject> elementPoolList;

// Start is called before the first frame update
    void Start()
    {
       elementPoolList = new List<GameObject>();

        for (int i = 0; i < poolMaxSize; i++) 
        {
            GameObject objetillo = (GameObject) Instantiate(goPrefab, transform);    
            objetillo.SetActive(false);   
            elementPoolList.Add(objetillo);
           
        }

       
    }
    public GameObject GetPoolObject()
    {
        for (int i = 0; i < elementPoolList.Count; i++)
        {
            if (elementPoolList[i].activeInHierarchy == false)
            {

                return elementPoolList[i];

            }


        }
        return null;
    }

        // Update is called once per frame
        void Update()
        {



        }

    
}
