using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScenes : MonoBehaviour
{
    public int SceneNumber = 2;
    
    private void OnTriggerEnter2D(Collider2D other){
        SceneManager.LoadScene(SceneNumber);
        Time.timeScale = 1f;
    }
}
