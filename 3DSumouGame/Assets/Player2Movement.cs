using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player2Movement : MonoBehaviour
{
    public float speed = 5.0f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 2P用の入力（2台目のコントローラー用）
        // ※もしInput Managerで名前を変えた場合は、ここの文字列も合わせてください
        float horizontal = Input.GetAxis("Horizontal_2P");
        float vertical = Input.GetAxis("Vertical_2P");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude > 0.1f)
        {
            direction.y = 0f;
            controller.SimpleMove(direction * speed);
        }
    }
}