using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainSceneMenu : MonoBehaviour {
    //主界面选线
    public GameObject menu1;
    //单人选关卡
    public GameObject menu2;
    //多人游戏界面
    public GameObject menu3;
    public GameObject pleaseWaiting;//功能暂未开启
    

    void Start()
    {
        if (menu1 != null)
        {
            menu1.SetActive(true);
        }
        if (menu2 != null)
        {
            menu2.SetActive(false);
        }
        if (menu3 != null)
        {
            menu3.SetActive(false);
        }
        if (pleaseWaiting != null)
        {
            pleaseWaiting.SetActive(false);
        }
    }

    //开始单人选择关卡
    public void ShowMenu2()
    {
        menu1.SetActive(false);
        menu2.SetActive(true);
    }
    //进入FireSlimeBoss关卡
    public void EnterLevel1()
    {
        Application.LoadLevel("FireSlimeBoss");
    }
	
    //进入IceSlimeBoss关卡
    public void EnterLevel2()
    {
        Application.LoadLevel("IceSlimeBoss");
    }

    //退出游戏
    public void QuitGame()
    {
        Application.Quit();
    }

    //跳出暂未开放的提示
    public void ShowWaitingInterface()
    {
        pleaseWaiting.SetActive(true);
    }
    //关闭暂未开放的提示
    public void CloseWaitingInterface()
    {
        pleaseWaiting.SetActive(false);
    }
}
