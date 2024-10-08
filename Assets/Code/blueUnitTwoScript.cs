using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueUnitTwoScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int health;
    public int shootDist;
    public LayerMask hittableLayer;
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public bool shoot;

    public float targetTime = 1.2f;
    public GameObject bulletPrefab;
    public float moveSpeed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, shootDist, hittableLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(firePoint2.position, firePoint2.right, shootDist, hittableLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(firePoint3.position, firePoint3.right, shootDist, hittableLayer);

        if (hit.collider != null || hit2.collider != null || hit3.collider != null)
        {
            if (hit == GameObject.FindGameObjectWithTag("redUnit") || hit2 == GameObject.FindGameObjectWithTag("redUnit") || hit3 == GameObject.FindGameObjectWithTag("redUnit"))
            {
                shoot = true;
                moveSpeed = 0;
            }
        }
        else
        {
            moveSpeed = -0.25f;
            shoot = false;
        }

        if (shoot == true && targetTime <= 0.0f)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, transform);
            targetTime = 1.2f;
            shoot = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemyU1Weapon"))
        {
            health--;

        }
        if (collision.gameObject.CompareTag("enemyU2Weapon"))
        {
            health -= 2;

        }
        if (collision.gameObject.CompareTag("enemyU3Weapon"))
        {
            health -= 10;

        }
    }

}