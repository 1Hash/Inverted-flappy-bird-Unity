using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUILoader : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("SceneUI", LoadSceneMode.Additive);
    }
}
