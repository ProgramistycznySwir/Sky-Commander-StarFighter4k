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

    [Header("RCS Sprites Sockets:")]
    public SpriteRenderer rearRCS;
    public SpriteRenderer frontRCS;

    [Header("Engine exhaust animation Settings:")]
    public ExhaustAnimation rearExhaust;
    public ExhaustAnimation frontExhaust;

    bool acceleratedThisFrame = false, deacceleratedThisFrame = false;


    [Header("Turning Settings:")]
    public float stunDuration = 1f;
    [SerializeField]
    public float stun;

    public float turningSpeed = 1;

    public float maxVelocity = 10f;
    const float dragWhenSpeeding = 1;


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag != "projectile")
            stun = stunDuration;
    }


    // Update is called once per frame
    void Update()
    {
        rearExhaust.Animate(acceleratedThisFrame);
        frontExhaust.Animate(deacceleratedThisFrame);

        if (frontRCS != null)
            frontRCS.gameObject.SetActive(deacceleratedThisFrame);
        if (rearRCS != null)
            rearRCS.gameObject.SetActive(acceleratedThisFrame);

        acceleratedThisFrame = false;
        deacceleratedThisFrame = false;

        if(stun > 0)
            stun -= Time.deltaTime;

        // rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVelocity);
        rigidbody.drag = rigidbody.velocity.magnitude > maxVelocity ? dragWhenSpeeding : 0f;
    }

    public void Accelerate(float input)
    {
        rigidbody.AddRelativeForce(new Vector2(0, (input > 0 ? forwardPower : backwardPower) * input));
        acceleratedThisFrame = (input > 0);
        deacceleratedThisFrame = (input < 0);
    }
    public void Turn(float input)
    {
        if(!(stun > 0))
            rigidbody.angularVelocity = -input * turningSpeed;
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

[System.Serializable]
public struct ExhaustAnimation
{
    [Tooltip("Rate (1/[time in seconds]) at which Engine's exhaust turns visible.")]
    public float buildupRate;
    [Tooltip("Rate (1/[time in seconds]) at which Engine's exhaust turns invisible.")]
    public float decayRate;
    [Tooltip("Current state of visibility of Engine's exhaust.")]
    public float visability;

    [Tooltip("Animated engine exhaust.")]
    public SpriteRenderer sprite;

    public void Animate(bool acceleratedThisFrame)
    {
        if(sprite == null)
            return;
        visability = Mathf.Clamp01(visability + (acceleratedThisFrame ? buildupRate : -decayRate) * Time.deltaTime);
        sprite.color = new Color(1, 1, 1, visability);
    }
}
