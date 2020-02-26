using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownScript : MonoBehaviour
{
    public GameObject PlayAgain;
    public Text countDownText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
  // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlayAgain.SetActive(false);
            StartCoroutine(CountDown());
        }
    }
    IEnumerator CountDown()
    {
        countDownText.text = "3";
        yield return new WaitForSeconds(1);
        countDownText.text = "2";
        yield return new WaitForSeconds(1);
        countDownText.text = "1";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
