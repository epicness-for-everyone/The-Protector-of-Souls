using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrCamera : MonoBehaviour
{
    public Transform obj;
    [Range (0,1)]public float smooth;
    private Vector2 vel;
    // Start is called before the first frame update
    void Start()
    {
        obj= obj.GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        float posx= Mathf.SmoothDamp(transform.position.x, obj.position.x, ref vel.x, smooth);
        float posz= Mathf.SmoothDamp(transform.position.z, obj.position.z-5, ref vel.y, smooth);
        transform.position = new Vector3(posx, transform.position.y, posz);
    }
}
