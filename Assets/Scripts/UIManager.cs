using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public GameObject OverMenu;
    public GameObject PauseMenu;

    public GameObject RunningInterface;
 
    void Start()
    {
        OverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        RunningInterface.SetActive(true);
    }

    void Update()
    {

    }
}
