﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SignPost : MonoBehaviour
{
    public void ResetScene()
    {
        SceneManager.LoadScene("TejasMaze");// Reset the scene when the user clicks the sign post
    }
}