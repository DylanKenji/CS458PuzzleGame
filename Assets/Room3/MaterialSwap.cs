using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MaterialSwap : MonoBehaviour
{
    public Material Found;
    public Material NotFoundYet;
    public AudioSource audioSource;
    public GameObject audioGameObject;

    private Renderer rend;
    private static int keysFoundCount = 0;
    private static readonly int totalKeys = 4; 

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = NotFoundYet;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key1") && gameObject.CompareTag("KeyHolder1"))
        {
            HandleKeyFound(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Key2") && gameObject.CompareTag("KeyHolder2"))
        {
            HandleKeyFound(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Key3") && gameObject.CompareTag("KeyHolder3"))
        {
            HandleKeyFound(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Key4") && gameObject.CompareTag("KeyHolder4"))
        {
            HandleKeyFound(collision.gameObject);
        }
    }

    void HandleKeyFound(GameObject key)
    {
        rend.material = Found;
        key.SetActive(false);
        PlayAudio();
        keysFoundCount++;

        Debug.Log("Keys found: " + keysFoundCount + "/" + totalKeys);

        if (keysFoundCount == totalKeys)
        {
            PlayCompletionAudio();
        }
    }

    void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void PlayCompletionAudio()
    {
        if (audioGameObject != null)
        {
            AudioSource completionAudioSource = audioGameObject.GetComponent<AudioSource>();
            if (completionAudioSource != null)
            {
                completionAudioSource.Play();
                RoomManager.MarkRoomCompleted(RoomManager.Room3);
                SceneManager.LoadScene("HomeRoom");
            }
        }
    }
}
