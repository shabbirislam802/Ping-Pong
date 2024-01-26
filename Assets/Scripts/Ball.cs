using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxStartSpeed= 3f;
    public float minSpeed = 2f;
    public float maxSpeed = 10f;
    public float collisionVelocityMultiplier = 1.1f;

    public Rigidbody rb;

    private Collider lastHitCollider = null;

    private float hitTime = -1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 initForceDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        float initForceMagnitude = Random.Range(minSpeed, maxStartSpeed);
        rb.AddForce(initForceDirection * initForceMagnitude, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != this.lastHitCollider && Time.time > this.hitTime)
        {
            var velocity = this.rb.velocity;
            velocity *= this.collisionVelocityMultiplier;
            var contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, velocity) < 0.0f)
            {
                velocity = Vector3.Reflect(velocity, contact.normal);
            }

            if (velocity.magnitude > this.maxSpeed)
            {
                velocity *= (this.maxSpeed / velocity.magnitude);
            }

            float velocityXAbs = Mathf.Abs(velocity.x);
            if (velocityXAbs < this.minSpeed && velocityXAbs != 0)
            {
                Debug.Log(velocity.x);
                velocity.x *= (this.minSpeed / velocityXAbs);
            }
            else if (Mathf.Approximately(velocityXAbs, 0))
            {
                velocity.x += Random.Range(-this.minSpeed, this.minSpeed);
            }

            float velocityYAbs = Mathf.Abs(velocity.y);
            if (velocityYAbs < this.minSpeed && velocityYAbs != 0)
            {
                Debug.Log(velocity.y);
                velocity.y *= (this.minSpeed / velocityYAbs);
            }
            else if (Mathf.Approximately(velocityYAbs, 0))
            {
                velocity.y += Random.Range(-this.minSpeed, this.minSpeed);
            }

            Debug.Log(velocity);

            this.rb.velocity = velocity;
            this.lastHitCollider = collision.collider;
            this.hitTime = Time.time;
        }
    }
}
