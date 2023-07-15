using PureMVC.Patterns.Proxy;
using System.Data;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 玩家数据代理对象
/// 主要处理 玩家数据更新相关的逻辑
/// </summary>
public class PlayerProxy : Proxy
{
    public new const string NAME = "PlayerProxy";
    // 1.继承Proxy父类
    // 2.写我们的构造函数

    // 写构造函数
    // 重要点
    // 1.代理的名字！！！
    // 2.代理相关的数据！！！

    public PlayerProxy() : base(NAME)
    {
        // 在构造函数中 初始化一个数据 进行关联
        PlayerDataObj data = new()
        {
            // 初始化
            playerName = PlayerPrefs.GetString("PlayerName", "唐老狮"),
            lev = PlayerPrefs.GetInt("PlayerLev", 1),
            money = PlayerPrefs.GetInt("PlayerMoney", 999),
            gem = PlayerPrefs.GetInt("PlayerGem", 888),
            power = PlayerPrefs.GetInt("PlayerPower", 10),

            hp = PlayerPrefs.GetInt("PlayerHp", 100),
            atk = PlayerPrefs.GetInt("PlayerAtk", 20),
            def = PlayerPrefs.GetInt("PlayerDef", 10),
            crit = PlayerPrefs.GetInt("PlayerCrit", 20),
            miss = PlayerPrefs.GetInt("PlayerMiss", 10),
            luck = PlayerPrefs.GetInt("PlayerLuck", 40),
        };

        // 赋值给自己的Data进行关联
        Data = data;
    }

    public void LevUp()
    {
        PlayerDataObj data = Data as PlayerDataObj;

        // 升级 改变内容
        data.lev += 1;

        data.hp += data.lev;
        data.atk += data.lev;
        data.def += data.lev;
        data.crit += data.lev;
        data.miss += data.lev;
        data.luck += data.lev;
    }

    public void SaveData()
    {
        PlayerDataObj data = Data as PlayerDataObj;

        // 把这些数据内容 存储到本地
        PlayerPrefs.SetString("PlayerName", data.playerName);
        PlayerPrefs.SetInt("PlayerLev", data.lev);
        PlayerPrefs.SetInt("PlayerMoney", data.money);
        PlayerPrefs.SetInt("PlayerGem", data.gem);
        PlayerPrefs.SetInt("PlayerPower", data.power);

        PlayerPrefs.SetInt("PlayerHp", data.hp);
        PlayerPrefs.SetInt("PlayerAtk", data.atk);
        PlayerPrefs.SetInt("PlayerDef", data.def);
        PlayerPrefs.SetInt("PlayerCrit", data.crit);
        PlayerPrefs.SetInt("PlayerMiss", data.miss);
        PlayerPrefs.SetInt("PlayerLuck", data.luck);
    }
}
