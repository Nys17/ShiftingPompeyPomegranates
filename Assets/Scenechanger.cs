using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenechanger : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }

    public void OnStart() { SceneManager.LoadScene(1); }

    public void onQuit() { Application.Quit(); }
}
