using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;
    [SerializeField] float jumpForce = 20f;
    private Rigidbody2D rb2D;
    public Animator anim;
    private Transform groundCheckPos;
    [SerializeField] LayerMask groundLayer;
    bool isGround = true;
    float Health = 100f;
    [SerializeField] Image HealthBar;
    [SerializeField] TMP_Text score;
   public int scoreCount = 0;

    int ufoComeCount = 0;
    [SerializeField] GameObject Ufo;
    [SerializeField] Transform UfoPos;
    [SerializeField] Transform UfoTransform;
    [SerializeField] Transform trushPos;
    Sequence seq = DOTween.Sequence();
  [SerializeField]  List<GameObject> Trushs = new List<GameObject>();
    public GameObject ObstacleSpawner;
  
    public static PlayerController instance;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        rb2D = GetComponent<Rigidbody2D>();
        groundCheckPos = transform.GetChild(0).transform;
        anim = GetComponent<Animator>();
     
    }
    void Start()
    {
    }

    void Update()
    {
        PlayerJump();
       
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    void MovePlayer() {
        rb2D.velocity = new Vector2(moveSpeed, rb2D.velocity.y);
    }

    //bool IsGrounded() {
    //    return Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
    //}

    public void PlayerJump() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            

            if (isGround) {
                anim.SetTrigger("Jump");
                rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isGround= false;
            }
        }
    }

    void AnimatePlayer()
    {
        //anim.SetFloat("Jump",rb2D.velocity.y);
        //anim.SetBool("Running",IsGrounded());
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Collectable")) {
            other.gameObject.SetActive(false);
            scoreCount++;
            score.text=scoreCount.ToString();
            ufoComeCount++;
            StartCoroutine(UfoCome());
            
        }
        if (other.CompareTag("Obstacle"))
        {
            gameObject.GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), 0.3f).SetLoops(4, LoopType.Yoyo).OnComplete(() =>
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            });
            Health -= 33f;
            HealthBar.fillAmount = Health / 100f;
            
        }
        if (Health<10)
        {
            moveSpeed = 0;
            anim.SetTrigger("Idle");
            Destroy(other.gameObject);
            ObstacleSpawner.SetActive(false);
            UIManager.instance.OpenFailPanel();
            UIManager.instance.OpenFailPanel();
        }

        if (other.CompareTag("DeadZ"))
        {
            moveSpeed = 0;
            rb2D.mass = 100;
            anim.SetTrigger("Idle");
        }
        if (other.CompareTag("Dead"))
        {
            HealthBar.fillAmount = 0;   
            //Time.timeScale = 0;
            ObstacleSpawner.SetActive(false);
            UIManager.instance.OpenFailPanel();

        }



    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            anim.SetTrigger("Run");
            isGround = true;
        }
    }

    public IEnumerator UfoCome()
    {
        if (ufoComeCount == 2)
        {
            moveSpeed= 0;
            anim.SetBool("Idle",true);
            seq.Append(Ufo.transform.DOMove(UfoTransform.position, 0.5f).OnComplete(() =>
            {
                Ufo.transform.GetChild(0).gameObject.SetActive(true);
                StartCoroutine(Wait());
            }));
            yield return new WaitForSeconds(2f);
            Ufo.transform.GetChild(0).gameObject.SetActive(false);
            moveSpeed = 11;
            ufoComeCount = 0;
            anim.SetBool("Idle", false);

            seq.Append(Ufo.transform.DOMove(UfoPos.position, 0.5f).OnComplete(() =>
            {
                
                
            }));
        }
    }

    IEnumerator Wait()
    {
        foreach (var item in Trushs)
        {
            item.SetActive(true);
            item.transform.DOMove(trushPos.position, 0.2f).OnComplete(() =>
            {
                item.SetActive(false);
                item.transform.localPosition = Vector3.zero;

            });
            yield return new WaitForSeconds(0.2f);
        }
        
    }
    public void Restart()
    {
        UIManager.instance.PausePanel.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void GoHome()
    {
        
        UIManager.instance.PausePanel.SetActive(false);
        UIManager.instance.HomePanel.SetActive(true);
        SceneManager.LoadScene(1);
      UIManager.instance.Button.transform.DOScale(1.25f, 1).SetLoops(-1, LoopType.Yoyo);
        UIManager.instance.Play.transform.DORotate(new Vector3(0,0,-1.5f),1).SetLoops(-1, LoopType.Yoyo);

    }

}
