using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStory : MonoBehaviour
{
    public void CloseStoryboard()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
