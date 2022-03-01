using System;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x020013AE RID: 5038
[RequireComponent(typeof(Button))]
internal class OnOpenActiveFrame : MonoBehaviour
{
	// Token: 0x0600C393 RID: 50067 RVA: 0x002ED675 File Offset: 0x002EBA75
	private void Start()
	{
		this.m_kButton = base.GetComponent<Button>();
		this.m_kButton.onClick.RemoveAllListeners();
		this.m_kButton.onClick.AddListener(new UnityAction(this.OnClick));
	}

	// Token: 0x0600C394 RID: 50068 RVA: 0x002ED6B0 File Offset: 0x002EBAB0
	private void OnClick()
	{
		if (this.iActiveTypeID == 9380)
		{
			DataManager<WarriorRecruitDataManager>.GetInstance().SendQueryTaskStatusReq();
		}
		DataManager<ActiveManager>.GetInstance().OpenActiveFrame(this.iActiveTypeID, 0);
		ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
		if (clientSystemTownFrame != null)
		{
			clientSystemTownFrame.UpdateBeStrongExpand(false);
		}
	}

	// Token: 0x04006F0A RID: 28426
	private Button m_kButton;

	// Token: 0x04006F0B RID: 28427
	public int iActiveTypeID;
}
