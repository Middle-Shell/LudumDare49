using UnityEngine;

public class generator : MonoBehaviour
{
    public GameObject Rukoyat;
    public GameObject Clickable;
    public Transform RotationPivot;

    //private GameManager gameManager;
    private Camera mainCam;
    private float angle;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        RotateToCursor();
    }

    private void RotateToCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = (RotationPivot.position - mainCam.transform.position).z;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(RotationPivot.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 170;

        Rukoyat.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
