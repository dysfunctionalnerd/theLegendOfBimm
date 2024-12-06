using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPlayerMovement : MonoBehaviour
{

    Rigidbody2D rigid;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        rigid.velocity = new Vector2(xMovement * speed, yMovement * speed);


        //Rotation of the player towards the mouse Position
        Vector2 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        mouseWorldPos.z = this.transform.position.z; //eliminate the z-value

        Vector3 mousePlayer = mouseWorldPos - this.transform.position; //calculating the vector between player and mouse position
        float angle = Mathf.Atan2(mousePlayer.y, mousePlayer.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, angle);


        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentBullet = Instantiate(bulletPrefab, this.transform.position + mousePlayer.normalized * 2f, Quaternion.identity);
            currentBullet.GetComponent<Rigidbody2D>().velocity = mousePlayer * 10f;
        }

    }
}
