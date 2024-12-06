using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KEnemyMovement : MonoBehaviour
{
    Rigidbody2D rigid;

    Transform player;

    [SerializeField]
    float speed = 5f;

    [SerializeField]
    float radius = 10f;

    [SerializeField]
    LayerMask checkLayer;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer() == true)
        {
            Vector2 direction = player.position - this.transform.position;
            rigid.velocity = direction.normalized * speed;
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
    }

    bool CanSeePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, player.position - this.transform.position, radius, checkLayer);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }

}
