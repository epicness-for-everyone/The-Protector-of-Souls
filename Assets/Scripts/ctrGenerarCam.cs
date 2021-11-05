using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrGenerarCam : MonoBehaviour
{
    public GameObject Camino;
    public bool relace;
    public float d; //distancia
    private Vector3 posP;
    public GameObject Next= null;
    private ctrPath ctrNext;
    public GameObject Tail= null;
    private ctrPath ctrTail;
    //private float dist=;
    // Start is called before the first frame update
    void Start()
    {
        posP= transform.position;
        relace=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            relace= !relace;
            posP= transform.position;
        }
        if(relace){
            if(d<=Vector3.Distance(posP, transform.position)){
                posP=transform.position;
                Vector3 lugar = new Vector3(transform.position.x, Camino.transform.position.y, transform.position.z);
                Tail= Next;
                Next= Instantiate(Camino, lugar, transform.localRotation);
                if(Tail != null) Assign();
                else Tail=Next;
            }
        }
    }
    public void Assign(){
        ctrNext= Next.GetComponent<ctrPath>();
        ctrTail= Tail.GetComponent<ctrPath>();
        ctrTail.setHead(ctrNext.getTail());
        ctrTail.setNext(Next);
    }
}
