using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArmThrust : MonoBehaviour
{
    [Header("キー設定")]
    [SerializeField] private KeyCode actionKey = KeyCode.Space;

    [Header("突き出しパラメータ")]
    [SerializeField] private float thrustForce = 500f;     // 前に突き出す力
    [SerializeField] private float thrustDuration = 0.12f; // 突き出し時間

    [Header("元の位置に戻る力（復元）")]
    [SerializeField] private float returnSpeed = 10f;      // 元の位置に戻る速さ
    [SerializeField] private float damping = 20f;          // 揺れを抑える力

    private Rigidbody rb;
    private Quaternion initialLocalRotation;
    private bool isThrusting = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // 初期角度（下ろした状態）を記憶
        initialLocalRotation = transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(actionKey) && !isThrusting)
        {
            StartCoroutine(ThrustRoutine());
        }
    }

    private void FixedUpdate()
    {
        // 突き出し時以外は、安全に初期角度へ引き戻す
        if (!isThrusting)
        {
            ResetArmRotation();
        }
    }

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

    /// <summary>
    /// 安定して腕を初期位置に戻す処理
    /// </summary>
    private void ResetArmRotation()
    {
        // 現在のローカル角度から初期角度への滑らかな補間目標を計算
        Quaternion targetLocal = Quaternion.Slerp(transform.localRotation, initialLocalRotation, Time.fixedDeltaTime * returnSpeed);

        // 親（胴体）の回転を考慮してワールド角度に変換
        Quaternion targetWorld = transform.parent != null ? transform.parent.rotation * targetLocal : targetLocal;

        // 目標角度への角速度（トルク）を計算して加える
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