using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SphereWantToRoll : MonoBehaviour {

    public static float rollSpeed = 5f;
    public static float ballVision = 5f;
    public float stopDelay = 5f;
    public float slowCheckInterval = 1f;
    public float minSpeed = 10f;
    public float breakPower = 3f;
    public bool isCombined = false;
    public float rotationDelay = 0.1f;
    public float torqueAmount = 100f;


    private Rigidbody rb;
    private Vector3 rollPower;
    private float elapsedTime;
    private float elapsedTimeForBreak;
    private Vector3 moveDirection;

    private Vector3 oldPosition;
    private Vector3 newPosition;
    private Vector3 forceVector;
    private Vector3 torqueVector;
    private Light spotLight;





    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        spotLight = GetComponent<Light>();
    }

    // Use this for initialization
    void Start () {
        rb.maxAngularVelocity = 100f;
        spotLight.range = 0;
        spotLight.intensity = 0;
        rollSpeed = 0f;
    }




    void StartToRoll()
    {
        FirstRoll(rollSpeed);
    }


    void FirstRoll(float RollSpeed)
    {
        Vector2 randomVector = new Vector2(1, 1);
        forceVector = new Vector3(randomVector.x * RollSpeed, 0, randomVector.y * RollSpeed);
        Debug.Log(forceVector);
        rb.drag = 0f;
        rb.AddForce(forceVector, ForceMode.Impulse);
    }



    private void FixedUpdate()
    {
        moveDirection = transform.position - oldPosition;
        oldPosition = transform.position;
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        elapsedTimeForBreak += Time.deltaTime;
        if (elapsedTimeForBreak >= stopDelay)
        {
            elapsedTimeForBreak = 0f;
            Break();
        }

        if (IsSlow)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= slowCheckInterval)
            {
                elapsedTime = 0f;
                Roll(rollSpeed);
            }
        }
    }

    public void Break()
    {
        rb.drag = breakPower;
    }

    public void BreakAndRollAgain()
    {
        rb.drag = breakPower * 1000;
        elapsedTimeForBreak = 0f;
        Invoke("RollAgain", 1f);
    }

    void RollAgain()
    {
        Roll(rollSpeed);
    }


    public void Roll(float RollSpeed)
    {
        Vector2 randomVector = Random.insideUnitCircle.normalized;
        forceVector = new Vector3(randomVector.x * RollSpeed, 0, randomVector.y * RollSpeed);
        torqueVector = transform.right * torqueAmount;
        rb.drag = 0f;
        rb.AddForce(forceVector, ForceMode.Impulse);
        // rb.AddTorque(torqueVector, ForceMode.Impulse);
    }

    private bool IsSlow
    {
        get
        {
            return (rb.velocity.sqrMagnitude < minSpeed);
        }
    }

    public void LightUP()
    {
        spotLight.range = ballVision;
        spotLight.intensity = ballVision;
    }
}
