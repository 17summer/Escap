using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DoorRotate : MonoBehaviour
{

    public GameObject door;
    private Vector3 targetPosition;
    public float movePosition; 
    public float smoothness;
    public static int flag;

    public Text gameWin;
    public Button exit;
    public Text exitText;
    public float fadeInDuration = 2.0f;
    public Color gameWinColor;

    public AudioSource source;
    private void Start()
    {

        flag = 0;

        if (exit != null)
        {
            exit.gameObject.SetActive(false);
            Color textColor = exitText.color;
            textColor.a = 0f;
            exitText.color = textColor;
        }
        if(gameWin!=null)
        {
            gameWin.gameObject.SetActive(false);
            gameWinColor = gameWin.color;
            gameWinColor.a = 0f;
        }

        
        source = GetComponent<AudioSource>();   
    }   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && flag == 1)
        {
            //set targetPostion
            targetPosition= door.transform.position + new Vector3(0f,0f,movePosition);
            StartCoroutine(MoveSmoothly());
            StartCoroutine(FadeInText());
            StartCoroutine(WaitSomeTime());
            StartCoroutine(FadeIn());


        }
    }
    

    private IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(3);
        exit.gameObject.SetActive(true);
        gameWin.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        source.Play();
    }
    private IEnumerator MoveSmoothly()
    {
        while(Vector3.Distance(door.transform.position,targetPosition) > 0.01f)
        {
            door.transform.position = Vector3.Lerp(door.transform.position,targetPosition,smoothness*Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator FadeInText()
    {
        //time has passed
        float elapsedTime = 0f;
        Color textColor = exitText.color;

        while (elapsedTime < fadeInDuration)
        {
            // accumulate the alpha
            textColor.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            exitText.color = textColor;

            // update the time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // ensure the alpha get to 1
        textColor.a = 1f;
        exitText.color = textColor;
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);

            gameWin.color = new Color(gameWinColor.r, gameWinColor.g, gameWinColor.b, alpha);

            yield return null;

            elapsedTime += Time.deltaTime;
        }
        gameWin.color = new Color(gameWinColor.r, gameWinColor.g, gameWinColor.b, 1f);
    }
}
