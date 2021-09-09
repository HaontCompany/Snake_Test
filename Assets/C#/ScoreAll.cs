using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreAll : MonoBehaviour
{
    private int score, crystal;
    public Text scoreT, crystalT;
    public string colorname;
    public Tails tails;
    int numtext;
    public GameObject[] Numbertext;
    int crysFever;
    public MoveTouch moveTouch;
    [HideInInspector]
    public bool fever;
    void Start()
    {
        
    }
    public void ScoreAdd(){
        score++;
        scoreT.text = score.ToString();
        tails.ChangeSize();
        SeeNumbers();
        crysFever = 0;
    }
    public void CrystalAdd(){
        crystal+=5;
        crystalT.text = crystal.ToString();
        tails.ChangeSize();
        crysFever++;
        if(crysFever == 4  && !fever){
            fever = true;
            tails.Feverspeed();
            moveTouch.FeverGo();
        }
    }
    public void ResetFever(){
        fever = false;
        crysFever = 0;
        crystal=0;
        crystalT.text = crystal.ToString();
        tails.Feverspeed(false);
    }
    public void SeeNumbers(){
        if(Numbertext[numtext].activeSelf == true)
        Numbertext[numtext].SetActive(false);

        Numbertext[numtext].SetActive(true);
        numtext++;
        if(numtext >=4){
            numtext = 0;
        }
    }
    public void LvlRestart(){
        if(!fever)
        SceneManager.LoadScene(0);
    }
    public void LvlNext(){

        SceneManager.LoadScene(0);
    }
}
