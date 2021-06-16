



using System.Collections.Generic;
using System.ComponentModel;
using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class Move1 : MonoBehaviour
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

        //gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    // Update is called once per frame


    public void Update()
    {





        x = transform.position.x + 1;
        if (obj.run() == true) //&& obj.LightStep<obj.EntangledLightStep
        { //If the remainder of the current frame divided by 100 is 0 run the function.

            obj.LightStep = obj.frames;
            
            if (Entangled == null)
            {
                





                if (sameDirectionCounter >=  wavelength)
                {
                    sameDirectionCounter = 0;


                    int i = Random.Range(0, 2);


                    if (i == 1)
                    {
                        y = transform.position.y - (1 / Mathf.Sqrt(2));
                        z = transform.position.z + (1 / Mathf.Sqrt(2));


                    }
                    if (i == 0)
                    {
                        z = transform.position.z - (1 / Mathf.Sqrt(2));
                        y = transform.position.y + (1 / Mathf.Sqrt(2));

                    }


                    if (i == 2)
                    {//Debug.Log("I=2");
                    }
                }
                else
                {


                    z = transform.position.z + (transform.position.z - prevPos.z);
                    y = transform.position.y + (transform.position.y - prevPos.y);


                }
            }
            else
            {
                

                if (sameDirectionCounter == wavelength)
                {
                    sameDirectionCounter = 0;

                    z = transform.position.z - (transform.position.z - prevPos.z);
                    y = transform.position.y - (transform.position.y - prevPos.y);


                }
                else
                {
                    z = transform.position.z + (transform.position.z - prevPos.z);
                    y = transform.position.y + (transform.position.y - prevPos.y);
                }



            }
            sameDirectionCounter++;
            prevPos = transform.position;
            UnityEngine.Collider[] intersecting = Physics.OverlapSphere(new Vector3(x, y, z), 0.0005f);
            if (intersecting.Length == 0)

            {
                
                gameObject.GetComponent<Renderer>().material = LightSkin;
                transform.position = new Vector3(x, y, z);



            }


            else foreach (UnityEngine.Collider obj in intersecting)
                {

                    if (colliderList.Contains(obj.gameObject))
                    { //TODO cant figure this shit out
                        transform.position = new Vector3(x, y, z);
                        GameObject wall = obj.gameObject;
                        wall.GetComponent<colliderUpdate>().hits++;
                        Destroy(gameObject);
                        Destroy(this);
                        // UnityEngine.Debug.Log("Died");

                 


                    }


                    if (obj.gameObject.GetComponent<Move1>() != null && obj.gameObject.GetComponent<Move1>().enabled == true)
                    {

                        transform.position = new Vector3(x, y, z);
                        GameObject entangled2 = obj.gameObject;
                        if (Entangled != null)
                        {
                            this.Entangled.GetComponent<Move1>().Entangled = null;
                        }

                        Entangle(entangled2);
                        entangled2.GetComponent<Move1>().Entangle(gameObject);
                        gameObject.GetComponent<Renderer>().material = EntangledLightSkin;
                        entangled2.GetComponent<Renderer>().material = EntangledLightSkin;
                        
                    }
                    if (obj.name.Contains("Sphere"))
                    {
                       
                        Destroy(gameObject);
                        Destroy(this);
                        UnityEngine.Debug.Log("Died in Sphere");
                        
                       

                    }
                    else if(obj.gameObject.GetComponent<Move1>() != null || obj.gameObject.GetComponent<LightVertical>() != null)
                    {

                        transform.position = new Vector3(x, y, z);
                        GameObject entangled2 = obj.gameObject;
                        entangled2.GetComponent<Renderer>().material = EntangledLightSkin;
                        gameObject.GetComponent<Renderer>().material = EntangledLightSkin;

                    }


                }
            //   GameObject ent =  Instantiate (EntangledModel, new Vector3(x, y, z), transform.rotation); 
            //    ent.GetComponent<EntangledMove>().enabled = true; 
            //  ent.GetComponent<EntangledMove>().fieldScripts   =  GameObject.Find("FieldScripts");
            //ent.GetComponent<EntangledMove>().obj =  fieldScripts.GetComponent<TimeCounter>();
            //  /ent.GetComponent<EntangledMove>().isLaser = false;

            //obj.EntangledLightStep = obj.frames;

        }
    }




    // transform.position += transform.forward*Time.deltaTime;       


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
