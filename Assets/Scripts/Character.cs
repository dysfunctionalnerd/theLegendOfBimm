using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField] float speed;
    [SerializeField] GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * 3, Input.GetAxis("Vertical") * 3);

        //This rotates the player based on mouse position
        Vector2 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        mouseWorldPos.z = this.transform.position.z; //eliminates the z value

        Vector3 mousePlayer = mouseWorldPos - this.transform.position; //this calulates the vector between the player and the mouse position
        float angle = Mathf.Atan2(mousePlayer.y, mousePlayer.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, angle);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject currentBullet = Instantiate(bulletPrefab, this.transform.position + mousePlayer.normalized * .5f, Quaternion.identity);
            currentBullet.GetComponent<Rigidbody2D>().velocity = mousePlayer * 10f;
        }
    }
}
