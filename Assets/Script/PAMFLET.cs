using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PAMFLET : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(load());
    }

    private IEnumerator load()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("PesawatTerbang");
    }

}
