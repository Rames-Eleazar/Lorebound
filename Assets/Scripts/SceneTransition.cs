using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 playerPosition;
    public VectorValue playerStorage;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}