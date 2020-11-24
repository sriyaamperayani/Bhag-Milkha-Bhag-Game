using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody playerRigidbody;

    Vector3 startPos, endPos;
    float moveTime;

    public AudioSource enemySound;
    public AudioSource coinSound;

    int score = 0;
    public Text scoreDisplay;
    int coins = 0;
    public Text coinDisplay;
    public Text highScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        scoreDisplay.text = "Score :" + score;
        coinDisplay.text = "Coins :" + coins;
        highScoreDisplay.text = "HighScore:" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemySound.Play();
            SceneManager.LoadScene("GameOver");
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinSound.Play();
            coins++;
            coinDisplay.text = "Coins :" + coins;
        }

    }


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitForPlatform());

    }
    IEnumerator WaitForPlatform()
    {
        yield return new WaitForSeconds(4f);
        score++;
        scoreDisplay.text = "Score : " + score;
        if(score>PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreDisplay.text = "HighScore:" + score.ToString();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && (playerRigidbody.velocity.y == 0))
        {
            playerAnimator.SetTrigger("Jump");
            playerRigidbody.velocity = new Vector3(0, 5f, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerAnimator.SetTrigger("Roll");

        }
        if(Input.GetKeyDown(KeyCode.RightArrow)&&(transform.position.x==0))
        {
            //transform.position = new Vector3(3, 0, 0);
            StartCoroutine(Move("Right"));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (transform.position.x == 0))
        {
            //transform.position = new Vector3(-3, 0, 0);
            StartCoroutine(Move("Left"));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && (transform.position.x == -3))
        {
            //transform.position = new Vector3(0, 0, 0);
            StartCoroutine(Move("Right"));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (transform.position.x == 3))
        {
            //transform.position = new Vector3(0, 0, 0);
            StartCoroutine(Move("Left"));
        }
    }
    IEnumerator Move(string whereToMove)
    {
        switch(whereToMove)
        {
            case "Right":
                moveTime = 0f;
                startPos = this.transform.position;
                endPos = new Vector3(this.transform.position.x + 3f, this.transform.position.y, this.transform.position.z);
                while (moveTime < 0.5f) 
                {
                    moveTime += 0.02f;
                    this.transform.position = Vector3.Lerp(startPos, endPos, moveTime / 0.5f);
                    yield return null;
                }
                break;
            case "Left":
                moveTime = 0f;
                startPos = this.transform.position;
                endPos = new Vector3(this.transform.position.x - 3f, this.transform.position.y, this.transform.position.z);
                while (moveTime < 0.5f)
                {
                    moveTime += 0.02f;
                    this.transform.position = Vector3.Lerp(startPos, endPos, moveTime / 0.5f);
                    yield return null;
                }
                break;
        }
    }

}
