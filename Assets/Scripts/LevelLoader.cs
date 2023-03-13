using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transition;

    [SerializeField] float transistionTime = 1f;

    [SerializeField] GameObject gameObjectMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevel1()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadLevel2()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadLevel3()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void ExitApplication()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transistionTime);
        //Load scene
        SceneManager.LoadScene(levelIndex);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        gameObjectMenu.SetActive(false);
    }
}
