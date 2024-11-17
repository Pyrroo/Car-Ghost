using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject Endcanvas, gamecanvas;
    public TextMeshProUGUI textgc;
    public GameController gc;
    private void Start()
    {
        HideEndCanvas();
    }

    public void ShowEndCanvas()
    {
        Endcanvas.SetActive(true);
    }

    public void HideEndCanvas()
    {
        Endcanvas.SetActive(false);
    }

    public void ShowGameCanvas()
    {
        gamecanvas.SetActive(true);
    }

    public void HideGameCanvas()
    {
        gamecanvas.SetActive(false);
    }

    public void RestartRace()
    {
        gc.StartGame();
    }

    public void ToStart()
    {
        SceneManager.LoadScene("Start");
    }


}
