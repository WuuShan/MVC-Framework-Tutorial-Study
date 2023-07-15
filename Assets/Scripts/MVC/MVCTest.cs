using UnityEngine;

public class MVCTest : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // 显示主面板
            MainController.ShowMe();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            // 隐藏主面板
            MainController.HideMe();
        }
    }
}
