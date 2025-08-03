using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject mainMenuUI;
    public GameObject player;
    public CameraFollow cameraFollow;

    [Header("Camera")]
    public Transform menuCameraPosition; // Menü sýrasýnda kamera burada duracak

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        // Kamera menü pozisyonuna alýnýr
        if (menuCameraPosition != null)
            mainCamera.transform.position = menuCameraPosition.position;

        // Baþlangýçta kontrol ve takip kapalý
        player.GetComponent<TekneHareket>().enabled = false;
        cameraFollow.enabled = false;

        // Menü açýk
        mainMenuUI.SetActive(true);
    }

    public void StartGame()
    {
        // Menü kapanýr
        mainMenuUI.SetActive(false);

        // Gemi kontrolü açýlýr
        player.GetComponent<TekneHareket>().enabled = true;

        // Kamera takip aktif edilir
        cameraFollow.enabled = true;
    }
}
