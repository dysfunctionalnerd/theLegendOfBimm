using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform character;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Character").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(character.position.x, character.position.y, this.transform.position.z);
    }
}
