using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovie : MonoBehaviour
{
    private Animator anim;

    private SpriteRenderer sr;
    
    private float speed = 3f;

    private float Min_X = -1.9f;

    private float Max_X = 3.86f;

    public Text Timer_text;

    private int timer;
  

    // Start is called before the first frame update
    void Awake()
    {

        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();

        
    }

    void Start()
    {
        Time.timeScale = 1f;

        StartCoroutine(CountTime());

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PlayerBound();
    }


    void PlayerBound()
    {
        Vector3 temp = transform.position;

        if(temp.x < Min_X)
        {
            temp.x = Min_X;

        }

        if (temp.x > Max_X)
        {
            temp.x = Min_X;

        }

        transform.position = temp;

    }

    void Move()
    {

        float h = Input.GetAxisRaw("Horizontal");


        //Debug.Log("Text: " + h);

        Vector3 temp = transform.position;

        if (h > 0)
        {
            temp.x += speed * Time.deltaTime;

            sr.flipX = false;

            anim.SetBool("Walk", true);
        }
        else if(h<0)
        {

            temp.x -= speed * Time.deltaTime;

            sr.flipX = true;

            anim.SetBool("Walk", true);

        }
        else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }

      //  temp.x += speed * Time.deltaTime;

        transform.position = temp;

    }


    IEnumerator CountTime()
    {

        yield return new WaitForSeconds(1f);

        timer++;

        Timer_text.text = "Timer : " + timer;

        StartCoroutine(CountTime());
             
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
       if(target.tag == "Knife")
        {

            Time.timeScale = 0f;

            StartCoroutine(RestartGame());
        }


    }
}
