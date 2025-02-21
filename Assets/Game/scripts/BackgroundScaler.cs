using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mainCamera = Camera.main; // Ana kamera referans� al
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer'� al
        AdjustBackgroundScale(); // Ba�lang��ta arka plan �l�e�ini ayarla
    }

    void Update()
    {
        // Ekran boyutu de�i�ti�inde arka plan�n �l�e�ini yeniden ayarla
        AdjustBackgroundScale();
    }

    void AdjustBackgroundScale()
    {
        // Ekran ��z�n�rl���n� al
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Kamera ��z�n�rl��� ile uyumlu olacak �ekilde arka plan�n �l�e�ini ayarla
        float aspectRatio = (float)screenWidth / screenHeight;

        // Kamera ��z�n�rl��� ile uyumlu sprite boyutunu hesapla
        float cameraHeight = mainCamera.orthographicSize * 2; // Kamera y�ksekli�i
        float cameraWidth = cameraHeight * aspectRatio; // Kamera geni�li�i

        // Sprite'�n boyutlar�n� al
        float spriteWidth = spriteRenderer.sprite.bounds.size.x;
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;

        // Ekran� tamamen kaplayacak �ekilde sprite �l�eklendir
        float scaleWidth = cameraWidth / spriteWidth;
        float scaleHeight = cameraHeight / spriteHeight;

        // En uygun �l�ek oran�n� se�
        float scale = Mathf.Max(scaleWidth, scaleHeight); // Hem geni�li�i hem de y�ksekli�i kapsayacak �ekilde

        // Yeni �l�e�i uygula
        transform.localScale = new Vector3(scale, scale, 1);

        // Arka plan�n pozisyonunu s�f�rla, b�ylece ekran�n tam ortas�nda olur
        transform.position = new Vector3(0, 0, transform.position.z);
    }
}
