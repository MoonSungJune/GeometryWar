using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFollow : MonoBehaviour {


    private bool isFollowing = false;
    public float combineDistance = 1.5f;
    public float dampSpeed = 3;


    private Vector3 myPosition;
    private Vector3 targetPosition;
    private Transform followingTarget;
    private LineRenderer lineRenderer;



    // Use this for initialization
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.yellow;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            FollowTarget();
            RenderLink();
        }
    }


    void RenderLink()
    {
        lineRenderer.enabled = true;
        myPosition = transform.position;
        targetPosition = followingTarget.position;
        lineRenderer.SetPosition(0, myPosition);
        lineRenderer.SetPosition(1, targetPosition);
    }


    void FollowTarget()
    {
        Vector3 heading = followingTarget.position - transform.position;

        if (heading.sqrMagnitude > combineDistance)
        {
            transform.position = Vector3.Lerp(transform.position, followingTarget.position, Time.deltaTime * dampSpeed);
        }
        transform.LookAt(followingTarget);
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name != "wall" && collider.name != "bottom")
        {
            if (!isFollowing)
            {
                if (collider.tag == "Move")
                {
                    Renderer rend = GetComponent<Renderer>();
                    Color cubeColor = new Vector4(.9f, .6f, .05f, 1);
                    isFollowing = true;
                    rend.material.SetColor("_Color", cubeColor);
                    followingTarget = collider.transform;
                }
            }
        }
    }
}
