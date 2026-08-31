using System.Collections;
using UnityEngine;
using Cinemachine; // Cinemachine 3.x の場合は using Unity.Cinemachine;

public class CameraIntroDirector : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera introCamera;
    [SerializeField] private float waitSeconds = 1.0f; // 引きの状態で静止する秒数

    private void Start()
    {
        StartCoroutine(SwitchToGameCamera());
    }

    private IEnumerator SwitchToGameCamera()
    {
        // 指定した秒数だけ待機
        yield return new WaitForSeconds(waitSeconds);

        // 引きカメラを無効化（自動的にGameカメラへブレンド開始）
        if (introCamera != null)
        {
            introCamera.gameObject.SetActive(false);
            // または introCamera.Priority = 0; でもOK
        }
    }
}