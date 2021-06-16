
using System;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEditorInternal;

public class EntangledMove : MonoBehaviour
{
    float x, y, z;
    float x2, y2, z2, x3, y3, z3, x4, y4, z4;


    public GameObject fieldScripts;
    public TimeCounter obj;
    public GameObject LightModel;
    public GameObject EntangledModel;

    GameObject ent1, ent2, ent3, ent4 = null;

    public int waveGen;


    // Start is called before the first frame update
    void Start()

    {


        //  gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        fieldScripts = GameObject.Find("FieldScripts");
        obj = fieldScripts.GetComponent<TimeCounter>();
        obj.EntangledLightStep = 0;
        obj.LightStep = 1;

        y  = transform.position.y + (1);
        y3 = transform.position.y - (1);
        y2=y4= transform.position.y;
        x = x2 = x3 = x4 = transform.position.x + 1;

        z3 = z = transform.position.z ;
        z2 = transform.position.z+1;
        z4 = transform.position.z-1;



       



    }


    void Awake()
    {

    }

    // Update is called once per frame


    void Update()
    {






        if (obj.runEntangled() == false)
        {

        }



        if (obj.run() == true)
        {



            Move(waveGen);


        }
    }



    // transform.position += transform.forward*Time.deltaTime;       



    void Move(int wave)
    {
        UnityEngine.Collider[] intersecting = Physics.OverlapSphere(new Vector3(x, y, z), 0.01f);
        UnityEngine.Collider[] intersecting2 = Physics.OverlapSphere(new Vector3(x2, y2, z2), 0.01f);
        UnityEngine.Collider[] intersecting3 = Physics.OverlapSphere(new Vector3(x3, y3, z3), 0.01f);
        UnityEngine.Collider[] intersecting4 = Physics.OverlapSphere(new Vector3(x4, y4, z4), 0.01f);
        if (intersecting.Length == 0 && intersecting2.Length == 0 && intersecting3.Length == 0 && intersecting4.Length == 0)

        {
            obj.LightStep = obj.frames;

            /*
            ent1.GetComponent<LightVertical>().Entangle(ent2);
            ent2.GetComponent<LightVertical>().Entangle(ent1);
            ent1.GetComponent<LightVertical>().sameDirectionCounter = 1;
            ent2.GetComponent<LightVertical>().sameDirectionCounter = 1;

            ent1.GetComponent<LightVertical>().Update();
            ent2.GetComponent<LightVertical>().Update();
            */



            ent1 = Instantiate(LightModel, new Vector3(x, y, z), transform.rotation);
            ent1.GetComponent<LightVertical>().enabled = true;
            ent2 = Instantiate(LightModel, new Vector3(x2, y2, z2), transform.rotation);
            ent2.GetComponent<HorizontalMove>().enabled = true;

            ent3 = Instantiate(LightModel, new Vector3(x3, y3, z3), transform.rotation);
            ent3.GetComponent<LightVertical>().enabled = true;
            ent4 = Instantiate(LightModel, new Vector3(x4, y4, z4), transform.rotation);
            ent4.GetComponent<HorizontalMove>().enabled = true;

            ent1.GetComponent<LightVertical>().Entangle(ent3);
            ent3.GetComponent<LightVertical>().Entangle(ent1);
            ent1.GetComponent<LightVertical>().sameDirectionCounter = 1;
            ent3.GetComponent<LightVertical>().sameDirectionCounter = 1;

            ent1.GetComponent<LightVertical>().setPreviousPos(transform.position);
            ent3.GetComponent<LightVertical>().setPreviousPos(transform.position);
            ent2.GetComponent<HorizontalMove>().setPreviousPos(transform.position);
            ent4.GetComponent<HorizontalMove>().setPreviousPos(transform.position);





            ent2.GetComponent<HorizontalMove>().Entangle(ent4);
            ent4.GetComponent<HorizontalMove>().Entangle(ent2);


            ent2.GetComponent<HorizontalMove>().sameDirectionCounter = 1;
            ent4.GetComponent<HorizontalMove>().sameDirectionCounter = 1;

            ent1.GetComponent<LightVertical>().wavelength = wave;
            ent3.GetComponent<LightVertical>().wavelength = wave;
            ent2.GetComponent<HorizontalMove>().wavelength = wave;
            ent4.GetComponent<HorizontalMove>().wavelength = wave;


            ent1.GetComponent<LightVertical>().Entangled2 = ent2;
            ent3.GetComponent<LightVertical>().Entangled2 = ent2;
            ent1.GetComponent<LightVertical>().Entangled4 = ent4;
            ent3.GetComponent<LightVertical>().Entangled4 = ent4;




            ent2.GetComponent<HorizontalMove>().Entangled1 = ent1;
            ent2.GetComponent<HorizontalMove>().Entangled3 = ent3;
            ent4.GetComponent<HorizontalMove>().Entangled1 = ent1;
            ent4.GetComponent<HorizontalMove>().Entangled3 = ent3;



            // ent3.GetComponent<HorizontalMove>().Update();
            // ent4.GetComponent<HorizontalMove>().Update();







            Destroy(this);
            Destroy(gameObject);

        }


        else
        {



            if (intersecting.Length == 0)
            {



                ent1 = Instantiate(LightModel, new Vector3(x, y, z), transform.rotation);
                ent1.GetComponent<LightVertical>().enabled = true;

                ent1.GetComponent<LightVertical>().setPreviousPos(transform.position);


            }
            else
            {
                GameObject entangled = intersecting[0].gameObject;
                if (entangled.GetComponent<LightVertical>().gameObject != null)
                {


                    ent1 = Instantiate(LightModel, new Vector3(x, y, z), transform.rotation);
                    ent1.GetComponent<LightVertical>().enabled = true;
                    if ((entangled.GetComponent<LightVertical>().enabled == true))
                    {
                        ent1.GetComponent<LightVertical>().Entangle(entangled);
                        entangled.GetComponent<LightVertical>().Entangle(ent1);
                    }
                }
            }








            if (intersecting2.Length == 0)
            {



                ent2 = Instantiate(LightModel, new Vector3(x, y, z), transform.rotation);
                ent2.GetComponent<HorizontalMove>().enabled = true;

                ent2.GetComponent<HorizontalMove>().setPreviousPos(transform.position);


            }
            else
            {
                GameObject entangled = intersecting2[0].gameObject;
                if (entangled.GetComponent<HorizontalMove>().gameObject != null)
                {


                    ent2 = Instantiate(LightModel, new Vector3(x2, y2, z2), transform.rotation);
                    ent2.GetComponent<HorizontalMove>().enabled = true;
                    if (entangled.GetComponent<HorizontalMove>().enabled == true)
                    {
                        ent2.GetComponent<HorizontalMove>().Entangle(entangled);
                        entangled.GetComponent<HorizontalMove>().Entangle(ent2);
                    }

                }
            }



            if (intersecting3.Length == 0)
            {



                ent3 = Instantiate(LightModel, new Vector3(x3, y3, z3), transform.rotation);
                ent3.GetComponent<LightVertical>().enabled = true;

                ent3.GetComponent<LightVertical>().setPreviousPos(transform.position);


            }
            else
            {
                GameObject entangled = intersecting3[0].gameObject;
                if (entangled.GetComponent<LightVertical>().gameObject != null)
                {


                    ent3 = Instantiate(LightModel, new Vector3(x3, y3, z3), transform.rotation);
                    ent3.GetComponent<LightVertical>().enabled = true;
                    if ((entangled.GetComponent<LightVertical>().enabled == true))
                    {
                        ent3.GetComponent<LightVertical>().Entangle(entangled);
                        entangled.GetComponent<LightVertical>().Entangle(ent2);

                    }
                }
            }



            if (intersecting4.Length == 0)
            {



                ent4 = Instantiate(LightModel, new Vector3(x4, y4, z4), transform.rotation);
                ent4.GetComponent<HorizontalMove>().enabled = true;

                ent4.GetComponent<HorizontalMove>().setPreviousPos(transform.position);


            }
            else
            {
                GameObject entangled = intersecting4[0].gameObject;
                if (entangled.GetComponent<HorizontalMove>().gameObject != null)
                {


                    ent4 = Instantiate(LightModel, new Vector3(x4, y4, z4), transform.rotation);
                    ent4.GetComponent<HorizontalMove>().enabled = true;
                    if (entangled.GetComponent<HorizontalMove>().enabled == true)
                    {
                        ent4.GetComponent<HorizontalMove>().Entangle(entangled);
                        entangled.GetComponent<HorizontalMove>().Entangle(ent4);
                    }

                }
            }


            //obj.EntangledLightStep = obj.frames; 


            /*







                 UnityEngine.Collider[] intersecting2 = Physics.OverlapSphere(new Vector3(x2, y2, z2), 0.01f);
            if (intersecting2.Length == 0)
            {

                ent2 = Instantiate(LightModel, new Vector3(x2, y2, z2), transform.rotation);
                ent2.GetComponent<LightVertical>().enabled = true;
                ent2.GetComponent<LightVertical>().setPreviousPos(transform.position);


            }

            else {
                GameObject entangled = intersecting2[0].gameObject;

            if (entangled.GetComponent<LightVertical>().gameObject != null) { 


                      Destroy(entangled);


                   ent2 = Instantiate (EntangledModel, new Vector3(x2, y2, z2), transform.rotation); 
                     ent2.GetComponent<EntangledMove>().enabled = true;  
                  }

            UnityEngine.Collider[] intersecting3 = Physics.OverlapSphere(new Vector3(x3, y3, z), 0.01f);
            if (intersecting3.Length == 0)
            {
                    ent3 = Instantiate(LightModel, new Vector3(x2, y2, z2), transform.rotation);
                    ent3.GetComponent<LightVertical>().enabled = true;
                    ent3.GetComponent<LightVertical>().setPreviousPos(transform.position);


                }

                else
                {
                    GameObject entangled = intersecting2[0].gameObject;

                    if (entangled.GetComponent<LightVertical>().gameObject != null)
                    {


                        Destroy(entangled);


                        ent2 = Instantiate(EntangledModel, new Vector3(x2, y2, z2), transform.rotation);
                        ent2.GetComponent<EntangledMove>().enabled = true;

                    }

            UnityEngine.Collider[] intersecting4 = Physics.OverlapSphere(new Vector3(x4, y4, z4), 0.01f);
            if (intersecting4.Length == 0)
            {

            }

             */





        }

    }
}

