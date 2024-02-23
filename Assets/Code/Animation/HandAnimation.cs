using System;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private HandInput m_handInput;

    // Update is called once per frame
    void Update()
    {
        CheckForAnimations();
    }

    private void CheckForAnimations()
    {
        m_animator.Play("Pinch", -1, Math.Clamp(m_handInput.TriggerValue, 0f, 0.95f));
        m_animator.Play("Grip", -1, Math.Clamp(m_handInput.GripValue, 0f, 0.95f));
    }
}
