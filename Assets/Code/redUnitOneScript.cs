using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redUnitOneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public float moveSpeed;
    public Animator unitAnim;
    public int shootDist;
    public LayerMask hittableLayer;
    public Transform firePoint;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, shootDist, hittableLayer);

        if (hit.collider != null)
        {
            if (hit == GameObject.FindGameObjectWithTag("blueUnit"))
            {
                unitAnim.Play("redUnitOneAttack");
                moveSpeed = 0;
            }
        }
        else
        {
            unitAnim.Play("redUnitOneStill");
            moveSpeed = 0.25f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("goodU1Weapon"))
        {
            health--;

        }
        if (collision.gameObject.CompareTag("goodU2Weapon"))
        {
            health -= 2;

        }
        if (collision.gameObject.CompareTag("goodU3Weapon"))
        {
            health -= 10;

        }
    }
}