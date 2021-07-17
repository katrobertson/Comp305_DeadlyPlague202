using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Scene3()
    {
        SceneManager.LoadScene("Level3");
    }
}
