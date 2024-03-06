using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    [SerializeField] private Transform cameraParent;
    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(-cameraParent.transform.localEulerAngles.x, transform.localEulerAngles.y, -cameraParent.transform.localEulerAngles.z);
        transform.localRotation = rotation;
    }
}
