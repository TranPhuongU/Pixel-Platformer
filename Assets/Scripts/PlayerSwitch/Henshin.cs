using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Henshin : MonoBehaviour
{
    public GameObject player1Prefab;  // Kéo prefab Player1 từ Project
    public GameObject player2Prefab;  // Kéo prefab Player2 từ Project

    private GameObject currentPlayer;

    void Start()
    {
        // Khởi tạo Player1 ban đầu
        currentPlayer = Instantiate(player1Prefab);
    }

    public void SwitchToPlayer2()
    {
        // Lưu vị trí của player hiện tại
        Vector3 currentPosition = currentPlayer.transform.position;

        // Hủy player hiện tại
        Destroy(currentPlayer);

        // Tạo player mới tại vị trí cũ
        currentPlayer = Instantiate(player2Prefab, currentPosition, Quaternion.identity);
    }
}
