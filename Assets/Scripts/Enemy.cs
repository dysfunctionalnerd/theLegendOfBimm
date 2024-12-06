using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRig;

    [SerializeField] Character character;

    [SerializeField] float speed = 2.0f;
    [SerializeField] float radius = 10f;

    [SerializeField] LayerMask checkLayer;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyRig = this.GetComponent<Rigidbody2D>();
        character = GameObject.Find("Character").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        //character.transform.position
        if (CanSeePlayer() == true)
        { 
        Vector2 enemyDir = character.transform.position - this.transform.position;
        enemyDir = enemyDir.normalized;
        enemyRig.velocity = enemyDir * speed;
        }

        else 
        {
            enemyRig.velocity = Vector2.zero;
        }
    }

    bool CanSeePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, character.transform.position - this.transform.position, radius, checkLayer);

        if(hit.collider !=null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }
}
