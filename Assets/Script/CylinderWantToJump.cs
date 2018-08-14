using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderWantToJump : MonoBehaviour {

    public float forcePower = 10;
    public float jumpDelay = 1f;
    public float minSpeed = 2.5f;

    private Rigidbody rb;
    private Vector3 forceVector;
    private float elapsedTime;

    // Use this for initialization

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= jumpDelay)
        {
            elapsedTime = 0f;
            if (IsStopped)
            {
                // JumpUP(forcePower);
            }
        }
    }

    void JumpUP(float jumpPower)
    {
        forceVector = Vector3.up;
        forceVector = Vector3.Scale(forceVector, new Vector3(0, jumpPower, 0));
        rb.AddForce(forceVector, ForceMode.Impulse);
    }

    private bool IsStopped
    {
        get
        {
            // return (rb.velocity.sqrMagnitude < .0001f && rb.angularVelocity.sqrMagnitude < .0001f) ;
            return (Mathf.Abs(rb.velocity.y) < minSpeed);
        }
    }
}
