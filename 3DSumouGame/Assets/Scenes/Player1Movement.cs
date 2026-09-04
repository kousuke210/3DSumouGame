using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player1Movement : MonoBehaviour
{
    public float speed = 5.0f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 1P用の入力（1台目のコントローラーまたはキーボード）
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude > 0.1f)
        {
            direction.y = 0f;
            controller.SimpleMove(direction * speed);
        }
    }
}