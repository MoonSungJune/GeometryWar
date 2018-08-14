using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour {

    public AnimationCurve animCurve;
    public float durationTime = 1.6f;

    [Range(0.0f, 2.0f)]
    public float t;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t>=durationTime)
        {
            t = 0;
        }
        float y = animCurve.Evaluate(t);
        transform.localScale = new Vector3(3*y, y, 3*y);
	}
}
