using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public GameObject endPanel;
	public GameObject[] pauseUI;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKey("escape"))
	    {
		    Application.Quit();
	    }
    }
    
    public void Pause()
    {
	    Time.timeScale = 0;
	    pauseUI[0].SetActive(false);
	    pauseUI[1].SetActive(true);
    }
    
    public void UnPause()
    {
	    Time.timeScale = 1;
	    pauseUI[0].SetActive(true);
	    pauseUI[1].SetActive(false);
    }
    
    public void Exit()
    {
	    Application.Quit();
    }
    
    public void TransitionScene(int level)
    {
	    SceneManager.LoadScene(level);
	    if (Time.timeScale == 0)
	    {
		    UnPause();
	    }
    }

	public void LoseGame()
    {
        endPanel.SetActive(true);
		endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game over...";
    }

	public void WinGame()
    {
        endPanel.SetActive(true);
		endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win!";
    }
}
