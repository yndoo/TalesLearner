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
    public Transform myTrans;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        //if(Time.time - laskCheckTime > checkRate)
        //{
        //    laskCheckTime = Time.time;

        //    // Ray ½÷¼­ Æ©Åä¸®¾ó ¿ÀºêÁ§Æ® Ã¼Å©
        //    //Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //    Ray ray = new Ray(myTrans.position + myTrans.forward * 0.2f + myTrans.up * 0.01f, myTrans.forward);
        //    RaycastHit hit;
        //    if(Physics.Raycast(ray, out hit, maxCheckDistance, checkLayer))
        //    {
        //        hit.collider.gameObject.GetComponent<TutorialObject>().SetTutorialUI();
        //    }
        //    else
        //    {
        //        // ºó °÷À» ½ð °æ¿ì 
        //        UIManager.Instance.DescriptionUI.SetActive(false);
        //    }
        //}
    }
}