using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Timeline;

public class Player_Controller : MonoBehaviour
{
    //PlayerSound sound;

    public AudioSource source;
    public AudioClip jumpSFX;
    public AudioClip coinSFX;
    public AudioClip hitSFX;

    public void PlayJump() { source.PlayOneShot(jumpSFX); }
    public void PlayCoin() { source.PlayOneShot(coinSFX); }
    public void PlayHit() { source.PlayOneShot(hitSFX); }


    [SerializeField] Transform center_pos;
    [SerializeField] Transform left_pos;
    [SerializeField] Transform right_pos;

    int current_pos = 0;
    
    public float side_speed;
    public float running_Speed;
    public float jump_Force;

    [SerializeField] Rigidbody rb;

    bool isGameStarted;
    bool isGameOver;

    [SerializeField] Animator player_Animator;

    [SerializeField] GameObject GameOverPanle;
    [SerializeField] GameObject Tap_To_Start_Canvas;

    [Header("Android Controls")]

    private float dragDistance; 
    private Vector3 fp;
    private Vector3 lp;

    void Start()
    {
        isGameStarted = false;
        isGameOver = false;
        current_pos = 0;
        dragDistance = Screen.height * 15 / 100; //dragDistance
    }

    void Update()
    {
        if (!isGameStarted || !isGameOver)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("Game is Started");
                isGameStarted = true;
                player_Animator.SetInteger("isRunning", 1);
                player_Animator.speed = 1.42f;
                Tap_To_Start_Canvas.SetActive(false);
            }
        }

        if (isGameStarted == true)
        {


            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + running_Speed * Time.deltaTime);

            // ---------------- PC SWIPE DETECTION ----------------
            // ---------------- PC SWIPE DETECTION ----------------
            if (Input.GetMouseButtonDown(0))
            {
                fp = Input.mousePosition;
                lp = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                lp = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                lp = Input.mousePosition;

                float swipeX = lp.x - fp.x;
                float swipeY = lp.y - fp.y;

                // HORIZONTAL swipe (Left/Right)
                if (Mathf.Abs(swipeX) > Mathf.Abs(swipeY) && Mathf.Abs(swipeX) > 80f)
                {
                    if (swipeX > 0)
                    {
                        // RIGHT SWIPE
                        Debug.Log("PC Right Swipe");

                        if (current_pos == 0) current_pos = 2;
                        else if (current_pos == 1) current_pos = 0;
                    }
                    else
                    {
                        // LEFT SWIPE
                        Debug.Log("PC Left Swipe");

                        if (current_pos == 0) current_pos = 1;
                        else if (current_pos == 2) current_pos = 0;
                    }
                }

                // VERTICAL swipe (JUMP)
                else if (Mathf.Abs(swipeY) > Mathf.Abs(swipeX) && Mathf.Abs(swipeY) > 80f)
                {
                    if (swipeY > 0)
                    {
                        // UP SWIPE (JUMP)
                        Debug.Log("PC Jump Swipe");

                        rb.linearVelocity = Vector3.up * jump_Force;
                        StartCoroutine(Jump());
                        //sound.PlayJump();

                        PlayJump();
                    }
                }
            }



#if UNITY_EDITOR
            if (current_pos == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    current_pos = 1;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    current_pos = 2;
                }
            }
            else if (current_pos == 1)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    current_pos = 0;
                }
            }
            else if (current_pos == 2)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    current_pos = 0;
                }
            }

#elif UNITY_ANDROID
            if (Input.touchCount == 1) // user is touching the screen with a single touch
            {
                Touch touch = Input.GetTouch(0); // get the touch
                if (touch.phase == TouchPhase.Began) //check for the first touch
                {
                    fp = touch.position;
                    lp = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
                {
                    lp = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
                {
                    lp = touch.position;     //last touch position. Omitted if you use list

                    //Check if drag distance is greater than 20% of the screen height
                    if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                    {//It's a drag
                     //check if the drag is vertical or horizontal
                        if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                        {
                            //If the horizontal movement is greater than the vertical movement...
                            if ((lp.x > fp.x)) //If the movement was to the right
                            {
                                //Right swipe
                                Debug.Log("Right Swipe");
                                if(current_pos == 0)
                                {
                                    current_pos = 2;
                                }
                                else if(current_pos == 1)
                                {
                                    current_pos = 0;
                                }
                            }
                            else
                            {
                                //Left swipe
                                Debug.Log("Left Swipe");
                                if(current_pos == 0)
                                {
                                    current_pos = 1;
                                }
                                else if(current_pos == 2)
                                {
                                    current_pos = 0;
                                }

                            }
                        }
                        else
                        {
                            //the vertical movement is greater than the horizontal movement
                            if (lp.y > fp.y) //If the movement was up
                            {
                                //Up swipe
                                Debug.Log("Up Swipe");
                                rb.linearVelocity = Vector3.up * jump_Force;
                                StartCoroutine(Jump());
                              //  sound.PlayJump();
                              PlayJump();
                            }
                            else
                            {
                                //Down swipe
                                Debug.Log("Down Swipe");
                            }
                        }
                    }
                    else
                    {
                        //It's a tap as the drag distance is less than 20% of the screen height
                        Debug.Log("Tap");
                    }
                }
            }
        }
#endif





            if (current_pos == 0)
            {
                if (Vector3.Distance(transform.position, new Vector3(center_pos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
                {
                    Vector3 dir = new Vector3(center_pos.position.x, transform.position.y, transform.position.z) - transform.position;
                    transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
                }
            }
            else if (current_pos == 1)
            {
                if (Vector3.Distance(transform.position, new Vector3(left_pos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
                {
                    Vector3 dir = new Vector3(left_pos.position.x, transform.position.y, transform.position.z) - transform.position;
                    transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
                }
            }
            else if (current_pos == 2)
            {
                if (Vector3.Distance(transform.position, new Vector3(right_pos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
                {
                    Vector3 dir = new Vector3(right_pos.position.x, transform.position.y, transform.position.z) - transform.position;
                    transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.linearVelocity = Vector3.up * jump_Force;
                StartCoroutine(Jump());
                //  sound.PlayJump();
                PlayJump();
            }

        }




        if(isGameOver)
        {
            if (!GameOverPanle.activeSelf)
            {
                GameOverPanle.SetActive(true);
            }

        }
    }

    IEnumerator Jump()
    {
        player_Animator.SetInteger("isJump", 1);
        yield return new WaitForSeconds(0.1f);
        player_Animator.SetInteger("isJump", 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "object")
        {
            //sound.PlayHit();
            PlayHit();

            isGameStarted = false;
            isGameOver = true;
            player_Animator.applyRootMotion = true;
            player_Animator.SetInteger("isDied", 1);
            
             
        }
    }

}
