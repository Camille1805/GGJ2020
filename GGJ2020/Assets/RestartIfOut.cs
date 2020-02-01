using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartIfOut : MonoBehaviour
{
    float timer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 6f))
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0.0f)
        {
            Reload();
        }
    }

  
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ramp")
        {
            timer = 1f;
        }
    }

    private void Reload()
    {
        SceneManager.LoadScene(0);
    }
    
}
