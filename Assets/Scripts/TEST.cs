using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public Transform snuff;
    public GameObject centerOfTurning;
    public float radiusOfTurning = 5;
    Rigidbody2D rigidbody;
    float force;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0,1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0,0, -((Mathf.Atan2(snuff.position.x - transform.position.x, snuff.position.y - transform.position.y)*180) / Mathf.PI)+90);
        centerOfTurning.transform.position = transform.position + new Vector3(Mathf.Cos((transform.eulerAngles.z * Mathf.PI) / 180) * radiusOfTurning, Mathf.Sin((transform.eulerAngles.z * Mathf.PI) / 180) * radiusOfTurning, 0);
        force = 1 / Vector3.Distance(transform.position, snuff.position);
        rigidbody.AddForce(RotateVector2ByAngle(rigidbody.velocity.normalized, -90f) * force);
        Debug.Log(rigidbody.velocity.magnitude);
        rigidbody.AddRelativeForce(new Vector2(0,Input.GetAxis("Vertical") * 1f));
    }
    Vector2 RotateVector2ByAngle(Vector2 vector, float angle)
    {
        float theta = (angle*Mathf.PI) / 180f;

        float cs = Mathf.Cos(theta);
        float sn = Mathf.Sin(theta);

        float x1 = vector.x * cs - vector.y * sn;
        float y1 = vector.x * sn + vector.y * cs;

        return new Vector2(x1, y1);
    }
    
}
