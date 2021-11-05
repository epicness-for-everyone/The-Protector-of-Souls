using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrMovPlayer : MonoBehaviour
{
    public float vel;
    public float velG;
    public bool tmov;
    private CharacterController mov;
    private float hm;
    private float vm; 
    private Vector3 playerMove;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        mov= GetComponent<CharacterController>();
        anim= transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hm= Input.GetAxis("Horizontal");
        vm= Input.GetAxis("Vertical");
        if(tmov){
            playerMove= new Vector3(hm,0,vm);
            playerMove= Vector3.ClampMagnitude(playerMove, 1);
            transform.rotation= Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, playerMove, velG*Time.deltaTime, 0f));
            mov.Move(playerMove*vel*Time.deltaTime);
        }else{
            playerMove= mov.transform.forward * vm;
            mov.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") *( 100f * Time.deltaTime));
            mov.Move(playerMove*vel*Time.deltaTime);
        }
        if(mov.velocity == Vector3.zero){
            anim.SetBool("walk", false);
        }else anim.SetBool("walk", true);
    }
}
