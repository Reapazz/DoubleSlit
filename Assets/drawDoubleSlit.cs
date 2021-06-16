using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class drawDoubleSlit : MonoBehaviour
{
    GameObject[] slit = new GameObject[50];
  
    public GameObject cubePrefab;


    // Start is called before the first frame update
    void Start()
    {
        
       for (int i=0; i< PlaceField.Length/8; i++){
        GameObject newCube = Instantiate(cubePrefab,new Vector3(30,0,200+(2*i)),Quaternion.identity);
            slit [i] = newCube;
       }

        for (int i=0; i< 10; i++){
         GameObject newCube = Instantiate(cubePrefab,new Vector3(30,0,35+(2*i)),Quaternion.identity);
            slit[i+10] = newCube;
       }
    }

    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
