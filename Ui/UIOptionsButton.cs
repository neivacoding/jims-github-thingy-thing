using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOptionsButton : MonoBehaviour
{
   public void MoveToScene(int Options)
   {
        SceneManager.LoadScene(Options);
   }
}
