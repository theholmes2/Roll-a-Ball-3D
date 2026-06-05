using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
   public float jumpPower=7;
    public int itemCount;
    public GameManagerLogic manager;
    bool isJump;
    Rigidbody rigid;
    AudioSource audio;

    void Awake(){
        isJump=false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        if (Input.GetButtonDown("Jump")&&!isJump)
        {
            isJump=true;
            rigid.AddForce(new Vector3(0, jumpPower, 0),ForceMode.Impulse);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        int CustomSpeed = 10;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3 (h* CustomSpeed, 0,v* CustomSpeed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            
            this.itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);

        }
        else if(other.tag=="Finish")
        {
            if(itemCount == manager.TotalItemCount)
            {
                if (manager.stage == 3)
                {
                    SceneManager.LoadScene("SampleScene1");
                }
                else
                {   //clear
                    SceneManager.LoadScene("SampleScene" + (manager.stage + 1).ToString());
                }
             
            }
            else
            {
                //reset
                SceneManager.LoadScene("SampleScene"+manager.stage.ToString());
            }
        }
    }
}
