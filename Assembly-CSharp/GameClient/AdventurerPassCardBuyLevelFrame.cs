using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001430 RID: 5168
	public class AdventurerPassCardBuyLevelFrame : ClientFrame
	{
		// Token: 0x0600C883 RID: 51331 RVA: 0x0030B3BD File Offset: 0x003097BD
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AdventurerPassCard/AdventurerPassCardBuyLevel";
		}

		// Token: 0x0600C884 RID: 51332 RVA: 0x0030B3C4 File Offset: 0x003097C4
		protected override void _OnOpenFrame()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			this.buyLevels = null;
			this.InitBuyItems();
			this.UpdateBuyItems();
			this.BindUIEvent();
		}

		// Token: 0x0600C885 RID: 51333 RVA: 0x0030B410 File Offset: 0x00309810
		protected override void _OnCloseFrame()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			this.UnBindUIEvent();
			this.buyLevels = null;
		}

		// Token: 0x0600C886 RID: 51334 RVA: 0x0030B445 File Offset: 0x00309845
		protected override void _bindExUI()
		{
			this.Items = this.mBind.GetCom<ComUIListScript>("Items");
		}

		// Token: 0x0600C887 RID: 51335 RVA: 0x0030B45D File Offset: 0x0030985D
		protected override void _unbindExUI()
		{
			this.Items = null;
		}

		// Token: 0x0600C888 RID: 51336 RVA: 0x0030B466 File Offset: 0x00309866
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
		{
			this.UpdateBuyItems();
		}

		// Token: 0x0600C889 RID: 51337 RVA: 0x0030B46E File Offset: 0x0030986E
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateAventurePassStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassStatus));
		}

		// Token: 0x0600C88A RID: 51338 RVA: 0x0030B48B File Offset: 0x0030988B
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateAventurePassStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassStatus));
		}

		// Token: 0x0600C88B RID: 51339 RVA: 0x0030B4A8 File Offset: 0x003098A8
		private void InitBuyItems()
		{
			if (this.Items == null)
			{
				return;
			}
			this.Items.Initialize();
			this.Items.onBindItem = delegate(GameObject go)
			{
				if (go != null)
				{
					return go.GetComponent<AdventurerPassCardBuyItem>();
				}
				return null;
			};
			this.Items.onItemVisiable = delegate(ComUIListElementScript go)
			{
				if (go != null && this.buyLevels != null && go.m_index < this.buyLevels.Count)
				{
					AdventurerPassCardBuyItem component = go.GetComponent<AdventurerPassCardBuyItem>();
					if (component != null)
					{
						component.SetUp(this.buyLevels[go.m_index]);
					}
				}
			};
		}

		// Token: 0x0600C88C RID: 51340 RVA: 0x0030B514 File Offset: 0x00309914
		private void UpdateBuyItems()
		{
			if (this.Items == null)
			{
				return;
			}
			this.buyLevels = new List<int>();
			if (this.buyLevels == null)
			{
				return;
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<AdventurePassBuyLevelTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AdventurePassBuyLevelTable adventurePassBuyLevelTable = keyValuePair.Value as AdventurePassBuyLevelTable;
					if (adventurePassBuyLevelTable != null)
					{
						this.buyLevels.Add(adventurePassBuyLevelTable.ID);
					}
				}
			}
			this.Items.SetElementAmount(this.buyLevels.Count);
		}

		// Token: 0x0600C88D RID: 51341 RVA: 0x0030B5BA File Offset: 0x003099BA
		private void _OnUpdateAventurePassStatus(UIEvent uiEvent)
		{
			this.UpdateBuyItems();
		}

		// Token: 0x0400739D RID: 29597
		private List<int> buyLevels;

		// Token: 0x0400739E RID: 29598
		private ComUIListScript Items;
	}
}
