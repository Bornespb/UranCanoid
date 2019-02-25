using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    //state 
    public int breakableBlockCounter;

    //cached refs
    SceneLoader sceneLoader;

    // Use this for initialization
    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
            breakableBlockCounter++;

    }

    public void BlockDestroyed()
    {
        breakableBlockCounter--;
        if(breakableBlockCounter<=0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
