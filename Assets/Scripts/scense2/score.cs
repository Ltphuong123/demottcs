using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public TMP_Text scoreText;
    void Start()
    {
        scoreText.text= PlayerPrefs.GetString("Score");
    }

}
