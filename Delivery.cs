using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Delivery : MonoBehaviour
{
	[SerializeField]
	private AudioSource methSoundFile;
	[SerializeField]
	private AudioSource waltSoundFile;
	
	bool timerActive = false;
	public static float currentTime;
	public TextMeshProUGUI currentTimeText;

 	[SerializeField] TextMeshProUGUI methScoreText;
	public int methScore = 0;
	public int maxMethScore = 5;
		
	public bool hasMeth;
	
	[SerializeField]
	float destroyTimer = 0.5f;
	
	public SpriteRenderer spriteRenderer;
	public Sprite hasMethSprite;
	public Sprite noMethSprite;
	
	private void Start() 
	{
		StartTimer();
	}
	
	private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Meth" && hasMeth == false)
		{
			hasMeth = true;
			Debug.Log("Picked up Meth");
			Destroy(other.gameObject, destroyTimer);
			methSoundFile.Play();
		}
		
		if (other.tag == "Walt" && hasMeth == true)
		{
			hasMeth = false;
			Debug.Log("Delivered Meth");
			waltSoundFile.Play();
			methScore++;
		}
	}
	
	private void Update() 
	{
		if (hasMeth == true)
		{
			spriteRenderer.sprite = hasMethSprite;	
		}	
		else
		
		{
			spriteRenderer.sprite = noMethSprite;
		}
		
		ShowMethScore();
		CompleteLevel();
		TimerGoing();
	}
	
	public void StartTimer()
	{
		timerActive = true;
	}
	
	public void StopTimer()
	{
		timerActive = false;
	}
	
	public void TimerGoing()
	{
		if (timerActive == true)
		
		{
			currentTime = currentTime + Time.deltaTime;
		}
		
		TimeSpan time = TimeSpan.FromSeconds(currentTime);
		currentTimeText.text = time.Minutes.ToString() + time.Seconds.ToString();
	}
	
	public void ShowMethScore()
	
	{
		methScoreText.text = (methScore + "/" + maxMethScore + " Meth");
	}
	
	public void CompleteLevel()
	{
		if (methScore == maxMethScore)
		{
			timerActive = false;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
