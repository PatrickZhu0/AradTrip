using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017BA RID: 6074
	internal class ComDailyScriptTemplate<T> : MonoBehaviour where T : ClientFrame, new()
	{
		// Token: 0x0600EF86 RID: 61318 RVA: 0x004065E0 File Offset: 0x004049E0
		private void OnDestroy()
		{
			this.Name = null;
			this.Desc = null;
			this.awardParent = null;
			this.progressImage = null;
			if (this.slider != null)
			{
				this.slider.onValueChanged.RemoveAllListeners();
				this.slider = null;
			}
			this.progressText = null;
			this.progress = null;
			this.gray = null;
			if (this.award != null)
			{
				this.award.onClick.RemoveAllListeners();
				this.award = null;
			}
			if (this.go != null)
			{
				this.go.onClick.RemoveAllListeners();
				this.go = null;
			}
			this.complete = null;
		}

		// Token: 0x0600EF87 RID: 61319 RVA: 0x004066A0 File Offset: 0x00404AA0
		private void _RecycleComItems()
		{
			for (int i = 0; i < this.akComItems.Count; i++)
			{
				this.akComItems[i].Setup(null, null);
				this.akComItems[i].CustomActive(false);
				this.akCachedItems.Add(this.akComItems[i]);
			}
			this.akComItems.Clear();
		}

		// Token: 0x0600EF88 RID: 61320 RVA: 0x00406710 File Offset: 0x00404B10
		private void _OnItemClicked(GameObject obj, ItemData item)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x0600EF89 RID: 61321 RVA: 0x00406724 File Offset: 0x00404B24
		private void OnClickAward()
		{
			int num = 0;
			int num2 = 0;
			string empty = string.Empty;
			if (this.RewardIsHaveGoogLuckCharm(ref num, ref num2, ref empty))
			{
				if (num + (int)DataManager<PlayerBaseData>.GetInstance().WeaponLeaseTicket > num2)
				{
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("GoodLuckCharmDesc", num, empty, empty), delegate()
					{
						DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)this.value.missionItem.ID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
					}, null, 0f, false);
				}
				else
				{
					DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)this.value.missionItem.ID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
				}
				return;
			}
			DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)this.value.missionItem.ID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
		}

		// Token: 0x0600EF8A RID: 61322 RVA: 0x004067C8 File Offset: 0x00404BC8
		private bool RewardIsHaveGoogLuckCharm(ref int iGoodLuckCharmNum, ref int iGoodLuckCharmTatleNumber, ref string sGoodLuckCharmName)
		{
			bool result = false;
			List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(this.value.missionItem.ID, -1);
			for (int i = 0; i < missionAwards.Count; i++)
			{
				AwardItemData awardItemData = missionAwards[i];
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(awardItemData.ID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.Type == ItemTable.eType.INCOME || tableItem.SubType == ItemTable.eSubType.ST_WEAPON_LEASE_TICKET)
					{
						result = true;
						iGoodLuckCharmNum = awardItemData.Num;
						iGoodLuckCharmTatleNumber = tableItem.MaxNum;
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem.ID);
						if (commonItemTableDataByID != null)
						{
							sGoodLuckCharmName = commonItemTableDataByID.GetColorName(string.Empty, false);
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600EF8B RID: 61323 RVA: 0x00406892 File Offset: 0x00404C92
		private void OnClickGo()
		{
			if (this.value.missionItem != null)
			{
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(this.value.missionItem.LinkInfo, null, false);
			}
		}

		// Token: 0x0600EF8C RID: 61324 RVA: 0x004068C0 File Offset: 0x00404CC0
		public void OnVisible(MissionManager.SingleMissionInfo data, ClientFrame clientFrame)
		{
			this.value = data;
			this.frame = (clientFrame as T);
			MissionTable missionItem = this.value.missionItem;
			this.award.onClick.RemoveAllListeners();
			this.award.onClick.AddListener(new UnityAction(this.OnClickAward));
			this.go.onClick.RemoveAllListeners();
			this.go.onClick.AddListener(new UnityAction(this.OnClickGo));
			base.gameObject.name = missionItem.ID.ToString();
			this.Name.text = missionItem.TaskName;
			this.Desc.text = Utility.ParseMissionText(missionItem.ID, true, false, false);
			this._RecycleComItems();
			this.score.text = "x" + missionItem.MissionParam.ToString();
			this.VitalityValue.text = "x" + missionItem.VitalityValue;
			if (null != this.Icon)
			{
				ETCImageLoader.LoadSprite(ref this.Icon, missionItem.Icon, true);
				this.Icon.SetNativeSize();
			}
			List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(missionItem.ID, -1);
			for (int i = 0; i < missionAwards.Count; i++)
			{
				AwardItemData awardItemData = missionAwards[i];
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(awardItemData.ID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(awardItemData.ID, 100, 0);
					if (itemData != null)
					{
						itemData.Count = awardItemData.Num;
						ComItem comItem;
						if (this.akCachedItems.Count > 0)
						{
							comItem = this.akCachedItems[0];
							this.akCachedItems.RemoveAt(0);
						}
						else
						{
							comItem = this.frame.CreateComItem(this.awardParent);
						}
						if (comItem != null)
						{
							comItem.CustomActive(true);
							comItem.Setup(itemData, new ComItem.OnItemClicked(this._OnItemClicked));
							comItem.transform.SetSiblingIndex(i + 1);
							this.akComItems.Add(comItem);
						}
					}
				}
			}
			bool flag = this.value.status == 5;
			bool flag2 = false;
			if (flag)
			{
				this.complete.CustomActive(true);
				this.award.CustomActive(false);
				this.go.CustomActive(false);
				this.progress.CustomActive(false);
				this.acquired.CustomActive(true);
			}
			else
			{
				this.complete.CustomActive(false);
				this.acquired.CustomActive(false);
				bool flag3 = missionItem != null && missionItem.TaskFinishType == MissionTable.eTaskFinishType.TFT_LINKS && !string.IsNullOrEmpty(missionItem.LinkInfo) && this.value.status == 1;
				this.award.CustomActive(!flag3);
				this.go.CustomActive(flag3);
				this.progress.CustomActive(true);
				Utility.ContentProcess contentProcess = Utility.ParseMissionProcess(missionItem.ID, true);
				if (contentProcess != null)
				{
					if (contentProcess.iPreValue > contentProcess.iAftValue)
					{
						contentProcess.iPreValue = contentProcess.iAftValue;
					}
					this.slider.value = contentProcess.fAmount;
					this.progressText.text = contentProcess.iPreValue + "/" + contentProcess.iAftValue;
					flag2 = (this.value.status == 2);
				}
			}
			this.award.enabled = (!flag && flag2);
			this.gray.enabled = !this.award.enabled;
		}

		// Token: 0x040092C8 RID: 37576
		private MissionManager.SingleMissionInfo value;

		// Token: 0x040092C9 RID: 37577
		private T frame;

		// Token: 0x040092CA RID: 37578
		private List<ComItem> akComItems = new List<ComItem>();

		// Token: 0x040092CB RID: 37579
		private List<ComItem> akCachedItems = new List<ComItem>();

		// Token: 0x040092CC RID: 37580
		public Text Name;

		// Token: 0x040092CD RID: 37581
		public Text Desc;

		// Token: 0x040092CE RID: 37582
		public GameObject awardParent;

		// Token: 0x040092CF RID: 37583
		public Image progressImage;

		// Token: 0x040092D0 RID: 37584
		public Slider slider;

		// Token: 0x040092D1 RID: 37585
		public Text progressText;

		// Token: 0x040092D2 RID: 37586
		public GameObject progress;

		// Token: 0x040092D3 RID: 37587
		public UIGray gray;

		// Token: 0x040092D4 RID: 37588
		public Button award;

		// Token: 0x040092D5 RID: 37589
		public Button go;

		// Token: 0x040092D6 RID: 37590
		public Image complete;

		// Token: 0x040092D7 RID: 37591
		public Image acquired;

		// Token: 0x040092D8 RID: 37592
		public Text score;

		// Token: 0x040092D9 RID: 37593
		public Text VitalityValue;

		// Token: 0x040092DA RID: 37594
		public Image Icon;
	}
}
