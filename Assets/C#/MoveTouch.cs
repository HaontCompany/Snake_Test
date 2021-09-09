using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTouch : MonoBehaviour
{
    public float speed;

    private Vector3 touchedPos;
    public Transform head;
    [HideInInspector]
    public bool fever;
    public float timF;
    public ScoreAll scoreAll;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        if(fever){
            Fever();
        }
    }
    public void Fever(){
         timF -= Time.fixedDeltaTime;
        if(head.position.x!= 0)
        head.position = Vector3.Lerp(head.position, new Vector3(0, 0, head.position.z), 8 * Time.deltaTime);
        if(timF <= 0){
            
            speed /=3;
            fever = false;
            scoreAll.ResetFever();
            
        }
    }
    public void FeverGo(){
         speed *=3;
        fever = true;
        timF = 1;
    }

     void Update()
    {
        if (Input.touchCount > 0 && !fever)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                if (touchedPos.x > -2.4f && touchedPos.x < 2.4f)
                    head.position = Vector3.Lerp(head.position, new Vector3(touchedPos.x, 0, head.position.z), 5 * Time.deltaTime);
                else
                {
                    if (touchedPos.x <= -2.4f)
                        head.position = Vector3.Lerp(head.position, new Vector3(-2.4f, 0, head.position.z), 5 * Time.deltaTime);
                    else
                    {
                        head.position = Vector3.Lerp(head.position, new Vector3(2.4f, 0, head.position.z), 5 * Time.deltaTime);
                    }
                }
            }
        }
    }
}
