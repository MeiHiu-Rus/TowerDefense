using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class redBaseScript : MonoBehaviour
{
    public int health;
    public TMP_Text baseCountText;
    public GameObject gameOverScene;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        baseCountText.text = health.ToString();
        gameOverScene.SetActive(false);
        Time.timeScale = 1;
        AudioManager.Instance.PlayMusic("Theme");
    }

    // Update is called once per frame
    void Update()
    {
        baseCountText.text = health.ToString();
        if (health <= 0)
        {
            gameOverScene.SetActive(true);
            Time.timeScale = 0;
            AudioManager.Instance.musicSource.Stop();


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("goodU1Weapon"))
        {
            health--;
            baseCountText.text = health.ToString();
        }
        if (collision.gameObject.CompareTag("goodU2Weapon"))
        {
            health -= 2;
            baseCountText.text = health.ToString();
        }
        if (collision.gameObject.CompareTag("goodU3Weapon"))
        {
            health -= 10;     
            baseCountText.text = health.ToString();
        }
       
    }
}