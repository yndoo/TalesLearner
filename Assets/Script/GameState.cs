using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public EGameState curState;

    private UIManager uiManager;
    private void Start()
    {
        uiManager = UIManager.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(curState)
        {
            case EGameState.GameStart:
                uiManager.RecordUI.StartRecord();
                uiManager.SysInfoUI.SetActive(true);
                uiManager.SysInfoUI.GetComponent<UISystemInfo>().SetUIFor5Seconds("��¼����� �����ϼ���.");
                break;
            case EGameState.GameEnd:
                
                uiManager.SysInfoUI.SetActive(true);
                uiManager.SysInfoUI.GetComponent<UISystemInfo>().SetUIFor5Seconds($"{uiManager.RecordUI.StopRecord()} ���� ����");
                SoundManager.Instance.PlayBGM(EBGMType.Victory);
                break;
        }
    }
}
