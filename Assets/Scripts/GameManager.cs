using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;

    public bool isPaused = false;

    public NoteScroller noteScroller;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public int currentCombo;

    public Text scoreText;
    public Text multiplierText;
    public Text comboText;

    private float totalNotes;
    private float normalHits;
    private float goodHits;
    private float perfectHits;
    private float missedHits;

    public GameObject resultsScreen;
    public GameObject pauseScreen;
    public Text percentHitText, normalText, goodText, perfectText, missText, rankText, finalScoreText;

    public KeyCode keyToPress;

    public GameObject health;
    private HealthBarController healthBarController;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        healthBarController = health.GetComponent<HealthBarController>();

        noteScroller.hasStarted = true;

        audioSource.Play();

        currentMultiplier = 1;
        currentCombo = 0;

        scoreText = GameObject.Find("ScoreValueText").GetComponent<Text>();
        multiplierText = GameObject.Find("MultiplierValueText").GetComponent<Text>();
        comboText = GameObject.Find("ComboValueText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        totalNotes = noteScroller.numNotes;

        if ((!audioSource.isPlaying && !resultsScreen.activeInHierarchy && !isPaused) ^ (healthBarController.healthAmount <= 0))
        {
            Time.timeScale = 0f;
            audioSource.Pause();
            resultsScreen.SetActive(true);

            normalText.text = normalHits.ToString();
            goodText.text = goodHits.ToString();
            perfectText.text = perfectHits.ToString();
            missText.text = missedHits.ToString();

            float totalHit = normalHits + goodHits + perfectHits;
            float percentHit = (totalHit / totalNotes) * 100f;

            percentHitText.text = percentHit.ToString("F1") + "%";

            string rankVal = "F";

            if (percentHit > 95)
            {
                rankVal = "S";
            }
            else if (percentHit > 85)
            {
                rankVal = "A";
            }
            else if (percentHit > 70)
            {
                rankVal = "B";
            }
            else if (percentHit > 55)
            {
                rankVal = "C";
            }
            else if (percentHit > 40)
            {
                rankVal = "D";
            }
            else
            {
                rankVal = "F";
            }

            rankText.text = rankVal;

            finalScoreText.text = currentScore.ToString();
        }

        if (Input.GetKeyDown(keyToPress) && !isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            audioSource.Pause();
            pauseScreen.SetActive(true);
        }
    }

    public void NoteHit()
    {

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        scoreText.text = currentScore.ToString();
        multiplierText.text = currentMultiplier.ToString();

        currentCombo++;
        comboText.text = currentCombo.ToString();

        healthBarController.healthAmount += 5;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed()
    {
        //Debug.Log("Note was missed.");

        healthBarController.healthAmount -= 20;

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplierText.text = currentMultiplier.ToString();

        currentCombo = 0;
        comboText.text = currentCombo.ToString();

        missedHits++;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        audioSource.Play();
        pauseScreen.SetActive(false);
        isPaused = false;
    }

    void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
