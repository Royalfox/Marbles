using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAdjustments : MonoBehaviour
{
#if UNITY_STANDALONE_WIN
    public GameObject leftcontrol;
    public GameObject rightcontrol;

    // Start is called before the first frame update
    void Start()
    {
        if (leftcontrol) leftcontrol.SetActive(false);
        if (rightcontrol) rightcontrol.SetActive(false);
    }
#endif
}
