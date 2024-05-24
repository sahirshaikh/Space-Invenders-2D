using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCode : MonoBehaviour
{
    //--------------Hide public variable in inspector-----------
    [HideInInspector]public int life=5;


    int P =1;
    int speed=20;
    public GameObject Cube2;
    public GameObject[] Cube3;
    public GameObject Ball;
    Vector3 pos;
    Vector3 rot;

    public int speed1;

    Rigidbody RB;
    BoxCollider BC;



    ///----------------Array-----------
    public int[] Arr;

    void Awake()
    {

        
    }

    //------------------On collision Enter------------------------------

    // private void OnCollisionEnter(Collision other) {
    //     Debug.Log("Collision Happend");

    //     if (other.gameObject.tag == "Floor")
    //     {
    //         Destroy(other.gameObject);
    //     }
    // }


    //----------------- OnTriggerEnter---------------------------

    // private void OnTriggerEnter(Collider other) {
    //     Debug.Log("Trigger Happend");
    //     if (other.gameObject.tag == "Floor")
    //     {
    //         Destroy(other.gameObject);
    //     }
    // }


    // Start is called before the first frame update
    void Start()
    {

        // //------------------------Get Component---------------------------

        // RB = GetComponent<Rigidbody>();
        // RB.velocity = new Vector3(1,0,0);
        // Destroy(RB);

        // BC = GetComponent<BoxCollider>();

        // BC.enabled=false;

        









        pos = new Vector3(4, 2,0);
        rot = new Vector3(0, 0,0);

        // StartCoroutine(Test(2f));



        // //-----------------Find With Tag-------------- Single Object
        // Cube2 = GameObject.FindWithTag("Cube2");
        // Destroy(Cube2);




        // //---------------Find Multiple object with tags--------------

        // Cube3 = GameObject.FindGameObjectsWithTag("Cube2");

        // foreach(GameObject r in Cube3)
        // {
        //     Destroy(r.gameObject);
        // }



        // //-----------------Instatiate once ------------
        // Instantiate(Ball,pos,transform.rotation);



        // //----------------Instantiate After interval of time-----------------

        // InvokeRepeating("Inst",1f,1f);






        // //---------Foreach loop-------------
        // //---- it is helpful for array -- to find value in array-----

        // foreach(int i in Arr)
        // {
        //     Debug.Log(i);
        // }



        //----------------------------------------
        // //Destroy after time interval
        // Destroy(gameObject,3f);

        //------------------------------------------------

        // //Funstion with parameter
        // int a = Shoot(5);
        // Debug.Log(a);

    //     //--------While Loop--------------------------------------------
    // //While(true){Body of code}
    
    // while(P<5)
    //     {
    //         Debug.Log("Value of power: "+P);
    //         P++;
    //     }
    //     Debug.Log("Out of loop");




    // //----------------for Loop-------------------
    // //for(initialization;Condition;Increment)

    // for(int i=0;i<5;i++)
    // {
    //     Debug.Log("Value of i: "+i);

    // }
    // Debug.Log("Out of For Loop");



    }

    // IEnumerator Test(float Time)
    // {
    //     Debug.Log("Couroutine Started");
    //     yield return new WaitForSeconds(Time);
    //     Debug.Log("Couroutine Ended");

    // }

    // void Inst()
    // {
    //     Instantiate(Ball,pos,transform.rotation);
    // }

    // Update is called once per frame
    void Update()
    {


        // //--------------Input GetKey----------------------
        // if(Input.GetKeyDown(KeyCode.Escape))
        // {
        //     Inst();
        // }

        // //-----------Input GetButtonDown   using name that specify in Input   ----------------

        // if(Input.GetButtonDown("Jump"))
        // {
        //     Inst();
        // }

        // //-----------Input using Mouse---------------------------

        // if(Input.GetButtonDown("Fire1")) //----- left mouse button
        // {
        //     Inst();
        // }

        // //---------------------Input Using Mouse button----- 0 1 2------------------
        // if(Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("Left Mouse button");
        //     Vector3 mousePos = Input.mousePosition;
        //     Debug.Log(mousePos.x);
        //     Debug.Log(mousePos.y);
            
        // }

        //         if(Input.GetMouseButtonDown(1))
        // {
        //     Debug.Log("Right Mouse button");
        // }

        //         if(Input.GetMouseButtonDown(2))
        // {
        //     Debug.Log("Middle Mouse button");
        // }


        // //----------------------------Input Getaxis-----------------------------

        // float x = Input.GetAxis("Horizontal")*speed1*Time.deltaTime;
        // float y = Input.GetAxis("Vertical")*speed1*Time.deltaTime;

        // transform.Translate(x,y,0);



        //--------------------------------------------Transform-----------------------------

        //-------Vector2 stores 2 value ---where as vector3 store 3 values--------- Vector4 stores 4 Values----------------

        // Vector3 pos = transform.position;

        // pos.x+=0.5f*Time.deltaTime;
        // transform.position = pos;


        //----------------Translate------------------
        // transform.Translate(0,speed*Time.deltaTime,0);

        // //----------------Rotate---------------
        // transform.Rotate(speed*Time.deltaTime,0f,0f);

        // //----------------Local Scale-----------------
        //     Vector3 scale = transform.localScale;
        //     scale.x+=5f*Time.deltaTime;
        //     transform.localScale=scale;

        // //------------------Tag--------------------------
        // if(this.gameObject.tag =="Cube")
        // {
        //     Debug.Log("Its Cube");

        // }



        //--------Time.deltaTime---------------------

        //-    Time.deltaTime= 1 /fps--------- so will get equal unit moves per second------  Def: amount of time took to render last frame------------

        // //--------------if else-----------------------------------------------
        // if(life>0)
        // {
        //     Debug.Log("Playing");

        // }
        // else
        // {
        //     Debug.Log("Dead");
        // }








        
    }

    // //--------------Getting return from function-------------
    // int Shoot(int P)
    // {
    //     Debug.Log(P);
    //     return(P*2);
    // }

    private void OnCollisionEnter(Collision other) {

        GetComponent<MeshRenderer>().material.color = Color.red;
        
    }


    


}
