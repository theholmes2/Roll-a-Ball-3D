using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManagerLogic : MonoBehaviour
{
    public int TotalItemCount;
    
    public int stage;
    public TMP_Text stageCountText;
    public TMP_Text PlayerCountText;


    private void Awake()
    {
        stageCountText.text = "/ " + TotalItemCount.ToString();
    }

    public void GetItem(int count)
    {
        PlayerCountText.text=count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(stage-1);
        }
    }
}
