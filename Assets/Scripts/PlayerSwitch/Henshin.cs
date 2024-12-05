using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Henshin : MonoBehaviour
{
    public bool isHenshin = false;
    public GameObject player1Object;  // Player1 trong Hierarchy
    public GameObject player2Prefab;  // Kéo prefab Player2 từ Project
    private GameObject currentPlayer;

    private Animator player2Animator;  // Biến lưu trữ Animator của Player2

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

        // Tạo player mới (Player2) tại vị trí cũ
        currentPlayer = Instantiate(player2Prefab, currentPosition, Quaternion.identity);
        isHenshin = true;

        // Cập nhật tham chiếu cho Animator của Player2
        player2Animator = currentPlayer.GetComponent<Animator>();

        // Kiểm tra nếu Animator đã được gán
        if (player2Animator != null)
        {
            // Bạn có thể thực hiện các thao tác với Animator của player2 tại đây
            // Ví dụ, nếu muốn bắt đầu animation Idle ngay sau khi chuyển đổi
            player2Animator.SetBool("isAlive", true);  // Giả sử có biến isAlive trong Animator
        }
        else
        {
            Debug.LogError("Không tìm thấy Animator trên Player2!");
        }

        // Cập nhật tham chiếu cho các đối tượng Enemy
        EnemyFollowPlayer[] enemies = FindObjectsOfType<EnemyFollowPlayer>();
        foreach (EnemyFollowPlayer enemy in enemies)
        {
            enemy.player = currentPlayer.transform;
        }
    }
}
