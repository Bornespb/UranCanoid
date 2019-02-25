using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //Config params
    [SerializeField]
    private float screenWidth = 16f;
    [SerializeField]
    private float paddleYOffset = 0.25f,minPaddleX=1,maxPaddleX=15;

    //Cached refs
    GameSession mySession;
    Ball myBall;

	// Use this for initialization
	void Start () {
        mySession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePos = new Vector2(transform.position.x, paddleYOffset);
        paddlePos.x= Mathf.Clamp(GetXPos(), minPaddleX, maxPaddleX);
        this.transform.position = paddlePos;
	}
    private float GetXPos()
    {
        if(mySession.IsAutoPlayEnabled())
        {
            return myBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }
    }
}
