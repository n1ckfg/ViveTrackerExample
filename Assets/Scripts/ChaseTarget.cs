using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTarget : MonoBehaviour {

    public Transform target;
    public bool doLerp = true;
    public float lerpVal = 0.2f;

    private void Start() {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    private void Update() {
        if (doLerp) {
            transform.position = Vector3.Lerp(transform.position, target.position, lerpVal);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, lerpVal);
        } else {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
	}

}
