using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BD3 RID: 7123
	public class TAPGrade : ClientFrame
	{
		// Token: 0x0601171A RID: 71450 RVA: 0x005107A1 File Offset: 0x0050EBA1
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAP/TAPGrade";
		}

		// Token: 0x0601171B RID: 71451 RVA: 0x005107A8 File Offset: 0x0050EBA8
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.myMissionList = (List<MissionInfo>)this.userData;
			}
			this.myMissionList.Sort(new Comparison<MissionInfo>(this._SortMissionList));
			this._RegisterUIEvent();
			this._InitComUIList();
			this._InitData();
		}

		// Token: 0x0601171C RID: 71452 RVA: 0x005107FA File Offset: 0x0050EBFA
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0601171D RID: 71453 RVA: 0x00510808 File Offset: 0x0050EC08
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0601171E RID: 71454 RVA: 0x0051080A File Offset: 0x0050EC0A
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0601171F RID: 71455 RVA: 0x0051080C File Offset: 0x0050EC0C
		private void _InitData()
		{
			if (this.myMissionList.Count != 0)
			{
				this.mMissionScrollView.SetElementAmount(this.myMissionList.Count);
			}
		}

		// Token: 0x06011720 RID: 71456 RVA: 0x00510834 File Offset: 0x0050EC34
		private int _SortMissionList(MissionInfo mission1, MissionInfo mission2)
		{
			if (mission1.status > mission2.status)
			{
				return 1;
			}
			if (mission1.status < mission2.status)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x06011721 RID: 71457 RVA: 0x0051085D File Offset: 0x0050EC5D
		private void _ClearData()
		{
			this.myMissionList.Clear();
		}

		// Token: 0x06011722 RID: 71458 RVA: 0x0051086C File Offset: 0x0050EC6C
		private void _InitComUIList()
		{
			this.mMissionScrollView.Initialize();
			this.mMissionScrollView.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateMissionBind(item);
				}
			};
			this.mMissionScrollView.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
			};
		}

		// Token: 0x06011723 RID: 71459 RVA: 0x005108C4 File Offset: 0x0050ECC4
		private void _UpdateMissionBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0)
			{
				return;
			}
			MissionInfo missionInfo = this.myMissionList[item.m_index];
			Text com = component.GetCom<Text>("MissionName");
			Text com2 = component.GetCom<Text>("Schedule");
			Text com3 = component.GetCom<Text>("Score");
			Image com4 = component.GetCom<Image>("bg");
			GameObject gameObject = component.GetGameObject("ScheduleImage");
			List<GameObject> list = new List<GameObject>();
			list.Clear();
			list.Add(component.GetGameObject("root1"));
			list.Add(component.GetGameObject("root2"));
			list.Add(component.GetGameObject("root3"));
			if (item.m_index % 2 == 0)
			{
				com4.CustomActive(true);
			}
			else
			{
				com4.CustomActive(false);
			}
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)missionInfo.taskID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				com.text = tableItem.TaskName;
				string text = Utility.ParseMissionTextForMissionInfo(missionInfo, false, false, true);
				if (text == "已完成")
				{
					gameObject.CustomActive(true);
					com2.text = string.Empty;
				}
				else
				{
					gameObject.CustomActive(false);
					com2.text = text;
				}
				string award = tableItem.Award;
				string[] array = award.Split(new char[]
				{
					','
				});
				if (array == null)
				{
					return;
				}
				for (int i = 0; i < list.Count; i++)
				{
					list[i].CustomActive(false);
				}
				for (int j = 0; j < array.Length; j++)
				{
					if (j <= 2)
					{
						int num = -1;
						int num2 = -1;
						string[] array2 = array[j].Split(new char[]
						{
							'_'
						});
						if (array2.Length != 2)
						{
							return;
						}
						int.TryParse(array2[0], out num);
						int.TryParse(array2[1], out num2);
						if (num != -1 && num2 != -1)
						{
							list[j].CustomActive(true);
							ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								com3.text = num2.ToString();
							}
							ComItem comItem = list[j].GetComponentInChildren<ComItem>();
							if (comItem == null)
							{
								comItem = base.CreateComItem(list[j]);
							}
							ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable(num, 100, 0);
							if (ItemDetailData == null)
							{
								return;
							}
							if (num2 > 10000 && num2 % 10000 == 0)
							{
								ItemDetailData.Count = 0;
								string tempStrCount = (num2 / 10000).ToString();
								comItem.SetCountFormatter((ComItem var) => tempStrCount + "万");
							}
							else
							{
								ItemDetailData.Count = num2;
								comItem.SetCountFormatter(null);
							}
							comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
							{
								this._OnShowTips(ItemDetailData);
							});
						}
					}
				}
			}
		}

		// Token: 0x06011724 RID: 71460 RVA: 0x00510C15 File Offset: 0x0050F015
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x06011725 RID: 71461 RVA: 0x00510C30 File Offset: 0x0050F030
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mMissionScrollView = this.mBind.GetCom<ComUIListScript>("MissionScrollView");
		}

		// Token: 0x06011726 RID: 71462 RVA: 0x00510C96 File Offset: 0x0050F096
		protected override void _unbindExUI()
		{
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			this.mMissionScrollView = null;
		}

		// Token: 0x06011727 RID: 71463 RVA: 0x00510CD3 File Offset: 0x0050F0D3
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<TAPGrade>(this, false);
		}

		// Token: 0x0400B528 RID: 46376
		private List<MissionInfo> myMissionList = new List<MissionInfo>();

		// Token: 0x0400B529 RID: 46377
		private Button mClose;

		// Token: 0x0400B52A RID: 46378
		private ComUIListScript mMissionScrollView;
	}
}
