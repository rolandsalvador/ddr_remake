using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;

    public bool startPlaying;

    public NoteScroller noteScroller;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public int currentCombo;

    public Text scoreText;
    public Text multiplierText;
    public Text comboText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        currentMultiplier = 1;
        currentCombo = 0;

        scoreText = GameObject.Find("ScoreValueText").GetComponent<Text>();
        multiplierText = GameObject.Find("MultiplierValueText").GetComponent<Text>();
        comboText = GameObject.Find("ComboValueText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                noteScroller.hasStarted = true;

                audioSource.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Note hit on time.");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = currentScore.ToString();
        multiplierText.text = currentMultiplier.ToString();

        currentCombo++;
        comboText.text = currentCombo.ToString();
    }

    public void NoteMissed()
    {
        Debug.Log("Note was missed.");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplierText.text = currentMultiplier.ToString();

        currentCombo = 0;
        comboText.text = currentCombo.ToString();
    }
}
