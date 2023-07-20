using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collision : MonoBehaviour
{
    
    //private Transform cubePrefab;
    public GameObject cross;
    public GameObject rightSphere;
    public GameObject leftSphere;
    public GameObject cylinder;

    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public TMP_Text text4;
    public TMP_Text text5;
    public TMP_Text text6;
    public TMP_Text text7;



    public void Start()
    {
        
        cross = GameObject.Find("target");
        rightSphere = GameObject.Find("end_point");
        leftSphere = GameObject.Find("start_point");


        text1 = GameObject.Find("text1").GetComponentInChildren<TMP_Text>();
        text2 = GameObject.Find("text2").GetComponentInChildren<TMP_Text>();
        text3 = GameObject.Find("text3").GetComponentInChildren<TMP_Text>();
        text4 = GameObject.Find("text4").GetComponentInChildren<TMP_Text>();
        text5 = GameObject.Find("text5").GetComponentInChildren<TMP_Text>();
        text6 = GameObject.Find("text6").GetComponentInChildren<TMP_Text>();
        text7 = GameObject.Find("text7").GetComponentInChildren<TMP_Text>();
        
        cross.SetActive(false);
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "skin_mirror")
        {
            //Debug.Log("Collision skin");
            cylinder = GameObject.Find("Cylinder(Clone)");


            //Instantiate<GameObject>(cubePrefab.gameObject, collision.contacts[1].point, Quaternion.identity);
            cross.SetActive(true);
            cross.transform.position = collision.contacts[1].point;
            Debug.Log(cylinder.transform.localEulerAngles);
            cross.transform.LookAt(cylinder.transform);
           
            //Debug.Log(globalPositionOfContact);



        }




    }

    private void OnTriggerEnter(Collider collision)
    {
        
        
        if (collision.gameObject.name == "bone_mirror") { Debug.Log("bone coll"); text1.text = "Detected collision with: RIBS"; }

        if (collision.gameObject.name == "aorta_mirror") { text2.text = "Detected collision with: AORTA"; }

        if (collision.gameObject.name == "Coronary_mirror") { text3.text = "Detected collision with: CORONARY"; }

        if (collision.gameObject.name == "diaphragm_mirror") { text4.text = "Detected collision with: DIAPHRAGM"; }

        if (collision.gameObject.name == "liver_mirror") { text5.text = "Detected collision with: LIVER"; }

        if (collision.gameObject.name == "lung_mirror") { text6.text = "Detected collision with: LUNG"; }

        if (collision.gameObject.name == "stomach_mirror") { text7.text = "Detected collision with: STOMACH"; }


    }

    private void OnTriggerExit(Collider collision)
    {


        text1.text = "";

        text2.text = ""; 

        text3.text = ""; 

        text4.text = ""; 

        text5.text = ""; 

        text6.text = ""; 

        text7.text = ""; 


    }






}
