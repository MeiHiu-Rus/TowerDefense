using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redBulletScript : MonoBehaviour
{
    public float speed = .5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.right * -speed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("blueUnit"))
        {
            Destroy(gameObject);

        }

    }
}
