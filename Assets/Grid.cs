using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGrid : MonoBehaviour

{
    public GameObject sphere = null;
    

    // Start is called before the first frame update
    void Start(){
        Instantiate(sphere);
    }

                                
              
                            
                             
   

    
    
        /**
         Vector3[] pos;
            for (int i = 0; i < obj.Length; i++) {

         pos = new Vector3[obj.Length];
          public GameObject [] obj;
 pos[i] = new Vector3(transform.position.x + i, transform.position.y, transform.position.z);

         Instantiate (obj [i], pos[0], transform.rotation);

*/
        



    
     
 
 

    // Update is called once per frame
    void Update()
    {
        
    }
}