using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoToScene : MonoBehaviour
{

    
    

    public void ScenePlay() {

        SceneManager.LoadScene(1);
        //GameObject.Find("PlayerCapsule").GetComponent<StarterAssets.StarterAssetsInputs>().SetCursorState(true);
    }

    public void SceneMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SceneInstructions()
    {
        SceneManager.LoadScene(3);
    }
    public void SceneHardPlay()
    {
        SceneManager.LoadScene(4);
    }

}
//make a gun menu