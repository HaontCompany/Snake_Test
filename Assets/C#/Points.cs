using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
   Transform pers;
   public string colorname;
   private WaitForFixedUpdate waitF = new WaitForFixedUpdate();
   
    void Start()
    {
        colorname = GetComponent<MeshRenderer>().material.name;
    }
    public void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            if(col.gameObject.GetComponent<ScoreAll>().colorname == colorname){
            col.gameObject.GetComponent<ScoreAll>().ScoreAdd();
            Destroy(gameObject);
            }
            else
            {
            col.gameObject.GetComponent<ScoreAll>().LvlRestart(); 
            }
        }
        if(col.gameObject.CompareTag("Cone")){
            pers = col.gameObject.transform.parent;
        StartCoroutine(Go());

        }
    }
    public void OnTriggerExit(Collider col){
         if(col.gameObject.CompareTag("Cone")){
            pers = null;
        StopAllCoroutines();

        }
    }
    
    IEnumerator Go(){
        while (pers != null)
        {
        transform.position = Vector3.MoveTowards(transform.position, pers.position, Time.deltaTime * 4); 
        yield return waitF; 
        }
    
    }
}
