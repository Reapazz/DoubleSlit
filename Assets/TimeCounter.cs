using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public int frames = 0;
public int LightStep;
public int EntangledLightStep;
public int frameMod ;
public int entangledStep;
    // Start is called before the first frame update
    void Start()
    {
         

        
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        
    }

    public int getFrames(){
        return frames;
    }
    public bool run(){
  if (frames % frameMod == 0){

      return true;
  }
  else{
      return false;
  }

    }


    public bool runEntangled(){
  if (frames % frameMod == 1){

      return true;
  }
  else{
      return false;
  }

    }


     

    
}
