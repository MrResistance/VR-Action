using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string m_destinationSceneName;
    [SerializeField] private LayerMask m_playerLayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            SceneManager.LoadScene(m_destinationSceneName);
        }
    }
}
