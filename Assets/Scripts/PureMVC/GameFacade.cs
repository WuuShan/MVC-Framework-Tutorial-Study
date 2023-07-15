using PureMVC.Interfaces;
using PureMVC.Patterns.Facade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : Facade
{
    // 1.继承PureMVC中Facade脚本

    // 2.为了方便我们使用Facade 需要自己写一个单例模式的属性
    public static GameFacade Instance => (instance ??= new GameFacade()) as GameFacade;

    /// <summary>
    /// 3.初始化 控制层相关的内容
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();
        // 这里面要写一些 关于 命令和通知 绑定的逻辑   
        RegisterCommand(PureNotification.START_UP, () =>
        {
            return new StartUpCommand();
        });

        RegisterCommand(PureNotification.SHOW_PANEL, () =>
        {
            return new ShowPanelCommand();
        });

        RegisterCommand(PureNotification.HIDE_PANEL, () =>
        {
            return new HidePanelCommand();
        });

        RegisterCommand(PureNotification.LEV_UP, () =>
        {
            return new LevUpCommand();
        });
    }

    // 4.一定是有一个启动函数的
    public void StartUp()
    {
        // 发送通知
        SendNotification(PureNotification.START_UP);
    }
}