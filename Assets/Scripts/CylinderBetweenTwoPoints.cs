using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CylinderBetweenTwoPoints : MonoBehaviour
{
    [SerializeField]
    private Transform cylinderPrefab;

    public GameObject leftSphere;
    public GameObject rightSphere;
    public GameObject cylinder;
    public GameObject needle;
    public GameObject needle_tip;
    public GameObject cross;
    public bool flag = false;
    static public bool flag_perf = false;
    public collision checking;
    public Vector3 starting_point = Vector3.zero;
    



    public void Start()
    {
        //leftSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //rightSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //leftSphere.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        //rightSphere.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        rightSphere = GameObject.Find("end_point");
        leftSphere = GameObject.Find("start_point");
        needle = GameObject.Find("Needle");
        needle_tip = GameObject.Find("Needle_tip");
        cross = GameObject.Find("target");

        leftSphere.SetActive(false);
        cross.SetActive(false);
        needle_tip.SetActive(false);
        //leftSphere.transform.position = new Vector3(0.2f, 0.0f, 0.0f);
        //rightSphere.transform.position = new Vector3(0.2f, 0.5f, 0.0f);


    }

    public void pre_plan()
    {

        destroy();
        leftSphere.SetActive(false);

        do
        {

           starting_point = Random.onUnitSphere * 0.2f + rightSphere.transform.position;
           //Debug.Log(Physics.Linecast(rightSphere.transform.position, starting_point));

        } while(Physics.Linecast(rightSphere.transform.position, starting_point));

        //Debug.Log(Physics.Linecast(rightSphere.transform.position, starting_point));
        leftSphere.SetActive(true);
        leftSphere.transform.position = starting_point;
        //Debug.DrawLine(rightSphere.transform.position, leftSphere.transform.position);
        InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position);
        
        flag = true;
    }

    

   
    public void destroy()
    {   

        Destroy(cylinder);
        leftSphere.SetActive(false);
        flag = false;
        flag_perf = false;
    }


    private void FixedUpdate()
    {
        if (flag == true)
        {   
            UpdateCylinderPosition(cylinder, leftSphere.transform.position, rightSphere.transform.position);
            
        }

    }


    public void InstantiateCylinder(Transform cylinderPrefab, Vector3 beginPoint, Vector3 endPoint)
    {

        cylinder = Instantiate<GameObject>(cylinderPrefab.gameObject, Vector3.zero, Quaternion.identity);
        cylinder.GetComponent<MeshRenderer>().material.color = Color.green;
        cross.SetActive(true);
        needle_tip.SetActive(true);
        needle_tip.transform.position = endPoint;
        flag = true;
    }

    public void UpdateCylinderPosition(GameObject cylinder, Vector3 beginPoint, Vector3 endPoint)
    {
        Vector3 offset = (endPoint - beginPoint);
        Vector3 position = beginPoint - (offset/2);

        cylinder.transform.position = position;
        cylinder.transform.LookAt(beginPoint);
        Vector3 localScale = cylinder.transform.localScale;
        localScale.y = ((endPoint - beginPoint)+ offset/2).magnitude;
        localScale.x = 0.001f;
        localScale.z = 0.001f;

        cylinder.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
       
        cylinder.transform.localScale = localScale;
        needle_tip.transform.LookAt(cylinder.transform);
        

    }

    

}