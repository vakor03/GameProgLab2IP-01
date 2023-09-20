using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts
{
    public class NextLevel : MonoBehaviour
    {
        [SerializeField] private SceneName nextScene;
        [SerializeField] private LayerMask layerMask;
    
        private void OnTriggerEnter(Collider other)
        {
            if (ContainsLayer(layerMask, other.gameObject.layer))
            {
                SceneManager.LoadScene(nextScene.ToString());
            }
        }
        
        private bool ContainsLayer(LayerMask layerMask, int layer)
        {
            return layerMask == (layerMask | (1 << layer));
        }
    }
}