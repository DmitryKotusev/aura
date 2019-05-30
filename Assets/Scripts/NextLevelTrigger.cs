using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.parent != null && collider.gameObject.transform.parent.tag == "Player")
        {
            // Stop camera move
            GameObject.FindGameObjectWithTag("MoveController").SetActive(false);
            SaveHighestScore();
            Debug.Log("Loading next level");
        }
    }

    private void SaveHighestScore()
    {
        int currentKeyScore = GameObject.FindGameObjectWithTag("KeyCounter").GetComponent<KeyCounter>().GetKeys();
        int highestScore = FileDataController.GetLevelHighestScore(SceneManager.GetActiveScene().name);
        if (currentKeyScore > highestScore)
        {
            FileDataController.SetLevelHighestScore(SceneManager.GetActiveScene().name, currentKeyScore);
            FileDataController.SynchronizeDataWithStorage();
        }
    }
}
