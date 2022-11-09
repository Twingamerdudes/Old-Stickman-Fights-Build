using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ragdoll;
    public GameObject ragdollHips;
    public GameObject playerHips;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.sceneCount == 1)
        {
            StartCoroutine(delay());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerHips.GetComponent<PlayerController>().Die();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(5);
        ragdoll.SetActive(false);
        player.transform.position = new Vector3(ragdollHips.transform.position.x -1f, ragdollHips.transform.position.y, 0);
        player.SetActive(true);
    }
    IEnumerator delay2()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
    IEnumerator delay3()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
    public void PlayGame()
    {
        panel.SetActive(true);
        StartCoroutine(delay2());
    }
    public void MainMenu()
    {
        panel.SetActive(true);
        StartCoroutine(delay3());
    }
    public void Quit()
    {
        Application.Quit();
    }
}
