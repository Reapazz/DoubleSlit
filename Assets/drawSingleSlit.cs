﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;


public class drawSingleSlit : MonoBehaviour
{
    List<GameObject> slit = new List<GameObject>();
  
    public GameObject cubePrefab;
    public int height = 1;


    // Start is called before the first frame update
    void Start()
    {

        /*
        //Draw Single slit
        
       for (int i=0; i< PlaceField.Length/2-1; i++){
        GameObject newCube = Instantiate(cubePrefab,new Vector3(10,0,1+2*i),Quaternion.identity);
            slit.Add(newCube);
       }

        for (int i=PlaceField.Length/2+1; i< PlaceField.Length; i++){
         GameObject newCube = Instantiate(cubePrefab,new Vector3(10,0,1+(2*i)),Quaternion.identity);
          slit.Add(newCube);
       }
       */

        //transform.rotation = Quaternion.Euler(45, 0, 0);
        //Draw Back Wall

        for (int ih = -30; ih <= 30; ih++)
        {
            for (int i = -20; i <= PlaceField.Length + 20; i++)
            {

                GameObject newCube = Instantiate(cubePrefab, new Vector3(PlaceField.Width - 2,    ih, i), transform.rotation);
                slit.Add(newCube);
            }
        }




        //Draw Double slit:
        for (int ih = -(height+10); ih < height+10; ih++) { 

        for (int i = -10; i < (PlaceField.Length - LightBeam.waveGen) / 2 -7; i++)
        {
            GameObject newCube = Instantiate(cubePrefab, new Vector3(LightBeam.waveGen + (LightBeam.waveGen % 2), ih ,  i ), transform.rotation);
            slit.Add(newCube);
        }

        for (int i = (PlaceField.Length + LightBeam.waveGen) / 2 +6 - PlaceField.Length % 2; i < PlaceField.Length+10; i++)
        {
            GameObject newCube = Instantiate(cubePrefab, new Vector3(LightBeam.waveGen * 1 + (LightBeam.waveGen % 2), ih ,  i), transform.rotation);
            slit.Add(newCube);
        }



        for (int i = ((PlaceField.Length - LightBeam.waveGen) / 2) - 2; i <= ((PlaceField.Length + LightBeam.waveGen) / 2) + 1; i++)
        {


            GameObject centerCube = Instantiate(cubePrefab, new Vector3(LightBeam.waveGen + (LightBeam.waveGen % 2), ih , (( i))), transform.rotation);
            slit.Add(centerCube);
        }
    }
    


    }


    public List<GameObject> getColliderArray(){
        return slit;
    }

    
    

    // Update is called once per frame
    
}
