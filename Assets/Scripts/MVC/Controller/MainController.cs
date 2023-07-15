using System;
using UnityEngine;

/// <summary>
/// Controller要处理的东西 就是业务逻辑
/// </summary>
public class MainController : MonoBehaviour
{
    // 能够在Controller中得到界面才行
    private MainView mainView;

    private static MainController controller = null;

    public static MainController Controller => controller;

    // 1.界面的显隐
    public static void ShowMe()
    {
        if (controller == null)
        {
            // 实例化面板对象
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = Instantiate(res);
            // 设置它的父对象 为Canvas
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            controller = obj.GetComponent<MainController>();
        }
        controller.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (controller != null)
        {
            controller.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        // 获取同样挂在在一个对象上的 view脚本
        mainView = GetComponent<MainView>();
        // 第一次的 界面更新
        mainView.UpdateInfo(PlayerModel.Data);

        // 2.界面 事件的监听 来处理对于的业务逻辑
        mainView.btnRole.onClick.AddListener(ClickRoleBtn);

        PlayerModel.Data.AddEventListener(UpdateInfo);
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }

    private void ClickRoleBtn()
    {
        // 通过Controller去显示 角色面板
        RoleController.ShowMe();
    }

    // 3.界面的更新
    private void UpdateInfo(PlayerModel data)
    {
        if (mainView != null)
        {
            mainView.UpdateInfo(data);
        }
    }
}
