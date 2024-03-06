using UnityEngine;

public class PlayerLocomotionController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private HandInput m_leftHandInput;
    [SerializeField] private HandInput m_rightHandInput;

    [Header("Gameplay")]
    private HandInput m_currentHandInput;
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private Transform m_playerHeadRig;

    [Header("Variables")]
    [SerializeField] private float m_movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        ChangeActiveHand(GameSettings.Instance.IsLeftHanded, true); //Initialise and set right hand as default
        GameSettings.Instance.OnChangedActiveHand += ChangeActiveHand;
    }

    private void ChangeActiveHand(bool isLeftHanded)
    {
        ChangeActiveHand(isLeftHanded, false);
    }

    private void ChangeActiveHand(bool isLeftHanded, bool isInitialising = false)
    {
        if (!isInitialising)
        {
            m_currentHandInput.OnStickMoved -= HandleInput;
            m_currentHandInput.OnSecondaryButtonPressed -= ResetPositionAndRotation;
        }

        m_currentHandInput = isLeftHanded ? m_leftHandInput : m_rightHandInput;

        m_currentHandInput.OnStickMoved += HandleInput;
        m_currentHandInput.OnSecondaryButtonPressed += ResetPositionAndRotation;
    }

    private void HandleInput(Vector2 vector)
    {
        Debug.Log(m_currentHandInput.gameObject.name + " hand, Move player: " + vector);
        m_rb.AddForce(((vector.y * m_playerHeadRig.transform.forward) * m_movementSpeed) * Time.deltaTime);
        m_rb.AddForce(((vector.x * m_playerHeadRig.transform.right) * m_movementSpeed) * Time.deltaTime);
    }

    private void ResetPositionAndRotation()
    {
        Debug.Log("Reset Position and Rotation");
        m_rb.linearVelocity = Vector3.zero;
        m_rb.rotation = Quaternion.identity;

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    private void OnDestroy()
    {
        GameSettings.Instance.OnChangedActiveHand -= ChangeActiveHand;
    }
}
