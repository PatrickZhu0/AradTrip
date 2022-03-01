using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001365 RID: 4965
	public class AccumulativeSignIn : MonoBehaviour
	{
		// Token: 0x0600C0D4 RID: 49364 RVA: 0x002DB534 File Offset: 0x002D9934
		private void Start()
		{
			this.mSignInCount = null;
			this.mBoxBt = null;
			this.mTeXiao = null;
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this.UpdateSignInCount));
			ComCommonBind component = base.gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				Logger.LogErrorFormat("Can not find ComcomonBind in AccumulativeSighIn", new object[0]);
			}
			else
			{
				this.mTeXiao = component.GetGameObject("TeXiao");
				if (this.mTeXiao == null)
				{
					Logger.LogErrorFormat("mTeXiao is null", new object[0]);
					return;
				}
				this.mTeXiao.CustomActive(false);
				this.mSignInCount = component.GetCom<Text>("SignInCount");
				if (this.mSignInCount != null)
				{
					int activeItemValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(1940, "tt_si", 0);
					this.mSignInCount.text = activeItemValue + "/30";
				}
				this.mBoxBt = component.GetCom<Button>("BoxBt");
				if (this.mBoxBt == null)
				{
					Logger.LogErrorFormat("BoxBt is null", new object[0]);
				}
				else
				{
					if (DataManager<ActiveManager>.GetInstance().GetActiveItemValue(1940, "tt_si", 0) == 30)
					{
						this.IsOpen = true;
					}
					else
					{
						this.IsOpen = false;
					}
					this.AddBtState();
				}
			}
		}

		// Token: 0x0600C0D5 RID: 49365 RVA: 0x002DB6A8 File Offset: 0x002D9AA8
		private void OnDestroy()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this.UpdateSignInCount));
			if (this.mBoxBt != null)
			{
				this.mBoxBt.onClick.RemoveAllListeners();
				this.mBoxBt = null;
			}
		}

		// Token: 0x0600C0D6 RID: 49366 RVA: 0x002DB704 File Offset: 0x002D9B04
		private void AddBtState()
		{
			if (this.IsOpen)
			{
				this.mTeXiao.CustomActive(true);
			}
			else
			{
				this.mTeXiao.CustomActive(false);
			}
			this.mBoxBt.onClick.RemoveAllListeners();
			this.mBoxBt.onClick.AddListener(delegate()
			{
				ActiveAwardFrameDataNew activeAwardFrameDataNew = new ActiveAwardFrameDataNew();
				List<AwardItemData> list = new List<AwardItemData>();
				ActiveTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveTable>(1940, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("Can not get activeTableData from id:1940", new object[0]);
					return;
				}
				string[] array = tableItem.Awards.Split(new char[]
				{
					'_'
				});
				AwardItemData awardItemData = new AwardItemData();
				int num = -1;
				int num2 = -1;
				int.TryParse(array[0], out num);
				int.TryParse(array[1], out num2);
				if (num == -1 || num2 == -1)
				{
					Logger.LogErrorFormat("ActiveTableData is Error", new object[0]);
					return;
				}
				awardItemData.ID = num;
				awardItemData.Num = num2;
				list.Add(awardItemData);
				activeAwardFrameDataNew.title = "签到额外奖励";
				activeAwardFrameDataNew.datas = list;
				activeAwardFrameDataNew.canGet = this.IsOpen;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActiveAwardFrameNew>(FrameLayer.Middle, activeAwardFrameDataNew, string.Empty);
			});
		}

		// Token: 0x0600C0D7 RID: 49367 RVA: 0x002DB768 File Offset: 0x002D9B68
		private void UpdateSignInCount(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			if (data.ID == 1940)
			{
				int activeItemValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(1940, "tt_si", 0);
				this.mSignInCount.text = activeItemValue + "/30";
				if (data.status == 2)
				{
					this.IsOpen = true;
				}
				else
				{
					this.IsOpen = false;
				}
				this.AddBtState();
			}
		}

		// Token: 0x04006CF5 RID: 27893
		private Text mSignInCount;

		// Token: 0x04006CF6 RID: 27894
		private Button mBoxBt;

		// Token: 0x04006CF7 RID: 27895
		private GameObject mTeXiao;

		// Token: 0x04006CF8 RID: 27896
		private bool IsOpen;
	}
}
