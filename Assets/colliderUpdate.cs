using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderUpdate : MonoBehaviour
{


    public int hits ;
                Color white = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        hits=0;
    }

    // Update is called once per frame
    void Update()
    {
       
        Color newColor = Color.Lerp(white, Color.black, hits*0.1f);
        gameObject.GetComponent<Renderer>().material.color = newColor;
        

        
    }
}
