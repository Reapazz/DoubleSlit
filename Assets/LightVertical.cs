


using System.Collections.Generic;
using System.ComponentModel;
using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class LightVertical : MonoBehaviour
{
    float x, y, z;


    public int wavelength;


    public GameObject EntangledModel;
    public GameObject Entangled,Entangled2,Entangled4;
    

    public Vector3 prevPos;
    public int sameDirectionCounter;
    GameObject fieldScripts;
    TimeCounter obj;
    public Material LightSkin;
    public Material EntangledLightSkin;
    public List<GameObject> colliderList;






    // Start is called before the first frame update
    void Start()
    {
        fieldScripts = GameObject.Find("FieldScripts");
        obj = fieldScripts.GetComponent<TimeCounter>();
        colliderList = fieldScripts.GetComponent<drawSingleSlit>().getColliderArray();
        z = transform.position.z;

        //gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    // Update is called once per frame


    public void Update()
    {

        fieldScripts = GameObject.Find("FieldScripts");
        obj = fieldScripts.GetComponent<TimeCounter>();




        if (obj.run() == true) //&& obj.LightStep<obj.EntangledLightStep
        { //If the remainder of the current frame divided by 100 is 0 run the function.

            obj.LightStep = obj.frames;

            

            if (Entangled == null)
            {
               


                x = transform.position.x + 1;
                //y = transform.position.y + (transform.position.y - prevPos.y);



                if (sameDirectionCounter >= wavelength)
                {
                    sameDirectionCounter = 0;


                    int i = Random.Range(0, 2);


                    if (i == 1)
                    {

                        y = transform.position.y + 1;
                        z = transform.position.z ;
    


                    }
                    if (i == 0)
                    {
                        y = transform.position.y - 1;
                       z = transform.position.z ;

                    }


                    if (i == 2)
                    {//Debug.Log("I=2");
                    }
                }
                else
                {


                    y = transform.position.y + (transform.position.y - prevPos.y);
                    z = transform.position.z ;


                }
            }
            else //entangled
            {

                
        if(Entangled2 == null && Entangled4 != null){
         //   Debug.Log("noent2");

        //z = transform.position.z+ (Entangled4.transform.position.z- Entangled4.GetComponent<HorizontalMove>().prevPos.z);
        z = Entangled4.transform.position.z;
          try {

                Entangled2 = Entangled4.GetComponent<HorizontalMove>().Entangled;

            }
            catch (NullReferenceException e){
                Console.WriteLine($"No partner to entangle  '{e}'");
            } 

        }

        else if(Entangled4 == null && Entangled2 != null){
            //Debug.Log("noent4");
           // z = transform.position.z+ (Entangled2.transform.position.z- Entangled2.GetComponent<HorizontalMove>().prevPos.z); 
           z= Entangled2.transform.position.z; 
            try {

                Entangled4 = Entangled2.GetComponent<HorizontalMove>().Entangled;

            }
            catch (NullReferenceException e){
                Console.WriteLine($"No partner to entangle  '{e}'");
            } 

        }

        else if (Entangled4 == null && Entangled2 == null || Entangled4 != null && Entangled2 != null){


              z = transform.position.z ;


        }
                
                x = transform.position.x + 1;
             
                if (sameDirectionCounter == wavelength)
                {
                    sameDirectionCounter = 0;

                    y = transform.position.y - (transform.position.y - prevPos.y);
                  



                }
                else
                {
                    y = transform.position.y + (transform.position.y - prevPos.y);
            
                }



            }
            prevPos = transform.position;
            sameDirectionCounter++;
            UnityEngine.Collider[] intersecting = Physics.OverlapSphere(new Vector3(x, y, z), 0.0005f);
            if (intersecting.Length == 0)

            {
                gameObject.GetComponent<Renderer>().material = LightSkin;
                transform.position = new Vector3(x, y, z);


            }





            else foreach (UnityEngine.Collider obj in intersecting)
                {
                    if (colliderList.Contains(obj.gameObject))
                    { 
                       transform.position = new Vector3(x, y, z);
                        GameObject wall = obj.gameObject;
                        wall.GetComponent<colliderUpdate>().hits++;
                        Destroy(gameObject);
                        Destroy(this);
                        //UnityEngine.Debug.Log("Died");
                      
                    }

                    if (obj.gameObject.GetComponent<LightVertical>() != null && obj.gameObject.GetComponent<LightVertical>().enabled == true)
                    {

                        transform.position = new Vector3(x, y, z);
                        GameObject entangled2 = obj.gameObject;
                        if (Entangled != null)
                        {
                            Entangled.GetComponent<LightVertical>().Entangled = null;
                        }
                        Entangle(entangled2);
                        entangled2.GetComponent<LightVertical>().Entangle(gameObject);
                        gameObject.GetComponent<Renderer>().material = EntangledLightSkin;
                        entangled2.GetComponent<Renderer>().material = EntangledLightSkin;

                    }

                    if (obj.name.Contains("Sphere"))
                    {

                        Destroy(gameObject);
                        Destroy(this);
                        UnityEngine.Debug.Log("Died in Sphere");
                      


                    }
                    else if (obj.gameObject.GetComponent<HorizontalMove>() != null || obj.gameObject.GetComponent<LightVertical>() != null) //only other possible option is that it collided with another light particle which is not entangled in same direction
                    {

                        transform.position = new Vector3(x, y, z);
                        GameObject entangled2 = obj.gameObject;
                        entangled2.GetComponent<Renderer>().material = EntangledLightSkin;
                        gameObject.GetComponent<Renderer>().material = EntangledLightSkin;

                    }
                }



        }


    }

    public void Entangle(GameObject ent)
    {
        this.Entangled = ent;

        sameDirectionCounter = 0;



    }
    public void setPreviousPos(Vector3 pos)
    {

        prevPos = pos;


    }

    // public bool hitWall(){





    //}
}
