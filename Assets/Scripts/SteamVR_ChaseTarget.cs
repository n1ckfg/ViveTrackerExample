using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamVR_ChaseTarget : MonoBehaviour {

    public Transform target;
    public bool doLerp = true;
    public float lerpVal = 0.5f;

    private bool firstRun = true;

    private void Update() {
        if (doLerp) {
            if (firstRun) {
                matchPosRot();
                firstRun = false;
            } else {
                lerpPosRot();
            }
         } else {
            matchPosRot();
        }
    }

    private void lerpPosRot() {
        transform.position = Vector3.Lerp(transform.position, target.position, lerpVal);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, lerpVal);
    }

    private void matchPosRot() {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

}
