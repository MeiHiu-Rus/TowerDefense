using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redPlaneScript : MonoBehaviour
{


    // Start is called before the first frame update
    public Animator bPlane;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void attackPlane()
    {
        bPlane.Play("redUnitThreeAttack");
    }
}
