using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptRunway : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(load());
    }

    private IEnumerator load()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Hospital");
    }

}
