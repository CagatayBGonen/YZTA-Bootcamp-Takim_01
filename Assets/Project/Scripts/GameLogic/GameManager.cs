using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject mainMenuUI;
    public GameObject player;
    public CameraFollow cameraFollow;

    [Header("Camera")]
    public Transform menuCameraPosition; // Men� s�ras�nda kamera burada duracak

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        // Kamera men� pozisyonuna al�n�r
        if (menuCameraPosition != null)
            mainCamera.transform.position = menuCameraPosition.position;

        // Ba�lang��ta kontrol ve takip kapal�
        player.GetComponent<TekneHareket>().enabled = false;
        cameraFollow.enabled = false;

        // Men� a��k
        mainMenuUI.SetActive(true);
    }

    public void StartGame()
    {
        // Men� kapan�r
        mainMenuUI.SetActive(false);

        // Gemi kontrol� a��l�r
        player.GetComponent<TekneHareket>().enabled = true;

        // Kamera takip aktif edilir
        cameraFollow.enabled = true;
    }
}
