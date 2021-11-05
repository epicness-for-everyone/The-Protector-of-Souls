using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrPath : MonoBehaviour
{
    public Vector3 head;
    public Vector3 tail;
    public GameObject next=null;
    // Start is called before the first frame update
    void Start()
    {
        head= transform.GetChild(1).GetComponent<Transform>().position + transform.position;
        tail= transform.GetChild(2).GetComponent<Transform>().position + transform.position;
    }

    // Update is called once per frame
    //void Update(){}
    //Geters and Seters
    public void setTail(Vector3 obj){
        tail= obj;
    }
    public void setHead(Vector3 obj){
        head= obj;
    }
    public void setNext(GameObject obj){
        next= obj;
    }
    public Vector3 getTail(){
        return tail;
    }
    public Vector3 getTransform(){
        return transform.position;
    }
    public Vector3 getHead(){
        return head;
    }
    public GameObject getNext(){
        return next;
    }
}
