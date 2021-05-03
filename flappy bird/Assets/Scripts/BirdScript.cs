using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BirdScript : MonoBehaviour
{
    bool oneTime = true;
    public Text scoreText;
    int score = 0;
    public GameObject ReplayButton;
    bool isDead;
    Rigidbody2D rbd2d;
    public float speed=5f;
    [SerializeField]
    private float flapForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        rbd2d = GetComponent<Rigidbody2D>();
        rbd2d.velocity = Vector2.right * speed * Time.deltaTime;
    }
    private void Awake()
    {
     
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isDead = true;
        rbd2d.velocity = Vector2.zero;
        ReplayButton.SetActive(true);

        GetComponent<Animator>().SetBool("isDead", true);
    }
    public void Replay()
    {
    
        SceneManager.LoadScene(0);
    }
    public void Unfreeze()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            
            rbd2d.velocity = Vector2.right * speed * Time.deltaTime;
            rbd2d.AddForce(Vector2.up * flapForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Score" && oneTime)
        {
            oneTime = false;
            score++;
            Debug.Log(score);
            scoreText.text = score.ToString();
        }

        

    }
}