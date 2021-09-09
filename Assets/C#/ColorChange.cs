using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private Material color;
    private string colorname;
    void Start()
    {
        color = GetComponent<MeshRenderer>().material;
        colorname = color.name;
    }
    public void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            col.gameObject.GetComponent<MeshRenderer>().material = color;
            col.gameObject.GetComponent<ScoreAll>().colorname = colorname;

        }
        if(col.gameObject.CompareTag("Tail"))
            col.gameObject.GetComponent<MeshRenderer>().material = color;
    }
}
