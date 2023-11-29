using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tron : MonoBehaviour
{
    public CircleCollider2D circleCollider;
	public Rigidbody2D rigidBody;
    public float pushForce = 10f;
    public void UsePhysics ( bool usePhysics ) {
		// isKinematic = true  means that this rigidbody is not affected by Unity's physics engine
		rigidBody.isKinematic = !usePhysics;
	}
    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
    {
        Destroy(gameObject);
    }
    }
    public void OnCollisionEnter2D (Collision2D oj){
        if (oj.gameObject.CompareTag("Toan"))
        {   
            Vector2 pushDirection = transform.position - oj.transform.position;
            pushDirection.y = 0f;
            pushDirection.Normalize();
            rigidBody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);            
        }
    }
}
