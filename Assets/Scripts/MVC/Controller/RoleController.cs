using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    private RoleView roleView;

    private static RoleController controller = null;

    public static RoleController Controller => controller;

    public static void ShowMe()
    {
        if (controller == null)
        {
            // 实例化面板对象
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = Instantiate(res);
            // 设置它的父对象 为Canvas
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

            controller = obj.GetComponent<RoleController>();
        }
        // 如果是隐藏的形式hide 在这要显示
        controller.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        // 方式一 直接删
        //Destroy(panel.gameObject);
        //panel = null;
        // 方式二 设置可见为隐藏
        controller.gameObject.SetActive(false);
    }

    private void Start()
    {
        roleView = GetComponent<RoleView>();
        // 第一次更新面板
        roleView.UpdateInfo(PlayerModel.Data);

        roleView.btnClose.onClick.AddListener(ClickCloseBtn);
        roleView.btnLevUp.onClick.AddListener(ClickLevUpBtn);

        // 告知数据模块 当更新时 通知哪个函数做处理
        PlayerModel.Data.AddEventListener(UpdateInfo);
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }

    private void ClickCloseBtn()
    {
        HideMe();
    }

    private void ClickLevUpBtn()
    {
        // 通过数据模块 进行升级 达到数据改变
        PlayerModel.Data.LevUp();
    }

    private void UpdateInfo(PlayerModel data)
    {
        if (roleView != null)
        {
            roleView.UpdateInfo(data);
        }
    }
}
