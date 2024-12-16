using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
  // panel de mision
  public GameObject misionPanel;

  void Start(){
  	misionPanel.SetActive(false);
  }
  public void play(){
  	misionPanel.SetActive(true);
  }
  public void backToMenu(){
  	misionPanel.SetActive(false);
  }
  public void exit(){
  	Application.Quit();
  }

  public void loadGameScene(){
  	SceneManager.LoadScene(1);
  }
}
