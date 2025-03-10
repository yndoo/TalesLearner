using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ʃ�丮�� ������Ʈ ���� ���� ���̾��� �� -> ��������� ������Ʈ ���� ����
/// </summary>
public class TutorialPlayer : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float laskCheckTime;
    private float maxCheckDistance = 10f;
    public LayerMask checkLayer;

    private Camera playerCamera;
    public Transform myTrans;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        if (Time.time - laskCheckTime > checkRate)
        {
            laskCheckTime = Time.time;

            // Ray ���� Ʃ�丮�� ������Ʈ üũ
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxCheckDistance, checkLayer))
            {
                hit.collider.gameObject.GetComponent<TutorialObject>().SetInfoUI();
            }
            else
            {
                // �� ���� �� ��� 
                UIManager.Instance.DescriptionUI.SetActive(false);
            }
        }
    }
}