using UnityEngine;
using UnityEngine.InputSystem;   // WAJIB untuk Input System

public class PlayerMovement : MonoBehaviour
{
    public float kecepatan = 5f;

    public GameManajer gameManajer;

    private Vector2 arahGerak;  // nilai dari action "Move"

    // Dipanggil OTOMATIS oleh komponen Player Input
    // saat action "Move" pada asset InputSystem_Actions aktif.
    // Nama method WAJIB: On + nama action -> OnMove
    void OnMove(InputValue value)
    {
        // TODO: ambil nilai Vector2 dari input, simpan ke arahGerak
        arahGerak = value.Get<Vector2>();
    }

    void Update()
    {
        // TODO: gerakkan objek memakai arahGerak.
        // Ingat kalikan kecepatan DAN Time.deltaTime!
        Vector3 arah = new Vector3(arahGerak.x, arahGerak.y, 0);
        transform.position += arah * kecepatan * Time.deltaTime;
    }

    
    public int skor = 0;
    // Dipanggil otomatis saat Player menyentuh objek ber-Trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            
            // Menambah skor saat Player menyentuh Coin
            skor++;

            // Menampilkan skor di Console
            Debug.Log("Skor : " + skor);

            if (GameManajer.Instance != null)
            {
                GameManajer.Instance.AmbilKoin();
            } else {
                Debug.LogWarning("GameManajer tidak ditemukan di Scene! Pastikan sudah ditempel ke GameObject.");
            }
        }
    }
}
