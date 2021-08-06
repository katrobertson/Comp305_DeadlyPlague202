using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeopleCured : MonoBehaviour
{
    int peopleCured = 0;
    public Text peopleCuredText;
    public GameObject levelCompleteUI;

    public void peoplecured()
    {
        peopleCured += 1;
        peopleCuredText.text = ""+peopleCured;
        if(peopleCured >= 4)
        {
            LevelCompleted();
        }
    }

    public void LevelCompleted()
    {
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
