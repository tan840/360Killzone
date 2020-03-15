using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Elements : MonoBehaviour
{
    // Start is called before the first frame update
    public Button gun_change;
    public GameObject GameOver_panel;

    public Text highScore_txt;


    public Gun changeGun;
    void Start()
    {
        changeGun = GameObject.Find("Player").GetComponent<Gun>();
        GameOver_panel.SetActive(false);

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGun()
    {
        //print("hello ui");
        changeGun.machinGunActive = !changeGun.machinGunActive;

    }

    public void Retry_btn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
