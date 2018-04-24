using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FireSlimeGameLoop : MonoBehaviour {
    public Texture NullHeart;
    public Texture RedHeart;

    public RawImage[] playerHearts;

    public static FireSlimeGameLoop _instance;
    public static FireSlimeGameLoop GetInstance()
    {
        if (_instance == null)
        {
            _instance = new FireSlimeGameLoop();
        }
        return _instance;
    }

    public Player player;
    public GameObject OverMenu;
    public GameObject PauseMenu;
    public Text OverMenuText;
    //public GameObject RunningInterface;

    private bool isOver;
    public void SetOver(bool isOver)
    {
        this.isOver = isOver;
    }
    public bool  GetOver()
    {
        return isOver;
    }
    // Use this for initialization
    void Awake()
    {
        _instance = this;
        OverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        isOver = false;
        Time.timeScale = 1;
        
        //OverMenuText.gameObject.SetActive(false);
    }
	
    void Start()
    {
        Time.timeScale = 1;
    }
	// Update is called once per frame
	void Update () {
        UpdateUI();

        if (player.isDead == true)
        {
            isOver = true;
        }
        PlayerHeartsUpdate();
	}

    void PlayerHeartsUpdate()
    {
        int i = player.GetHealth();
        for (int x = 0; x < playerHearts.Length; x++)
        {
            if (x < i)
            {
                playerHearts[x].texture = RedHeart;
            }
            else
            {
                playerHearts[x].texture = NullHeart;
            }
        }
    }

    void UpdateUI()
    {
        if (isOver)
        {
            if (player.isDead == true)
            {
                OverMenuText.GetComponentInChildren<Text>().text = "你被击败了，是否重新来过";
            }
            else
            {
                OverMenu.GetComponentInChildren<Text>().text = "你通过了这关，是否再次挑战";
            }
            OverMenu.SetActive(true);

            PauseMenu.SetActive(false);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.activeSelf == false)
            {
                PauseMenu.SetActive(true);
            }
            else
            {
                PauseMenu.SetActive(false);
            }
        }
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void ReStart()
    {
        SceneManager.LoadScene("FireSlimeBoss");
    }

    public void ContinueGame()
    {
        PauseMenu.SetActive(false);
    }
}
