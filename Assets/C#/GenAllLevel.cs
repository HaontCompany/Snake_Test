using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenAllLevel : MonoBehaviour
{
    public GameObject[] location;
    private Vector3 vec3;
    private int locnum,wasnum;

    void Start()
    {
        wasnum = -1;
        vec3 = Vector3.zero;
        for (int i = 0; i < 4; i++)
        {
            GenerLoc();
        }
        
    }
    public void GenerLoc(){
        if(wasnum != locnum)
        locnum = Random.Range(0,location.Length);
        else
        {
            if(locnum >=0 && locnum < 3)
        locnum++; 
        else if(locnum <6 && locnum >= 3)
        {
            locnum--;
        }
        }
        Instantiate(location[locnum], vec3, Quaternion.identity);
        vec3.z += 35.954f;
    }
}
