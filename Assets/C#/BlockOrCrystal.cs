using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOrCrystal : MonoBehaviour
{
    public bool crystal;
    ScoreAll scoreAll;
    public bool win;
    void Start()
    {

    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (crystal)
            {
                col.gameObject.GetComponent<ScoreAll>().CrystalAdd();
                Destroy(gameObject);
            }
            else
            {
               
                scoreAll = col.gameObject.GetComponent<ScoreAll>();
                if(win)
                scoreAll.LvlNext();
                if (!scoreAll.fever)
                    scoreAll.LvlRestart();
                else
                {
                    col.gameObject.GetComponent<ScoreAll>().CrystalAdd();
                    Destroy(gameObject);
                }
            }

        }
    }
}
