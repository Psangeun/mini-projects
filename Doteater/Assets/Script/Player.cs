using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;

    GameManager gameManager;
    CharacterController charCtrl;
    Animator anim;

    public bool isEnemyStoped = false;

    void Start()
    {
        gameManager = GameObject.Find(name: "GameManager").GetComponent<GameManager>();
        charCtrl = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(dir.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, dir, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, dir));
            transform.LookAt(transform.position + forward);
        }
        charCtrl.Move(dir * moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", charCtrl.velocity.magnitude);

        if (GameObject.FindGameObjectsWithTag("Dot").Length < 1)
            SceneManager.LoadScene("Win");
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Dot":
                Destroy(other.gameObject);
                gameManager.AddScore(1);
                break;
            case "Item":
                Destroy(other.gameObject);
                enemyStop();
                Invoke("enemyMove", 3f);
                break;
            case "Enemy":
                if(!isEnemyStoped)
                {
                    SceneManager.LoadScene("Lose");
                }
                
                break;
        }
    }

    public void enemyStop()
    {
        isEnemyStoped = true;
    }

    public void enemyMove()
    {
        isEnemyStoped = false;
    }
}
