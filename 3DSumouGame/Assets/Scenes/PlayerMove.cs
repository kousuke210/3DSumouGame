using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // WASD入力（または矢印キー）を取得
        float horizontal = Input.GetAxis("Horizontal"); // A, D / 左, 右
        float vertical = Input.GetAxis("Vertical");     // W, S / 上, 下

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude > 0.1f)
        {
            // 向いている方向に移動させる
            controller.SimpleMove(direction * speed);
        }
    }
}