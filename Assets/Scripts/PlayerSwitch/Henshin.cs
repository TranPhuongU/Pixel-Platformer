using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Henshin : MonoBehaviour
{
    public GameObject player1Object;  // Player1 trong Hierarchy
    public GameObject player2Prefab; // Kéo prefab Player2 từ Project
    private GameObject currentPlayer;

    void Start()
    {
        // Gán player1Object làm player hiện tại
        currentPlayer = player1Object;
    }

    public void SwitchToPlayer2()
    {
        // Lưu vị trí của player hiện tại
        Vector3 currentPosition = currentPlayer.transform.position;

        // Hủy player hiện tại
        Destroy(currentPlayer);

        // Tạo player mới tại vị trí cũ
        currentPlayer = Instantiate(player2Prefab, currentPosition, Quaternion.identity);

        // Cập nhật tham chiếu cho các đối tượng Enemy
        EnemyFollowPlayer[] enemies = FindObjectsOfType<EnemyFollowPlayer>();
        foreach (EnemyFollowPlayer enemy in enemies)
        {
            enemy.player = currentPlayer.transform;
        }
    }

}
