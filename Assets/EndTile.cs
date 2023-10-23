using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EndTile : MonoBehaviour
{
    GamePlay gp;

    void Start()
    {
        gp = GameObject.FindFirstObjectByType<GamePlay>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        gp.CheckForWin();
    }

}

