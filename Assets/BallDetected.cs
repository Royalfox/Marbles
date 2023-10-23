using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallDetected : MonoBehaviour
{
    Color origcolor;
    GamePlay gp;

    void Start()
    {
        origcolor = GetComponent<Renderer>().material.color;
        gp = GameObject.FindFirstObjectByType<GamePlay>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Material mat = this.GetComponent<Renderer>().material;

        if (mat.color != Color.red)
        {
            GetComponent<Renderer>().material.color = Color.red;

           gp.IncScore();
        }
    }

    public void MyReset()
    {
        GetComponent<Renderer>().material.color = origcolor;
    }
}
