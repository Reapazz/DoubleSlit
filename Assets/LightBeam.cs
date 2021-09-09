using System;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

public class LightBeam : MonoBehaviour
{ 

public GameObject EntangledLight;

Vector3[] pos = new Vector3[200];
 GameObject fieldScripts;   
  TimeCounter obj ;
    public static int Height = 5;
    public static int Width=5;

    static int minWave = 10;
    static int maxWave =10;
    //For field generating based on waverange

    static double waveRange = (minWave + maxWave) / 2;
    static double waveRange2 = Math.Round(waveRange);

    public static int waveGen = (int)waveRange2;
    //

    public int waveSel;

    // Start is called before the first frame update
    void Start()
    {/*
         
              Width = Field.getWidth();
        Length = Field.getLength();
    

        //Light.AddComponent<Move>();


    int i = 0; 

          for (int i3 = (Width/4)-1 ; i3 < (Width/4)+1; i3++) {
              i++;
        pos[i] = new Vector3(transform.position.x, transform.position.y, transform.position.z+1+(2*i*(LightBeam.waveGen+1))); //  Iterate over all position vectors and add ot araay
       // Instantiate (Light, pos[i], transform.rotation); 
         GameObject ent = Instantiate (EntangledLight, pos[i], transform.rotation); 
         ent.GetComponent<EntangledMove>().enabled = true;
       
      
        
    }
     */
      fieldScripts = GameObject.Find("FieldScripts");
       obj =  fieldScripts.GetComponent<TimeCounter>();
       
     
    }

    // Update is called once per frame
    void Update()
    
    {


        

       

        if (obj.run() ==true ){
            waveSel = UnityEngine.Random.Range(minWave, maxWave);



            //Light.AddComponent<Move>();
            for (int i2 = -(Width - 1 + Width % 2)/2;i2 <= (Width - 1 + Width % 2)/2;  i2+= 1 ) {


                    //int i3 = -(Height - 1 +Height % 2)/2; i3 <= (Height - 1 + Height % 2)/2; i3 += 1
                for (int i3 = -(Height - 1 +Height % 2)/2; i3 <= (Height - 1 + Height % 2)/2; i3 += 1) {



                    Vector3 vec = new Vector3(transform.position.x , transform.position.y +  (3 + (i3 *(2*waveSel+1 )) ), transform.position.z +  ((i2 *(2* waveSel+1 ) )));

                    //   Vector3 vec2 = new Vector3(transform.position.x - 1, transform.position.y - 15 + Mathf.Sqrt(2) * (15-(i3*(LightBeam.waveGen+1)/2)), transform.position.z + 15 + Mathf.Sqrt(2) * (15+(i3 * (LightBeam.waveGen+1)/2)));
                    //  Iterate over all position vectors and add ot araay
                    // Instantiate (Light, pos[i], transform.rotation); 
                   GameObject ent = Instantiate(EntangledLight, vec, transform.rotation);

                   

                    ent.GetComponent<EntangledMove>().enabled = true;
                    ent.GetComponent<EntangledMove>().waveGen = waveSel;





                    // Place  sphere


                }
            }


            
        }
        
    }
}

