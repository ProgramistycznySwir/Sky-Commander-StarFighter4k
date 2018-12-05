using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    public GameObject rearExhaustSprite, frontExhaustSprite;
    public Rigidbody2D rigidbody;
    public GameObject centerOfTurning;
    public float forwardSpeed, backwardSpeed;
    public float anchorPower;

    float exhaustVisability;
    float radiusOfTurning;
    float changeRotationBy;
    bool firstIteration = true;


    void Start()
    {
        rearExhaustSprite.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

        radiusOfTurning = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (0 < Input.GetAxis("Vertical"))
        {
            rigidbody.AddRelativeForce(new Vector2(0, forwardSpeed));
            exhaustVisability += 0.2f;
        }
        else exhaustVisability -= 0.1f;
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

        if (0 > Input.GetAxis("Horizontal"))
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 1f);
            //transform.Rotate(0, 0, 1);
        }
        else if (0 < Input.GetAxis("Horizontal"))
        {
            radiusOfTurning = (rigidbody.mass * rigidbody.velocity.sqrMagnitude) / anchorPower;
            rigidbody.AddRelativeForce(new Vector2(anchorPower/2, 0));
            
            if (!firstIteration)
            {
                transform.eulerAngles = new Vector3(0, 0, -((Mathf.Atan2(centerOfTurning.transform.position.x - transform.position.x, centerOfTurning.transform.position.y - transform.position.y) * 180) / Mathf.PI) + 90);
                centerOfTurning.transform.position = transform.position + new Vector3(Mathf.Cos((transform.eulerAngles.z * Mathf.PI) / 180) * radiusOfTurning, Mathf.Sin((transform.eulerAngles.z * Mathf.PI) / 180) * radiusOfTurning, 0);
            }
            else // pierwsza iteracja
            {
                centerOfTurning.transform.position = transform.position + new Vector3(Mathf.Cos((transform.eulerAngles.z * Mathf.PI) / 180) * radiusOfTurning, Mathf.Sin((transform.eulerAngles.z * Mathf.PI) / 180) * radiusOfTurning, 0);                transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(transform.position, centerOfTurning.transform.position) + 90);
                transform.eulerAngles = new Vector3(0, 0, -((Mathf.Atan2(centerOfTurning.transform.position.x - transform.position.x, centerOfTurning.transform.position.y - transform.position.y) * 180) / Mathf.PI) + 90);//new Vector3(0, 0, Vector3.Angle(transform.position, centerOfTurning.transform.position) + 90);
                firstIteration = false;
            }
            

            rigidbody.AddRelativeForce(new Vector2(anchorPower/2, 0));
            //transform.Rotate(new Vector3(0,0,-1));
            //transform.RotateAround(centerOfTurning.transform.position, new Vector3(0,0,-1), 1f);
        }
        else firstIteration = true;
        Debug.Log(rigidbody.velocity + " / " + rigidbody.velocity.magnitude + " / " + transform.rotation.eulerAngles);
    }
}
