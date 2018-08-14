using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour {

    public Transform target;
    public float distancFromTarget = 7f;
    public float height = 5f;
    public float dampRate = 1f;



	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (transform != null && target != null)
        {
            transform.position = target.position - (Vector3.forward * distancFromTarget) + (Vector3.up * height);
            transform.LookAt(target);
        }

        //Vector3 offset = target.position - transform.position;

        //if (offset.sqrMagnitude > distancFromTarget)
        //{

        //    transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * dampRate);

        //}
        //target.position = new Vector3(target.position.x, target.position.y, height);
        //target.position = target.position - (Vector3.forward * distancFromTarget);
        //float curAngleY = Mathf.LerpAngle(transform.eulerAngles.y, target.eulerAngles.y, dampRate * Time.deltaTime);
        //Quaternion rot = Quaternion.Euler(0, curAngleY, 0);
        //transform.position = target.position - (rot * Vector3.forward * distancFromTarget) + (Vector3.up * height);

        
        
    }
}
