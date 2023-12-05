using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartGameButton : MonoBehaviour
{
  public void MoveToScene(int Level01)
   {
    SceneManager.LoadScene(Level01);
   }
}



