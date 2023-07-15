using UnityEngine;

public class NormalMain : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // 显示主面板
            MainPanel.ShowMe();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            // 隐藏主面板
            MainPanel.HideMe();
        }
    }
}
