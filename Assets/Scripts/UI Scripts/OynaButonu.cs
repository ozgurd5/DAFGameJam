using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OynaButonu : MonoBehaviour
{
    public void Oyna()
    {
        SceneManager.LoadScene("Level -1");
    }
}
