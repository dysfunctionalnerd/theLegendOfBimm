using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRig;

    [SerializeField]
    Character character;

    [SerializeField]
    float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //character.transform.position
        Vector2 enemyDir = character.transform.position - this.transform.position;
        enemyDir = enemyDir.normalized;
        enemyRig.velocity = enemyDir * speed;
    }
}
