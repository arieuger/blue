using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotate : MonoBehaviour {

    // Update is called once per frame
    void Update() {
        transform.Rotate(Vector3.up * Time.deltaTime * 20f);
    }
}
