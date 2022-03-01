using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014DC RID: 5340
	public class ChampionshipGuessBetRedPointControl : MonoBehaviour
	{
		// Token: 0x0600CF2F RID: 53039 RVA: 0x0033233E File Offset: 0x0033073E
		private void OnEnable()
		{
			this.UpdateGuessBetRedPoint();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipUpdateGuessBetRedPointMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipUpdateGuessBetRedPointMessage));
		}

		// Token: 0x0600CF30 RID: 53040 RVA: 0x00332361 File Offset: 0x00330761
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipUpdateGuessBetRedPointMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipUpdateGuessBetRedPointMessage));
		}

		// Token: 0x0600CF31 RID: 53041 RVA: 0x0033237E File Offset: 0x0033077E
		private void OnReceiveChampionshipUpdateGuessBetRedPointMessage(UIEvent uiEvent)
		{
			this.UpdateGuessBetRedPoint();
		}

		// Token: 0x0600CF32 RID: 53042 RVA: 0x00332388 File Offset: 0x00330788
		private void UpdateGuessBetRedPoint()
		{
			bool isShowGuessBetRedPoint = DataManager<ChampionshipDataManager>.GetInstance().IsShowGuessBetRedPoint;
			CommonUtility.UpdateGameObjectVisible(this.redPoint, isShowGuessBetRedPoint);
		}

		// Token: 0x04007921 RID: 31009
		[Space(10f)]
		[Header("RedPoint")]
		[Space(10f)]
		[SerializeField]
		private GameObject redPoint;
	}
}
