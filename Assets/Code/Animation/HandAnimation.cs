using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private HandInput m_handInput;

    // Update is called once per frame
    void Update()
    {
        m_animator.SetFloat("Grip", m_handInput.GripValue);
        m_animator.SetFloat("Trigger", m_handInput.TriggerValue);
    }
}
