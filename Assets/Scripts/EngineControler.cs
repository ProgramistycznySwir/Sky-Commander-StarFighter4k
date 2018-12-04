using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EngineControler : MonoBehaviour
{
    [Header("RigidBody Socket:")]
    [Tooltip("Rigidbody of object.")]
    public new Rigidbody2D rigidbody;

    [Header("Engines Power:")]
    [Tooltip("Power of Rear Engines (and RCS).")]
    public float forwardPower;
    [Tooltip("Power of Front Engines (and RCS).")]
    public float backwardPower;

    [Header("Engine Sprites Sockets:")]
    public GameObject rearEngines;
    public GameObject frontEngines;
    public GameObject rearRCS; 
    public GameObject frontRCS;
        
    [Header("Engine Sprites Settings:")]
    [Tooltip("Time (in frames) that takes to Rear Engines exhaust to turn fully visible, after start of acceleration.")]
    public float rearExhausBuildup;
    [Tooltip("Time (in frames) that takes to Rear Engines exhaust to turn fully invisible, after end of acceleration.")]
    public float rearExhaustThreshold; //how many frames
    [SerializeField]
    [Tooltip("Current state of visibility of Rear Engines exhaust.")]
    float rearExhaustVisability;
    [Space(5)]
    [Tooltip("Time (in frames) that takes to Front Engines exhaust to turn fully visible, after start of acceleration.")]
    public float frontExhausBuildup;
    [Tooltip("Time (in frames) that takes to Front Engines exhaust to turn fully invisible, after end of acceleration.")]
    public float frontExhaustThreshold;
    [SerializeField]
    [Tooltip("Current state of visibility of Front Engines exhaust.")]
    float frontExhaustVisability;

    bool acceleratedThisFrame = false, deacceleratedThisFrame = false;


    /// Turning variables;
    [Header("Turning Sockets:")]
    [Tooltip("Sprite (actually prefab) that indicates center of turning circle that makes spacecraft.")]
    public GameObject centerOfTurningIndicator;

    [Header("Turning Settings:")]
    [Tooltip("Power with which spacecraft is pulled toward centerOfTurningCircle (bigger the force, closer the turn).")]
    public float anchorPower;
    Vector2 centerOfTurning;
    Vector2 forceDirrection;
    bool turningLeft = false, turningRight = false;
    bool startedTurningLeft = false, startedTurningRight = false;

    float velocityOnTurningStart;  // leczenie objawowe :/


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (acceleratedThisFrame)
        {
            rearExhaustVisability += 1 / rearExhausBuildup;
        }
        else rearExhaustVisability -= 1 / rearExhaustThreshold;
        if (rearEngines != null)
        {
            if (rearExhaustVisability < 0) rearExhaustVisability = 0;
            else if (rearExhaustVisability > 1) rearExhaustVisability = 1;
            rearEngines.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, rearExhaustVisability);            
        }

        if (deacceleratedThisFrame)
        {
            frontExhaustVisability += 1 / frontExhausBuildup;
        }
        else frontExhaustVisability -= 1 / frontExhaustThreshold;
        if (frontEngines != null)
        {
            if (frontExhaustVisability < 0) frontExhaustVisability = 0;
            else if (frontExhaustVisability > 1) frontExhaustVisability = 1;
            frontEngines.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, frontExhaustVisability);
        }

        if (frontRCS != null)
        {
            frontRCS.SetActive(deacceleratedThisFrame);
        }
        if (rearRCS != null)
        {
            rearRCS.SetActive(acceleratedThisFrame);
        }
        
        acceleratedThisFrame = false;
        deacceleratedThisFrame = false;

        if (!turningLeft && !startedTurningLeft)
        {
            startedTurningLeft = true;
            rigidbody.velocity = transform.up * Mathf.Sqrt(velocityOnTurningStart); //to też jest leczeniem objawowym
            rigidbody.angularVelocity = 0f; // leczenie objawowe
        }
        turningLeft = false;
        if (!turningRight && !startedTurningRight)
        {
            startedTurningRight = true;
            rigidbody.velocity = transform.up * Mathf.Sqrt(velocityOnTurningStart); //i to
            rigidbody.angularVelocity = 0f; //oraz to <-
        }
        turningRight = false;
    }

    public void Accelerate()
    {
        rigidbody.AddRelativeForce(new Vector2(0, forwardPower));
        acceleratedThisFrame = true;
    }
    public void Deaccelerate()
    {
        rigidbody.AddRelativeForce(new Vector2(0, -backwardPower));
        deacceleratedThisFrame = true;
    }
    public void TurnLeft()
    {
        if (startedTurningLeft)
        {
            velocityOnTurningStart = rigidbody.velocity.sqrMagnitude;
            float radiusOfTurning = (rigidbody.mass * rigidbody.velocity.sqrMagnitude) / anchorPower;            

            centerOfTurning = transform.position + new Vector3(Mathf.Cos((transform.eulerAngles.z * Mathf.PI) / 180) * -radiusOfTurning, Mathf.Sin((transform.eulerAngles.z * Mathf.PI) / 180) * -radiusOfTurning, 0);
            
            centerOfTurningIndicator.transform.position = centerOfTurning;
            Debug.Log(forceDirrection);
            startedTurningLeft = false;
        }
        
        forceDirrection = centerOfTurning - ToVector2(transform.position);
        rigidbody.AddForce(forceDirrection.normalized*anchorPower);
        transform.eulerAngles = new Vector3(0, 0, -((Mathf.Atan2(forceDirrection.x, forceDirrection.y) * 180) / Mathf.PI) - 90);

        turningLeft = true;
    }
    public void TurnRight()
    {
        if (startedTurningRight)
        {
            velocityOnTurningStart = rigidbody.velocity.sqrMagnitude;
            float radiusOfTurning = (rigidbody.mass * rigidbody.velocity.sqrMagnitude) / anchorPower;

            centerOfTurning = transform.position + new Vector3(Mathf.Cos((transform.eulerAngles.z * Mathf.PI) / 180) * radiusOfTurning, Mathf.Sin((transform.eulerAngles.z * Mathf.PI) / 180) * radiusOfTurning, 0);

            centerOfTurningIndicator.transform.position = centerOfTurning;
            Debug.Log(forceDirrection);
            startedTurningRight = false;            
        }

        forceDirrection = centerOfTurning - ToVector2(transform.position);
        rigidbody.AddForce(forceDirrection.normalized * anchorPower);
        transform.eulerAngles = new Vector3(0, 0, -((Mathf.Atan2(forceDirrection.x, forceDirrection.y) * 180) / Mathf.PI) + 90);

        turningRight = true;
    }
    public static Vector2 ToVector2(Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.y);
    }
}
/*else exhaustVisability -= 0.1f;
        if (0 > Input.GetAxis("Vertical"))
        {
            rigidbody.AddRelativeForce(new Vector2(0, -backwardSpeed));
            frontExhaustSprite.SetActive(true);
        }
        else frontExhaustSprite.SetActive(false);
        if (exhaustVisability < 0)
        {
            exhaustVisability = 0;
        }
        else if (exhaustVisability > 1)
        {
            exhaustVisability = 1;
        }
        rearExhaustSprite.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, exhaustVisability);
*/     
