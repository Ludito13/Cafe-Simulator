using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    #region Variables

    #region Publics
    [SerializeField] Transform orientation;
    [SerializeField] float rotSpeed;
    [SerializeField] [Range(0, 1)] float sensibilty;
    [SerializeField] float maxRot;
    [SerializeField] float minRot;
    #endregion

    #region Privates
    private float rotY;
    private float rotX;
    #endregion

    #endregion

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilty;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilty;

        rotY += mouseX;

        rotX += Mathf.Clamp(mouseY, minRot, maxRot);

        Quaternion rot = Quaternion.Euler(-rotX, rotY, 0f).normalized;

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotSpeed);
        orientation.rotation = Quaternion.Euler(0f, rotY, 0f);
    }
}
