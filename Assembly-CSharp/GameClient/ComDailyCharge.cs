using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000023 RID: 35
	public class ComDailyCharge : MonoBehaviour
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x0000991F File Offset: 0x00007D1F
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnDayChargeChanged, new ClientEventSystem.UIEventHandler(this._OnDayChargeChanged));
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000993C File Offset: 0x00007D3C
		private void _OnDayChargeChanged(UIEvent uiEvent)
		{
			this._UpdateValue();
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00009944 File Offset: 0x00007D44
		private void _UpdateValue()
		{
			if (null != this.content)
			{
				string text = string.Empty;
				int num = 0;
				ActiveManager.ActivityData chargeItem = this.getChargeItem((int)DataManager<PlayerBaseData>.GetInstance().dayChargeNum);
				if (chargeItem != null)
				{
					num = chargeItem.activeItem.Param1 - (int)DataManager<PlayerBaseData>.GetInstance().dayChargeNum;
					text = string.Format(this.formatSting, DataManager<PlayerBaseData>.GetInstance().dayChargeNum, num, chargeItem.activeItem.Param0);
					if (null != this.state)
					{
						this.state.Key = "status_0";
					}
				}
				else
				{
					text = string.Format(this.formatSting2, DataManager<PlayerBaseData>.GetInstance().dayChargeNum, num);
					if (null != this.state)
					{
						this.state.Key = "status_1";
					}
				}
				this.content.text = text;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00009A38 File Offset: 0x00007E38
		private ActiveManager.ActivityData getChargeItem(int iValue)
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.iTemplateID);
			if (activeData != null)
			{
				for (int i = 0; i < activeData.akChildItems.Count; i++)
				{
					ActiveManager.ActivityData activityData = activeData.akChildItems[i];
					if (activityData != null && iValue < activityData.activeItem.Param1)
					{
						return activityData;
					}
				}
			}
			return null;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00009A9F File Offset: 0x00007E9F
		private void Start()
		{
			this._UpdateValue();
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00009AA7 File Offset: 0x00007EA7
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDayChargeChanged, new ClientEventSystem.UIEventHandler(this._OnDayChargeChanged));
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00009AC4 File Offset: 0x00007EC4
		public void OnClickGo()
		{
			if (!string.IsNullOrEmpty(this.linkString))
			{
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(this.linkString, null, false);
			}
		}

		// Token: 0x040000B3 RID: 179
		public int iTemplateID = 8500;

		// Token: 0x040000B4 RID: 180
		public string formatSting = string.Empty;

		// Token: 0x040000B5 RID: 181
		public string formatSting2 = string.Empty;

		// Token: 0x040000B6 RID: 182
		public string linkString = string.Empty;

		// Token: 0x040000B7 RID: 183
		public Text content;

		// Token: 0x040000B8 RID: 184
		public StateController state;
	}
}
