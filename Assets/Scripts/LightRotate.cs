using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotate : MonoBehaviour {

    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update() {
        transform.LookAt(target);
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
