using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneManager : MonoBehaviour
{
    public Vector3 respawnPoint;
    public Transform player;

   public static CurrentSceneManager instance;

    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène");
            return;
        }

        instance = this;
        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

   /* void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Niveau 4")
        {
            player.scale.x = 0.55;
            player.scale. = 0.6;

        }
    }*/
}
