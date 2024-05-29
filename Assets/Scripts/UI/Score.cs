using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    [SerializeField] protected int score=0;
    [SerializeField] protected  TMP_Text scoreText;

    public virtual void Add(int add)
    {
        this.score+=add;
    }
    void Update(){
        scoreText.text= score.ToString();
        PlayerPrefs.SetString("Score", score.ToString());
    }
}
