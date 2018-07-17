using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamVR_SevenMove : MonoBehaviour {
    // https://www.youtube.com/watch?v=ycCBzwjOD70

    public SteamVR_NewController steamCtlMain;
    public SteamVR_NewController steamCtlAlt;
    public Transform target;
    public GameObject centerObj;

    [Header("Translate")]
    public bool translateEnabled = true;
    public float moveSpeed = 4f;

    public enum RotMode { AVG, MAIN, ALT };
    [Header("Rotate")]
    public bool rotationEnabled = true;
    public RotMode rotMode = RotMode.AVG;
    public float rotSpeed = 0.8f;

    [Header("Scale")]
    public bool scaleEnabled = true;
    public float minScale = 0.0001f;
    public float maxScale = Mathf.Infinity;
    public float scaleTriggerDist = 0.333f;
    public float scaleSpeed = 0.75f;
    
    private Renderer centerRen;
    private Vector3 prevPosMain = Vector3.zero;
    private Vector3 prevPosAlt = Vector3.zero;
    private Vector3 centerPos = Vector3.zero;
    private float dist = 0f;
    private float delta = 0f;
    private float prevDist = 0f;

    private float angle = 0f;
    private float prevAngle = 0f;
    private float angleDelta = 0f;

    private float deltaThreshold = 0.01f;
    private bool useCenterObj = false;
    private List<Vector3> scaleDeltaSamples = new List<Vector3>();

    private void Awake() {
        if (centerObj == null) return;
        useCenterObj = true;
        centerRen = centerObj.GetComponent<Renderer>();
        centerRen.enabled = false;
    }

    private void Update() {
        dist = (steamCtlMain.transform.position - steamCtlAlt.transform.position).magnitude;
        delta = dist - prevDist;

        Vector3 deltaPosMain = steamCtlMain.transform.position - prevPosMain;
        Vector3 deltaPosAlt = steamCtlAlt.transform.position - prevPosAlt;
        Vector3 deltaPosAvg = (deltaPosMain + deltaPosAlt) / 2f;
        deltaPosAvg = new Vector3(deltaPosAvg.x, -deltaPosAvg.y, deltaPosAvg.z);

        centerPos = (steamCtlMain.transform.position + steamCtlAlt.transform.position) / 2f;
        if (useCenterObj && dist <= scaleTriggerDist * target.localScale.x) centerObj.transform.position = centerPos;

        if (rotMode == RotMode.AVG) {
            angle = (getAngle(steamCtlMain.transform, centerPos) + getAngle(steamCtlAlt.transform, centerPos)) / 2f;
        } else if (rotMode == RotMode.MAIN) {
            angle = getAngle(steamCtlMain.transform, centerPos);
        } else if (rotMode == RotMode.ALT) {
            angle = getAngle(steamCtlAlt.transform, centerPos);
        }
        angleDelta = (angle - prevAngle) * rotSpeed;

        //if (steamCtlMain.gripped && steamCtlAlt.gripped) {
        if (steamCtlAlt.triggerPressed) {
            if (useCenterObj) centerRen.enabled = true;

            doScale();
            doRotate();
            doTranslate(deltaPosAvg);
        } else {
            if (useCenterObj) centerRen.enabled = false;
        }

        prevPosMain = steamCtlMain.transform.position;
        prevPosAlt = steamCtlAlt.transform.position;
        prevDist = dist;
        prevAngle = angle;
    }

    private float getAngle(Transform t1, Vector3 v1) {
        Vector3 relative = t1.InverseTransformPoint(v1);
        float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
        return angle;
    }

    private void doTranslate(Vector3 deltaPosAvg) {
        if (!translateEnabled) return;

        Vector3 move = new Vector3(-deltaPosAvg.x, deltaPosAvg.y, -deltaPosAvg.z) * moveSpeed;
        Vector3 dir = target.InverseTransformDirection(move);

        Vector3 finalMove = new Vector3(dir.x, dir.y, dir.z);
        //if (dist > scaleTriggerDist * target.localScale.x) finalMove.y *= 0.1f; // reduce y movement while scaling
        target.Translate(finalMove);

    }

    private void doRotate() {
        if (!rotationEnabled) return;// || dist > scaleTriggerDist * target.localScale.x) return; // don't rotate while scaling

        target.rotation = Quaternion.RotateTowards(target.rotation, Quaternion.Euler(target.localEulerAngles.x, target.localEulerAngles.y - angleDelta, target.localEulerAngles.z), 1f);
        //target.Rotate(0f, -angleDelta, 0f);
    }

    private void doScale() {
        if (!scaleEnabled) return;// || dist <= scaleTriggerDist * target.localScale.x) return;

        if (Mathf.Abs(delta) > Mathf.Abs(deltaThreshold * target.localScale.x)) {
            Vector3 scaleDelta = Vector3.one * Mathf.Sign(delta); 
            Vector3 newScale = target.localScale - scaleDelta;
            newScale = new Vector3(Mathf.Clamp(newScale.x, minScale, maxScale), Mathf.Clamp(newScale.y, minScale, maxScale), Mathf.Clamp(newScale.z, minScale, maxScale));
            target.localScale = Vector3.Lerp(target.localScale, newScale, scaleSpeed / 100f);
        }
    }

}
