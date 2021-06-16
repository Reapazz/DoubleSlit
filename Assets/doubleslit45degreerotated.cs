/*
using System.Collections;
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

       

        transform.rotation = Quaternion.Euler(45, 0, 0);
        //Draw Back Wall

        for (int ih = -30; ih <= 30; ih++)
        {
            for (int i = -20; i <= PlaceField.Length + 20; i++)
            {

                GameObject newCube = Instantiate(cubePrefab, new Vector3(PlaceField.Width - 2,  Mathf.Sqrt(2) * ih,  Mathf.Sqrt(2) * i), transform.rotation);
                slit.Add(newCube);
            }
        }


        //Draw Double slit:
        for (int ih = -height; ih < height; ih++) { 

        for (int i = 0; i < (PlaceField.Length - LightBeam.waveGen) / 2 - 4; i++)
        {
            GameObject newCube = Instantiate(cubePrefab, new Vector3(LightBeam.waveGen + (LightBeam.waveGen % 2), ih*Mathf.Sqrt(2),  i * Mathf.Sqrt(2)), transform.rotation);
            slit.Add(newCube);
        }

        for (int i = (PlaceField.Length + LightBeam.waveGen) / 2 + 5 - PlaceField.Length % 2; i < PlaceField.Length; i++)
        {
            GameObject newCube = Instantiate(cubePrefab, new Vector3(LightBeam.waveGen * 1 + (LightBeam.waveGen % 2), ih * Mathf.Sqrt(2),  i* Mathf.Sqrt(2)), transform.rotation);
            slit.Add(newCube);
        }



        for (int i = ((PlaceField.Length - LightBeam.waveGen) / 2) - 2; i <= ((PlaceField.Length + LightBeam.waveGen) / 2) + 2; i++)
        {


            GameObject centerCube = Instantiate(cubePrefab, new Vector3(LightBeam.waveGen + (LightBeam.waveGen % 2), ih * Mathf.Sqrt(2), (( i)*Mathf.Sqrt(2))), transform.rotation);
            slit.Add(centerCube);
        }
    }
    }


    public List<GameObject> getColliderArray(){
        return slit;
    }

    
    

    // Update is called once per frame
    
}
*/