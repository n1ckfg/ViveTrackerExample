using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamVR_NewTracker : MonoBehaviour {

    public Transform target;
    public float smooth = 0.2f;

    private void Start() {
        target.position = transform.position;
        target.rotation = transform.rotation;
    }

    private void Update() {
        target.position = Vector3.Lerp(target.position, transform.position, smooth);
        target.rotation = Quaternion.Lerp(target.rotation, transform.rotation, smooth);
	}

}
