using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Make sure to add this, or you can't use SceneManager
using UnityEngine.SceneManagement;
using TMPro;


public class Level_Change : MonoBehaviour
{
    public int levelIndex = 0;
    //IE if you want the fade to black to work
    public bool useGameSceneManager = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        //other.name should equal the root of your Player object
        if (other.tag == "Player")
        {
            if (levelIndex == 6 && GameObject.FindGameObjectWithTag("SceneManager").GetComponent<CollectibleManager>().GetCollected() < 25)
            {
                //GameObject.FindGameObjectWithTag("finalText").meshRenderer.enabled = true;
                //TextMeshPro ft = (TextMeshPro) GameObject.FindGameObjectWithTag("finalText").GetComponent<TextMeshPro>();
                TextMeshPro ft = (TextMeshPro)GameObject.FindGameObjectWithTag("finalTextText").GetComponent<TextMeshPro>();
                //ft.renderer.SetActive(false);
                ft.text = "YOU MUST COLLECT AT LEAST 25 PAGES";
                //Debug.Log(ft.text);

            }
            else {
                //The scene number to load (in File->Build Settings)
                if (useGameSceneManager)
                {
                    GameObject.FindGameObjectWithTag("SceneManager").GetComponent<GameSceneManager>().LoadScene(levelIndex);
                }
                else
                {
                    SceneManager.LoadScene(levelIndex);
                }
            }
        }
    }
}