using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 100;
    [SerializeField] private float jumpforce = 5.5f;
    private bool IsGrounded;
    [SerializeField] private int gems;
    [SerializeField] Text hpText;
    [SerializeField] Text diamondsText;

    public GameObject HellGameOverPanel;
    public GameObject HellWinPanel;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HPLost");
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        gems = 0;
        hpText.text = lives.ToString();
        diamondsText.text = gems.ToString() +"/8";
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
        if (Input.GetButton("Horizontal")) Run();
        if (IsGrounded && Input.GetButtonDown("Jump")) Jump();

    }
    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        IsGrounded = collider.Length > 1;
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "diamond")
        {
            Destroy(other.gameObject);
            gems++;
            diamondsText.text = gems.ToString()+"/8";
        }
        if (other.tag == "deathzone")
            lives = 0;
    }
    IEnumerator HPLost()
    {
        
        while (gems != 8 && lives > 0)
        {
            lives -= 1;
            hpText.text = lives.ToString();
            yield return new WaitForSeconds(0.4f);
        }
        GameOver();
    }
    void GameOver()
    {
        
        HellGameOverPanel.SetActive(true);
    }
    void CheckGameOver()
    {
        
        if (lives<=0)
        {
            GameOver();
        }
        if (gems == 8)
        {
            Win();
        }
    }
    void Win()
    {
        HellWinPanel.SetActive(true);
        HellGameOverPanel.SetActive(false);
    }
}
