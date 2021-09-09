using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tails : MonoBehaviour
{
    public Transform ForTrain, MainTrain;
    public bool Can;
    public float speed;
    float sizeS;
    public Tails tails;
    private WaitForSeconds waitS = new WaitForSeconds(.3f);
    void FixedUpdate()
    {   
            transform.position = Vector3.MoveTowards(transform.position, ForTrain.position, Time.fixedDeltaTime *speed);
            Vector3 direction = ForTrain.transform.position - transform.position;
            if(transform.eulerAngles != direction){
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0,rot.y,0,rot.w), 10*Time.fixedDeltaTime);      
            }
    }
    public void Feverspeed(bool fever = true){
        if(fever)
         speed *=3;
         else
         {
         speed /=3;
         }
         if(tails != null)
         tails.Feverspeed(fever);
    }
    public void ChangeSize(){
        StartCoroutine(SizeS());
    }
    IEnumerator SizeS(){
        transform.localScale = new Vector3(.55f,.55f,.55f);
             yield return waitS;
             transform.localScale = new Vector3(.45f,.45f,.45f);
             if(tails != null)
             tails.ChangeSize();
}
}