using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeActive : MonoBehaviour
{
  public float tim;
  private float timS;

    void OnEnable(){
        timS = tim;
    }
    void FixedUpdate()
    {
        timS -= Time.fixedDeltaTime;
        if(timS <=0)
        gameObject.SetActive(false);
    }
}
