using System;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    [SerializeField] private bool m_isLeftHanded;
    public bool IsLeftHanded => m_isLeftHanded;

    public event Action<bool> OnChangedActiveHand;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetActiveHand(bool isLeftHanded)
    {
        if (isLeftHanded != m_isLeftHanded)
        {
            m_isLeftHanded = isLeftHanded;
        }
    }
}
