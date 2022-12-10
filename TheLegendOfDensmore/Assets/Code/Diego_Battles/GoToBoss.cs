using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position.x > 25 && player.transform.position.y > 15) && (player.transform.position.x < 35 && player.transform.position.y < 25)){
            SceneManager.LoadScene("Level1Fadi");
        }
    }
}
