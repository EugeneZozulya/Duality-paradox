using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    public int waittime = 38;
    public GameObject Panel;
    public GameObject Panel1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(waittime);
        Panel1.SetActive(false);
        Panel.SetActive(true);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            waittime = 0;
            Panel1.SetActive(false);
            Panel.SetActive(true);
        }
    }
}
