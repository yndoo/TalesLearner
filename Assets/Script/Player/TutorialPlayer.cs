using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float laskCheckTime;
    private float maxCheckDistance = 10f;
    public LayerMask checkLayer;

    private Camera playerCamera;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        if(Time.time - laskCheckTime > checkRate)
        {
            laskCheckTime = Time.time;

            // Ray ½÷¼­ Æ©Åä¸®¾ó ¿ÀºêÁ§Æ® Ã¼Å©
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * maxCheckDistance, Color.red);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, maxCheckDistance, checkLayer))
            {
                hit.collider.gameObject.GetComponent<TutorialObject>().SetTutorialUI();
            }
            else
            {
                // ºó °÷À» ½ð °æ¿ì 
                UIManager.Instance.DescriptionUI.SetActive(false);
            }
        }
    }
}