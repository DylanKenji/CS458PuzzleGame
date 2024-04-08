using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// this script keeps a track of all the "keys" for room 3 (scavenger hunt).
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
        // when matching key to holder is met, it changes the materual from notfoundyet parameter
        // to the found parameter.
        rend = GetComponent<Renderer>();
        rend.material = NotFoundYet;
    }

    // when the key to holder is matched, it sets the key to no longer be active, plays audio for matching,
    // and also adds to the keys found counter, out of 4.
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

        // just some console messages for testing
        Debug.Log("Keys found: " + keysFoundCount + "/" + totalKeys);

        // if keys found are 4 out of the total of 4, call the function
        if (keysFoundCount == totalKeys)
        {
            PlayCompletionAudio();
        }
    }

    // plays audio from audio source parameter
    void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
    
    // plays the completion audio from audio source parameter.
    // At the same time, it will mark the room as complete so that the "button" in the Home room
    // changes to green via the RoomManager script.
    // Then, it changes the scene to HomeRoom
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
