using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrMovPlayer : MonoBehaviour
{
    public CharacterController mov;
    public float vel;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        mov= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        dir= new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        mov.Move(dir*vel*Time.deltaTime);
    }
}
