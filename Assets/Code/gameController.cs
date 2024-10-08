using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float targetTime = 2.0f;
    public float saveTargetTime;
    public int gasCount;
    public TMP_Text gasCountText;

    public GameObject gasLoad1;
    public GameObject gasLoad2;
    public GameObject gasLoad3;
    public GameObject gasLoad4;
    public GameObject gasLoad5;

    public GameObject unitLock1;
    public GameObject unitLock2;
    public GameObject unitLock3;

    public bluePlaneScript bluePlane;
    public redPlaneScript redPlane;

    public int spawnPointNumber = 1;
    public Transform spawnPointOne;
    public Transform spawnPointTwo;
    public Transform spawnPointThree;

    public GameObject unitOne;
    public GameObject unitTwo;


    void Start()
    {

        gasCountText.text = gasCount.ToString();
        saveTargetTime = targetTime;



    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

        if (targetTime > (saveTargetTime * .8))
        {
            gasLoad1.SetActive(false);
            gasLoad2.SetActive(false);
            gasLoad3.SetActive(false);
            gasLoad4.SetActive(false);
            gasLoad5.SetActive(false);
        }

        if (targetTime <= (saveTargetTime * .84))
        {
            gasLoad1.SetActive(true);
        }
        if (targetTime <= (saveTargetTime * .68))
        {
            gasLoad2.SetActive(true);
        }
        if (targetTime <= (saveTargetTime * .52))
        {
            gasLoad3.SetActive(true);
        }
        if (targetTime <= (saveTargetTime * .36))
        {
            gasLoad4.SetActive(true);
        }
        if (targetTime <= (saveTargetTime * .2))
        {
            gasLoad5.SetActive(true);
        }


        ///

        if (gasCount >= 3)
        {
            unitLock1.SetActive(false);
        }
        else
        {
            unitLock1.SetActive(true);
        }
        if (gasCount >= 5)
        {
            unitLock2.SetActive(false);
        }
        else
        {
            unitLock2.SetActive(true);
        }
        if (gasCount >= 8)
        {
            unitLock3.SetActive(false);
        }
        else
        {
            unitLock3.SetActive(true);
        }
    }


    void timerEnded()
    {
        gasCount++;
        gasCountText.text = gasCount.ToString();
        targetTime = 2.0f;
    }


    public void buyUnitOne()
    {
        gasCount -= 3;
        gasCountText.text = gasCount.ToString();
        if(spawnPointNumber == 1)
        {
            Instantiate(unitOne, spawnPointOne.position, spawnPointOne.rotation, transform);
            spawnPointNumber = 2;

        }else if(spawnPointNumber == 2)
        {
            Instantiate(unitOne, spawnPointTwo.position, spawnPointTwo.rotation, transform);
            spawnPointNumber = 3;
        }
        else if (spawnPointNumber == 3)
        {
            Instantiate(unitOne, spawnPointThree.position, spawnPointThree.rotation, transform);
            spawnPointNumber = 1;
        }
    }

    public void buyUnitTwo()
    {
        gasCount -= 5;
        gasCountText.text = gasCount.ToString();
        if (spawnPointNumber == 1)
        {
            Instantiate(unitTwo, spawnPointOne.position, spawnPointOne.rotation, transform);
            spawnPointNumber = 2;

        }
        else if (spawnPointNumber == 2)
        {
            Instantiate(unitTwo, spawnPointTwo.position, spawnPointTwo.rotation, transform);
            spawnPointNumber = 3;
        }
        else if (spawnPointNumber == 3)
        {
            Instantiate(unitTwo, spawnPointThree.position, spawnPointThree.rotation, transform);
            spawnPointNumber = 1;
        }
    }


    public void buyUnitThree()
    {
        gasCount -= 8;
        gasCountText.text = gasCount.ToString();
        bluePlane.attackPlane();
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void exitGame()
    {
        SceneManager.LoadScene(0);
    }
}
