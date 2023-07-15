using UnityEngine;

public class Main : MonoBehaviour
{
    private void Start()
    {
        GameFacade.Instance.StartUp();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // 显示主面板
            GameFacade.Instance.SendNotification(PureNotification.SHOW_PANEL, "MainPanel");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            // 隐藏主面板
            GameFacade.Instance.SendNotification(PureNotification.HIDE_PANEL, GameFacade.Instance.RetrieveMediator(NewMainViewMediator.NAME));
        }
    }
}
