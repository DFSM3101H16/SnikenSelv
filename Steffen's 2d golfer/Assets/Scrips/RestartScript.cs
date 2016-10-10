using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour {

    public Button restartButton;

	// Use this for initialization
	void Start () {

        restartButton = restartButton.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void RestartMap()
    {
        SceneManager.LoadScene(0);
    }
}
