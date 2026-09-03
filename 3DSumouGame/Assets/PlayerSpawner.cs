using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform player1;      // すでにいるPlayer1
    [SerializeField] private GameObject player2Prefab; // 生成したいPlayer2のプレハブ

    void Start()
    {
        SpawnPlayer2();
    }

    public void SpawnPlayer2()
    {
        if (player1 == null || player2Prefab == null) return;

        Vector3 pos1 = player1.position;
        Vector3 rot1 = player1.eulerAngles;

        // 反対側の座標・回転を計算
        Vector3 oppositePos = new Vector3(-pos1.x, pos1.y, -pos1.z);
        float oppositeRotY = (rot1.y + 180f) % 360f;
        Quaternion oppositeRot = Quaternion.Euler(rot1.x, oppositeRotY, rot1.z);

        // 生成する
        Instantiate(player2Prefab, oppositePos, oppositeRot);
    }
}