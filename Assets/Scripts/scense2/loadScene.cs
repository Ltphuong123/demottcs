using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadScene : MonoBehaviour
{
    public string sceneName; // Tên của scene cần load

    void Start()
    {
        // Lấy reference đến button trong scene
        Button button = GetComponent<Button>();

        // Kiểm tra nếu button không null thì gán sự kiện onClick
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    // Phương thức này sẽ được gọi khi button được click
    void OnClick()
    {
        // Load scene với tên được chỉ định
        SceneManager.LoadScene(sceneName);
    }
}
