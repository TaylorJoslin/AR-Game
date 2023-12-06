using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class Start : MonoBehaviour
{
    public GameObject Instructions;

    private void OnEnable()
    {
        Time.timeScale = 0;
        Instructions.SetActive(true);
    }

    private void OnTapRecognized(TapGesture obj)

    {
        Vector2 mousePos = obj.startPosition;
        if (!mousePos.IsPointOverUIObject())
        {
            Time.timeScale = 1;
            Instructions.SetActive(false);
        }

           
    }
}
