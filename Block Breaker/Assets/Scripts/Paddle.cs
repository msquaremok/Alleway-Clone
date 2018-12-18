using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //config params
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float MaxX = 15f;
    [SerializeField] float MinX = 1f;

    //cached component ref
    GameStatus theGameSession;
    Ball theBall;

    void Start () {
        theGameSession = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }
	
	void Update () {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), MinX, MaxX);
        transform.position = paddlePos;
	}

    private float GetXPos()
    {
        if (theGameSession.AutoPlay())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }

    }
}
