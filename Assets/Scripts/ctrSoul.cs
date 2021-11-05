using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrSoul : MonoBehaviour
{
    public float vel;
    public float velG;
    public Transform target;
    public GameObject PathTarget=null;
    public ctrPath ctrTarget;
    public Animator anim;
    private Vector3 dir;
    private Quaternion angle;
    private int status;
    private float time=10f;
    // Start is called before the first frame update
    void Start()
    {
        anim= transform.GetChild(0).GetComponent<Animator>();
        status= Random.Range(1,3);
    }

    // Update is called once per frame
    void Update()
    {
        /**
        if(Input.GetKeyDown(KeyCode.R)){
            target=null;    
        }
        if(Input.GetKeyDown(KeyCode.T)){
            target= GetComponent<Transform>();
        }
        print(target);
        */
        if(PathTarget==null)  Doing();
        else Walking();
    }
    public void Doing(){
        time+= 1 * Time.deltaTime;
        if(time >= 4f){
            time=0;
            status= Random.Range(1,3);
        }
        switch(status){
            case 1: //idle
                anim.SetBool("walk", false);
                break;
            case 2: //walk 1da parte
                dir= newDirection();
                status= 3;
                break;
            case 3: //walk 2ra parte
                anim.SetBool("walk", true);
                if(Random.Range(0,10)==8) anim.SetTrigger("look");
                transform.rotation= Quaternion.LookRotation(
                        Vector3.RotateTowards(transform.forward, dir - transform.position, velG*Time.deltaTime, 0.0f));
                transform.position= Vector3.MoveTowards(transform.position, dir, vel * Time.deltaTime);
                break;
            default:
                print("Erron");
                break;
        }
        if(Vector3.Distance(dir, transform.position) <= 1f)
            if(Random.Range(0,10)>=5) status=2;
            else status=1;
    }
    public void Walking(){
        time=20;
        anim.SetBool("walk", true);
        if(target==null) target= PathTarget.GetComponent<Transform>();
        if(Vector3.Distance(target.position, transform.position)<=0.1f){
            PathTarget= ctrTarget.next;
            ctrTarget= PathTarget.GetComponent<ctrPath>(); 
            target= PathTarget.GetComponent<Transform>();
        }
        transform.rotation= Quaternion.LookRotation(
                Vector3.RotateTowards(transform.forward, target.position - transform.position, vel*Time.deltaTime, 0.0f));
        transform.position= Vector3.MoveTowards(transform.position, target.position, vel * Time.deltaTime);        
    }
    private Vector3 newDirection(){
        float rndx= Random.Range(-20,20), rndz= Random.Range(-20,20);
        return new Vector3(transform.position.x+rndx, 0f, transform.position.z+rndz);
    }
    private void OnTriggerEnter(Collider obj){
        if(obj.tag=="Path" && PathTarget==null){
            PathTarget= obj.gameObject;
            ctrTarget= PathTarget.GetComponent<ctrPath>();
        }
    }
    //private void OnTriggerExit(Collider obj){
        //if(obj.tag=="Path"){
        //    PathTarget=null;
        //}
    //}
    //movimiento de tipo 1 
    /**public void Move(){ 
        time+= 1 * Time.deltaTime;
        if(time >= 5f){
            time=0;
            status= Random.Range(1,3);
        }
        switch(status){
            case 1: //idle
                anim.SetBool("walk", false);
                break;
            case 2: //Giro
                angle= Quaternion.Euler(0, Random.Range(0,360),0);
                status++;
                break;
            case 3: //movimiento con giro
                transform.rotation= Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                anim.SetBool("walk", true);
                break;
            default:
                print("Erron");
                break;  
        }
    }*/
}
