using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject Menu;

    public void Resume() {
        Time.timeScale = 1.0f;
        Menu.SetActive(false);
    }

    public void Restart() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        SceneManager.LoadScene(0);
    }

	// Use this for initialization
	void Start () {
        Menu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Menu.activeSelf) {
                Time.timeScale = 1.0f;
                Menu.SetActive(false);
            } else {
                Time.timeScale = 0.0f;
                Menu.SetActive(true);
            }
        }
	}
}
