using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

    CharacterController controller;
    public bool isPaused;

    public Text countText;
    public Text winText;
    public Text loseText;

    public float moveSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public int deathCount = 0;

    private Vector3 moveDirection = Vector3.zero;

    private bool doubleJump = true;
    private bool grounded = true;

    private Vector3 startPosition = new Vector3(0, 1, 0);

    private int width = 250;
    private int height = 300;

    GameObject[] pauseObjects;

    void Start () {
        isPaused = false;
        controller = GetComponent<CharacterController>();
        deathCount = 0;
        Time.timeScale = 1;

        loseText.text = "";
        winText.text = "";

        pauseObjects = GameObject.FindGameObjectsWithTag("RestartButton");
      

        setDeathScore();
    }

	void Update () {

        CheckDead();

        moveDirection.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveDirection.z = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetButtonDown("Jump")) Jump();

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.Escape)) RestartGame();

        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;

        if (isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1.0f;
    }


    void Jump()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            doubleJump = true;
        }


        if (!controller.isGrounded && doubleJump)
        {
            moveDirection.y = jumpSpeed;
            doubleJump = false;
        }
    }

    void CheckDead()
    {
        if (controller.transform.position.y < -10f)
        {
            controller.transform.position = startPosition;
            deathCount++;
            setDeathScore();
        }

        if (deathCount >= 3)
        {
            loseText.text = "You lose!";
            Time.timeScale = 0;
            isPaused = true;
            //RestartGame();
        }
            

    }

    void setDeathScore()
    {
        countText.text = "Death Count: " + deathCount.ToString();
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }


    /*
    public void hidePaused()
    {
        foreach(GameObject go in pauseObjects)
        {
            go.SetActive(false);
        }
    }

    
    public void showPaused()
    {
        foreach (GameObject go in pauseObjects)
        {
            go.SetActive(true);
        }
    }*/

    void OnGUI()
    {
        if (isPaused)
        {
            float buttonWidth = 160;
            float buttonHeight = 30;
            float originX = (Screen.width - buttonWidth) / 2;
            float originY = (Screen.height - buttonHeight) / 2 + 10;
            Rect pos = new Rect(originX, originY, buttonWidth, buttonHeight);

            if (GUI.Button(pos, "Restart the game"))
            {
                RestartGame();
            }
        }
        
        
    }


}
