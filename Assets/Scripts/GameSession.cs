using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    //config
    [Range(0f,10f)][SerializeField] float gameSpeed=1f;
    [SerializeField] int pointPerBlock=83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    //Cached refs


    //state
    [SerializeField] int currentScore = 0;

 

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if(gameStatusCount>1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }


    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void AddToScore()
    {
        currentScore += pointPerBlock;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return this.isAutoPlayEnabled;
    }
}
