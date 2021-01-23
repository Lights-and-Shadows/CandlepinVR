using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public int currentBox = 1;

    public void Start()
    {
        Debug.Log("Current Box: " + currentBox.ToString());
    }
}
