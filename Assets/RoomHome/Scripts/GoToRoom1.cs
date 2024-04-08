using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToRoom1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LeftHand") || collision.gameObject.CompareTag("RightHand"))
        {
            SceneManager.LoadScene("Room1");
        }
    }
}
