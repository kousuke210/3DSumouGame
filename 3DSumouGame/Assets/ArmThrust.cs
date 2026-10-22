using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArmThrust : MonoBehaviour
{
    [Tooltip("コントローラーのボタン指定")]
    [SerializeField] private KeyCode controllerButton = KeyCode.JoystickButton1;

    [Header("突き出しパラメータ")]
    [SerializeField] private float thrustForce = 500f;
    [SerializeField] private float thrustDuration = 0.12f;

    [Header("元の位置に戻る力")]
    [SerializeField] private float returnSpeed = 10f;
    [SerializeField] private float damping = 20f;

    private Rigidbody rb;
    private Quaternion initialLocalRotation;
    private bool isThrusting = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        initialLocalRotation = transform.localRotation;
    }

    private void Update()
    {
     
        // 割り当てられたボタンで実行
        if (Input.GetKeyDown(controllerButton) && !isThrusting)
        {
            StartCoroutine(ThrustRoutine());
        }
    }

    private void FixedUpdate()
    {
        if (!isThrusting)
        {
            ResetArmRotation();
        }
    }

    //腕を突き出す
    private IEnumerator ThrustRoutine()
    {
        isThrusting = true;
        float timer = 0f;

        while (timer < thrustDuration)
        {
            rb.AddForce(transform.forward * thrustForce, ForceMode.Force);
            rb.AddTorque(-transform.right * (thrustForce * 0.4f), ForceMode.Force);

            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        isThrusting = false;
    }

    //突き出した腕を戻す
    private void ResetArmRotation()
    {
        Quaternion targetLocal = Quaternion.Slerp(transform.localRotation, initialLocalRotation, Time.fixedDeltaTime * returnSpeed);
        Quaternion targetWorld = transform.parent != null ? transform.parent.rotation * targetLocal : targetLocal;

        Quaternion delta = targetWorld * Quaternion.Inverse(transform.rotation);
        delta.ToAngleAxis(out float angle, out Vector3 axis);

        if (angle > 180f) angle -= 360f;

        if (Mathf.Abs(angle) > 0.1f)
        {
            Vector3 targetAngularVelocity = axis.normalized * (angle * Mathf.Deg2Rad * returnSpeed);
            Vector3 torque = targetAngularVelocity - rb.angularVelocity;
            rb.AddTorque(torque * damping, ForceMode.Acceleration);
        }
    }
}