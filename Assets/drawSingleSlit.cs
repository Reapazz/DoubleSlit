using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
//using System.Math;


public class drawSingleSlit : MonoBehaviour
{
    List<GameObject> slit = new List<GameObject>();
  
    public GameObject cubePrefab;
  //  public int height = 1;


    // Start is called before the first frame update
    void Start()
    {
        int h=  LightBeam.Height*2;
        int w = LightBeam.Width;
        int wavegen = LightBeam.waveGen;

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

        for (int ih = -h*wavegen; ih <= h*wavegen; ih++)
        {
            for (int i = -w*3*wavegen; i <= w*3*wavegen; i++)
            {

                GameObject newCube = Instantiate(cubePrefab, new Vector3(PlaceField.Width - 2,    ih, i), transform.rotation);
                slit.Add(newCube);
            }
        }




        //Draw Double slit:
        for (int ih = -(h*wavegen); ih < h*wavegen; ih++) { 

        for (int i = -w*2*wavegen; i <((-2)*wavegen)-2; i++)
        {
            GameObject newCube = Instantiate(cubePrefab, new Vector3(LightBeam.waveGen + (LightBeam.waveGen % 2), ih ,  i ), transform.rotation);
            slit.Add(newCube);
        }

        for (int i = (2*wavegen)+2; i < w*2*wavegen; i++)
        {
            GameObject newCube = Instantiate(cubePrefab, new Vector3(LightBeam.waveGen * 1 + (LightBeam.waveGen % 2), ih ,  i), transform.rotation);
            slit.Add(newCube);
        }



        //for (int i = Mathf.FloorToInt(1.5f*wavegen); i <= Mathf.FloorToInt(wavegen*0.5f); i++)
        for (int i =  -wavegen; i <= wavegen; i++)
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
