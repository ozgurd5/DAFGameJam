using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GeriButonu : MonoBehaviour
{
   public void Geri()
    {
        SceneManager.LoadScene("Level 0");
    }
}
