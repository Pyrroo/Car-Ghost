using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwap : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

}
