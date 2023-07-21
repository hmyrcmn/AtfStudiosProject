using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerController controller;  // Playercontroller bileşeni için bir değişken
    private Vector3 direction;  // Hareket yönünü temsil eden vektör
    public float forwardSpeed=10f;  // İleri yöndeki hız değeri (Inspector üzerinden ayarlanabilir)

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();  // PlayerController bileşenini alıyoruz
    }

    void Update()
    {
        direction.z = forwardSpeed;  // direction vektörünün z bileşenine forwardSpeed değerini atıyoruz
    }

    // Düzgün hareket için FixedUpdate kullanmayı unutmayın
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);  // direction vektörünü zaman bazlı olarak hareket ettiriyoruz
    }
}
