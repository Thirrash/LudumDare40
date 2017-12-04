using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuB : MonoBehaviour
{
    public Text DLC;
    public Color Begin;
    public Color End;
    public float Speed = 0.1f;

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void Exit() {
        Application.Quit();
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        DLC.color = Color.Lerp(Begin, End, (0.5f * Mathf.Sin(Time.time * Speed)) + 0.5f);
    }
}
