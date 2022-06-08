using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singelton;

    //LOGIC
    int levelNum;

    private void Awake()
    {
        if (singelton)
        {
            Destroy(gameObject);
        }else
        {
            singelton = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void NextLevel()
    {
        print("Next Level");
        levelNum++;
        StartCoroutine(NextLevel_());
    }

    IEnumerator NextLevel_()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("level" + levelNum);
    }
}
