



using System.Collections.Generic;
using System.ComponentModel;
using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    float x, y, z;


    public int wavelength;


    public GameObject EntangledModel;
    public GameObject Entangled, Entangled1, Entangled3;


    public Vector3 prevPos;
    public int sameDirectionCounter;
    GameObject fieldScripts;
    TimeCounter obj;
    public Material LightSkin;
    public Material EntangledLightSkin;
    public List<GameObject> colliderList;

    public Boolean returnedToStartZ = false;
    public float startZ;




    // Start is called before the first frame update
    void Start()
    {
        fieldScripts = GameObject.Find("FieldScripts");
        obj = fieldScripts.GetComponent<TimeCounter>();
        colliderList = fieldScripts.GetComponent<drawSingleSlit>().getColliderArray();
        startZ = prevPos.z;

        //gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    // Update is called once per frame


    public void Update()
    {





        x = transform.position.x + 1;
        if (obj.run() == true) //&& obj.LightStep<obj.EntangledLightStep
        {

            obj.LightStep = obj.frames;

            if (Entangled == null)
            {


                if (transform.position.z == startZ && returnedToStartZ == false)
                {

                    returnedToStartZ = true;
                    sameDirectionCounter = wavelength;

                }

                if (returnedToStartZ == true)
                {



                    if (sameDirectionCounter >= wavelength)
                    {
                        sameDirectionCounter = 0;


                        int i = Random.Range(0, 2);


                        if (i == 1)
                        {
                            y = transform.position.y;

                            z = transform.position.z + 1;


                        }
                        if (i == 0)
                        {
                            z = transform.position.z - 1;
                            y = transform.position.y;

                        }


                        if (i == 2)
                        {//Debug.Log("I=2");
                        }
                    }
                    else
                    {


                        z = transform.position.z + (transform.position.z - prevPos.z);
                        y = transform.position.y;


                    }
                }
                else if (returnedToStartZ == false)
                {

                    if (sameDirectionCounter == wavelength)
                    {
                        sameDirectionCounter = 0;

                        z = transform.position.z - (transform.position.z - prevPos.z);
                        y = transform.position.y;


                    }
                    else
                    {
                        z = transform.position.z + (transform.position.z - prevPos.z);
                        y = transform.position.y;
                    }


                }
            }
            else
            {


                if (sameDirectionCounter == wavelength)
                {
                    sameDirectionCounter = 0;

                    z = transform.position.z - (transform.position.z - prevPos.z);
                    y = transform.position.y;


                }
                else
                {
                    z = transform.position.z + (transform.position.z - prevPos.z);
                    y = transform.position.y;
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


                    if (obj.gameObject.GetComponent<HorizontalMove>() != null && obj.gameObject.GetComponent<HorizontalMove>().enabled == true)
                    {

                        transform.position = new Vector3(x, y, z);
                        GameObject entangled2 = obj.gameObject;
                        if (Entangled != null)
                        {
                            this.Entangled.GetComponent<HorizontalMove>().Entangled = null;
                        }

                        Entangle(entangled2);
                        entangled2.GetComponent<HorizontalMove>().Entangle(gameObject);
                        gameObject.GetComponent<Renderer>().material = EntangledLightSkin;
                        entangled2.GetComponent<Renderer>().material = EntangledLightSkin;

                    }
                    if (obj.name.Contains("Sphere"))
                    {

                        Destroy(gameObject);
                        Destroy(this);
                        UnityEngine.Debug.Log("Died in Sphere");



                    }
                    else if (obj.gameObject.GetComponent<HorizontalMove>() != null || obj.gameObject.GetComponent<LightVertical>() != null)
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
