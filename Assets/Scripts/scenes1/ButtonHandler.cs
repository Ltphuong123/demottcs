using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] protected TMP_InputField inputFieldTMP;
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }
    void OnClick()
    {
        SceneManager.LoadScene("play");
        PlayerPrefs.SetString("Id_TikTok", inputFieldTMP.text);

    }
}
