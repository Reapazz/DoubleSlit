using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceField : MonoBehaviour
{
  
  public static int Length = LightBeam.waveGen*10;
  public static int Width = LightBeam.waveGen*40;
  public int Height=3;
  
      public GameObject sphere ;
      public GameObject[,] sphereArray = null; 
      public int getWidth(){
          return Width;
      }
      public int getLength(){
          return Length;
      }
  

   
    
    // Start is called before the first frame update
    void Start()
  { 
       
            for (int ih = -(Height-(Height%2))/2; ih < (Height - (Height % 2)) / 2  + Height%2; ih++){
                for (int i2 = 0; i2 < Length; i2++) {




                   
                    //    pos[0] = new Vector3(transform.position.x , transform.position.y+i2, transform.position.z);

                    for (int i3 = 0; i3 < Width; i3++) {
                    // transform.position.z + Mathf.Sqrt(2) * i2    
                 


                    Vector3 pos =  new Vector3(transform.position.x -1 + i3, transform.position.y +Mathf.Sqrt(2) * ((+0.5f*ih)+ ((ih % 2) * 0.5f) + i2 + (0.5f * (i3 % 2))), transform.position.z + Mathf.Sqrt(2) * ((-0.5f*ih)+ ((ih % 2) * 0.5f)+i2 + (0.5f * (i3 % 2)))); //  Iterate over all position vectors and add ot araay 
                    //Vector3 pos = new Vector3(transform.position.x + i3, transform.position.y+ (Mathf.Sqrt(2)* ih*0.5f),(i2+(0.5f*((i3%2)+(ih%2)))) * Mathf.Sqrt(2));
                    GameObject obj = Instantiate(sphere, pos, transform.rotation); // Place  sphere
                  

                      


                    

                }



            }
        }
  }

    // Update is called once per frame
    void Update()
    {
        
    }
  }
