using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour {
	public float speed = 2f;
	public Transform[] PatrolPoints;

	Transform currentPatrolPoint;
    Rigidbody2D rb;
	int currentPatrolIndex;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
		currentPatrolIndex = 0;
		currentPatrolPoint = PatrolPoints [currentPatrolIndex];
    }

	void FixedUpdate () {
		if (currentPatrolIndex == 0) {
			transform.Translate (Vector2.right * speed);
		} else {//currentPatrolIndex == 1
			transform.Translate (Vector2.left * speed);
		}

		//check to see if we have reached the patrol point
		if (Vector2.Distance (this.transform.position, currentPatrolPoint.position) < 0.1f) {

			if (currentPatrolIndex == 0) {
				currentPatrolIndex++;
			} else {
				currentPatrolIndex--;
			}
			currentPatrolPoint = PatrolPoints [currentPatrolIndex];
		}
    }
}
