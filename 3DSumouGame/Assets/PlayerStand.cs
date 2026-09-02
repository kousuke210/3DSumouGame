using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerStand : MonoBehaviour
{
    [Header("自立パラメータ")]
    [Tooltip("直立しようとする力（筋力）")]
    [SerializeField] private float uprightTorque = 150f;

    [Tooltip("揺れを抑える力（減衰）")]
    [SerializeField] private float damping = 15f;

    private Rigidbody rb;
    private Quaternion initialLocalRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void Start()
    {
        // ゲーム開始時のローカル角度（初期姿勢）を正しい立ち姿勢として記憶する
        initialLocalRotation = transform.localRotation;
    }

    private void FixedUpdate()
    {
        KeepUpright();
    }

    private void KeepUpright()
    {
        // 親（またはワールド）に対する現在のローカル回転と初期回転の差分を計算
        Quaternion currentLocalRotation = transform.localRotation;
        Quaternion targetRotation = initialLocalRotation;

        // ズレの角度（Rotation）を取得
        Quaternion deltaRotation = targetRotation * Quaternion.Inverse(currentLocalRotation);
        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);

        if (angle > 180f) angle -= 360f;

        if (Mathf.Abs(angle) > 0.001f)
        {
            // ローカル軸の回転ベクトルをワールド軸に変換してトルクを加える
            Vector3 worldAxis = transform.TransformDirection(axis.normalized);
            Vector3 targetAngularVelocity = worldAxis * (angle * Mathf.Deg2Rad * uprightTorque);
            Vector3 torque = targetAngularVelocity - rb.angularVelocity;

            rb.AddTorque(torque * damping, ForceMode.Acceleration);
        }
    }
}