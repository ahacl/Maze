using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	public void SceneChange1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void SceneChange2()
    {
        SceneManager.LoadScene("Scene2");
    }
}
