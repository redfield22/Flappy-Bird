using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public int score;
    public Text Scoretext;
    public GameObject gameoverscreen;
    public Text HighScoreText;
    public bool scoreAddition = true;
    public AudioSource earn_sound;
    public pipeSpawner spawner;
    public GameObject Background;

    [ContextMenu("score_points")]
    public void addscore(int AddScore)
    {
        if (scoreAddition)
        {
            score = score + 1 + AddScore;
            Scoretext.text = score.ToString();
            earnSound();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameoverscreen.SetActive(true);
    }
    public void earnSound()
    {
        earn_sound.Play();
    }
    public void GotoMainmenu()
    {
        SceneManager.LoadScene("Main menu");
    }
    public void move_the_world(float dist)
    {
        Vector3 shift = Vector3.right * dist;
        Vector3 back_shift = Vector3.right * (dist);

        foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe"))
        {
            pipe.transform.position += shift;
        }
    }
}

