using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BF8 RID: 7160
	public class SubmitItemDlg : ClientFrame
	{
		// Token: 0x060118BC RID: 71868 RVA: 0x0051AF24 File Offset: 0x00519324
		protected List<ulong> GetItemToShow(int iMissionID)
		{
			if (this.param1 == 0U)
			{
				List<ulong> list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
				if (list.Count > 0)
				{
					list = list.FindAll(delegate(ulong id)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
						if (item == null)
						{
							return false;
						}
						if (item.bLocked)
						{
							return false;
						}
						uint quality = (uint)item.Quality;
						if (item.EquipType == EEquipType.ET_REDMARK)
						{
							return false;
						}
						if ((long)item.LevelLimit < (long)((ulong)this.param3))
						{
							return false;
						}
						if (quality < this.param2)
						{
							return false;
						}
						if (item.IsItemInUnUsedEquipPlan)
						{
							return false;
						}
						bool flag = false;
						if (this.param2 == 1U)
						{
							if (quality >= 1U && quality <= 2U)
							{
								flag = true;
							}
						}
						else if (quality == this.param2)
						{
							flag = true;
						}
						return flag && item.StrengthenLevel < 8;
					});
					list.Sort(delegate(ulong left, ulong right)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(left);
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(right);
						if (item2 == null || item == null)
						{
							return 0;
						}
						if (item2.Quality == item.Quality)
						{
							if (item2.LevelLimit == item.LevelLimit)
							{
								return 0;
							}
							if (item2.LevelLimit > item.LevelLimit)
							{
								return -1;
							}
							return 1;
						}
						else
						{
							if (item2.Quality > item.Quality)
							{
								return -1;
							}
							return 1;
						}
					});
				}
				return list;
			}
			if (this.param1 == 1U)
			{
				List<ulong> list2 = new List<ulong>();
				ItemData itemByTableID = DataManager<ItemDataManager>.GetInstance().GetItemByTableID((int)this.param2, true, true);
				if (itemByTableID != null)
				{
					if (!itemByTableID.IsItemInUnUsedEquipPlan)
					{
						list2.Add(itemByTableID.GUID);
					}
				}
				return list2;
			}
			Logger.LogErrorFormat("[上交物品任务]，任务<{0}>,MissionParam1 错{1}，目前只支持（0装备，1材料)", new object[]
			{
				iMissionID,
				this.param1
			});
			return null;
		}

		// Token: 0x060118BD RID: 71869 RVA: 0x0051B000 File Offset: 0x00519400
		protected override void _OnOpenFrame()
		{
			int num = (int)this.userData;
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(num, string.Empty, string.Empty);
			if (tableItem != null)
			{
				string[] array = tableItem.MissionParam.Split(new char[]
				{
					','
				});
				if (array.Length != 3)
				{
					Logger.LogErrorFormat("[上交物品任务]，任务<{0}>,{1}参数个数填错 {2} != 3", new object[]
					{
						num,
						tableItem.TaskName,
						array.Length
					});
				}
				try
				{
					this.param1 = uint.Parse(array[0]);
					this.param2 = uint.Parse(array[1]);
					this.param3 = uint.Parse(array[2]);
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat("[上交物品任务]，任务<{0}>,{1} 参数转换错误", new object[]
					{
						num,
						tableItem.TaskName,
						ex.ToString()
					});
				}
			}
			else
			{
				Logger.LogErrorFormat("[上交物品任务]，任务<{0}> ID错误，查不到数据", new object[]
				{
					num
				});
			}
			this.itemList = this.GetItemToShow(num);
			if (this.submitEquip != null)
			{
				SubmitItemDlg.<_OnOpenFrame>c__AnonStorey2 <_OnOpenFrame>c__AnonStorey = new SubmitItemDlg.<_OnOpenFrame>c__AnonStorey2();
				<_OnOpenFrame>c__AnonStorey.$this = this;
				<_OnOpenFrame>c__AnonStorey.itemDataFirst = null;
				this.submitEquip.Initialize();
				this.submitEquip.onBindItem = ((GameObject go) => go);
				this.submitEquip.onItemVisiable = delegate(ComUIListElementScript go)
				{
					int index = go.m_index;
					ComCommonBind component = go.GetComponent<ComCommonBind>();
					if (component == null)
					{
						return;
					}
					<_OnOpenFrame>c__AnonStorey.$this.itemImage[index] = component.GetCom<Image>("Item");
					<_OnOpenFrame>c__AnonStorey.$this.itemSelectImage[index] = component.GetCom<Image>("Image");
					<_OnOpenFrame>c__AnonStorey.$this.itemNum[index] = component.GetCom<Text>("Num");
					if (<_OnOpenFrame>c__AnonStorey.$this.itemImage[index] == null || <_OnOpenFrame>c__AnonStorey.$this.itemSelectImage[index] == null || <_OnOpenFrame>c__AnonStorey.$this.itemNum[index] == null)
					{
						return;
					}
					if (<_OnOpenFrame>c__AnonStorey.$this.itemList.Count > 0)
					{
						if (index < <_OnOpenFrame>c__AnonStorey.$this.itemList.Count)
						{
							ulong id = <_OnOpenFrame>c__AnonStorey.$this.itemList[index];
							ComItem comItem = <_OnOpenFrame>c__AnonStorey.$this.itemImage[index].GetComponentInChildren<ComItem>();
							if (comItem == null)
							{
								comItem = <_OnOpenFrame>c__AnonStorey.$this.CreateComItem(<_OnOpenFrame>c__AnonStorey.$this.itemImage[index].gameObject);
							}
							comItem.gameObject.transform.SetAsFirstSibling();
							ItemData itemData = null;
							if (<_OnOpenFrame>c__AnonStorey.$this.param1 == 0U)
							{
								<_OnOpenFrame>c__AnonStorey.$this.itemNum[index].text = "1/1";
								ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(id);
								if (item2 != null)
								{
									itemData = ItemDataManager.CreateItemDataFromTable(item2.TableID, 100, 0);
									itemData.StrengthenLevel = item2.StrengthenLevel;
									itemData.Count = 1;
								}
							}
							else if (<_OnOpenFrame>c__AnonStorey.$this.param1 == 1U)
							{
								int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)<_OnOpenFrame>c__AnonStorey.$this.param2, true);
								itemData = ItemDataManager.CreateItemDataFromTable((int)<_OnOpenFrame>c__AnonStorey.$this.param2, 100, 0);
								itemData.Count = 1;
								<_OnOpenFrame>c__AnonStorey.$this.itemNum[index].text = string.Format("{0}/{1}", ownedItemCount, <_OnOpenFrame>c__AnonStorey.$this.param3);
							}
							int localIndex = index;
							comItem.Setup(itemData, delegate(GameObject obj, ItemData item)
							{
								<_OnOpenFrame>c__AnonStorey.OnItemClicked(go.gameObject, item, localIndex);
							});
							<_OnOpenFrame>c__AnonStorey.$this.itemSelectImage[index].enabled = (<_OnOpenFrame>c__AnonStorey.$this.itemSelectIndex == index);
							if (index == 0)
							{
								<_OnOpenFrame>c__AnonStorey.itemDataFirst = itemData;
							}
						}
					}
					else if (go.m_index == 0)
					{
						ComItem comItem2 = <_OnOpenFrame>c__AnonStorey.$this.itemImage[0].GetComponentInChildren<ComItem>();
						if (comItem2 == null)
						{
							comItem2 = <_OnOpenFrame>c__AnonStorey.$this.CreateComItem(<_OnOpenFrame>c__AnonStorey.$this.itemImage[0].gameObject);
						}
						comItem2.gameObject.transform.SetAsFirstSibling();
						if (<_OnOpenFrame>c__AnonStorey.$this.param1 != 0U)
						{
							if (<_OnOpenFrame>c__AnonStorey.$this.param1 == 1U)
							{
								ItemData itemData2 = ItemDataManager.CreateItemDataFromTable((int)<_OnOpenFrame>c__AnonStorey.$this.param2, 100, 0);
								itemData2.Count = 1;
								<_OnOpenFrame>c__AnonStorey.$this.itemNum[0].text = string.Format("0/{0}", <_OnOpenFrame>c__AnonStorey.$this.param3);
								comItem2.Setup(itemData2, null);
							}
						}
					}
				};
				int num2 = (this.itemList.Count <= 3) ? 3 : this.itemList.Count;
				this.itemImage = new Image[num2];
				this.itemNum = new Text[num2];
				this.itemSelectImage = new Image[num2];
				this.submitEquip.SetElementAmount(num2);
				this.OnItemClicked(null, <_OnOpenFrame>c__AnonStorey.itemDataFirst, 0);
			}
		}

		// Token: 0x060118BE RID: 71870 RVA: 0x0051B1F8 File Offset: 0x005195F8
		private void OnItemClicked(GameObject obj, ItemData item, int index)
		{
			int selectItem = index;
			if (obj != null)
			{
				ComUIListElementScript component = obj.GetComponent<ComUIListElementScript>();
				if (component != null)
				{
					selectItem = component.m_index;
				}
			}
			this.SetSelectItem(selectItem);
			this.textShow.text = this.GetTextShow(item);
		}

		// Token: 0x060118BF RID: 71871 RVA: 0x0051B248 File Offset: 0x00519648
		private string GetTextShow(ItemData item)
		{
			if (item == null)
			{
				return string.Empty;
			}
			ItemData.QualityInfo qualityInfo = item.GetQualityInfo();
			string arg = string.Format("<color={0}>{1}</color>", qualityInfo.ColStr, item.Name);
			return string.Format("当前选择：{0}", arg);
		}

		// Token: 0x060118C0 RID: 71872 RVA: 0x0051B28A File Offset: 0x0051968A
		private void Reset()
		{
			this.itemList = new List<ulong>();
			this.itemSelectIndex = 0;
		}

		// Token: 0x060118C1 RID: 71873 RVA: 0x0051B29E File Offset: 0x0051969E
		protected override void _OnCloseFrame()
		{
			this.Reset();
		}

		// Token: 0x060118C2 RID: 71874 RVA: 0x0051B2A6 File Offset: 0x005196A6
		protected override void _bindExUI()
		{
			this.submitEquip = this.mBind.GetCom<ComUIListScript>("submitEquip");
		}

		// Token: 0x060118C3 RID: 71875 RVA: 0x0051B2BE File Offset: 0x005196BE
		protected override void _unbindExUI()
		{
			this.submitEquip = null;
		}

		// Token: 0x060118C4 RID: 71876 RVA: 0x0051B2C7 File Offset: 0x005196C7
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mission/SubmitItem";
		}

		// Token: 0x060118C5 RID: 71877 RVA: 0x0051B2D0 File Offset: 0x005196D0
		[UIEventHandle("Submit")]
		private void OnClickOK()
		{
			ulong selectItem = this.GetSelectItem();
			if (selectItem > 0UL)
			{
				if (this.param1 == 1U)
				{
					int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)this.param2, true);
					if ((long)ownedItemCount < (long)((ulong)this.param3))
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Task_Submit_Tip_Content"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
				}
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(selectItem);
				if (item != null && item.StrengthenLevel > 0)
				{
					ItemData.QualityInfo qualityInfo = item.GetQualityInfo();
					string text = string.Format("<color={0}>{1}</color>", qualityInfo.ColStr, item.Name);
					string msgContent = string.Format(TR.Value("mission_submit_strengthLevel"), string.Concat(new object[]
					{
						"+",
						item.StrengthenLevel,
						" ",
						text
					}));
					SystemNotifyManager.SysNotifyMsgBoxCancelOk(msgContent, null, delegate()
					{
						this._Submit();
					}, 0f, false, null);
				}
				else
				{
					this._Submit();
				}
			}
		}

		// Token: 0x060118C6 RID: 71878 RVA: 0x0051B3CC File Offset: 0x005197CC
		private void _Submit()
		{
			ulong selectItem = this.GetSelectItem();
			SceneSetTaskItemReq sceneSetTaskItemReq = new SceneSetTaskItemReq();
			sceneSetTaskItemReq.taskId = (uint)((int)this.userData);
			sceneSetTaskItemReq.itemIds = new ulong[]
			{
				selectItem
			};
			NetManager.Instance().SendCommand<SceneSetTaskItemReq>(ServerType.GATE_SERVER, sceneSetTaskItemReq);
			this.frameMgr.CloseFrame<SubmitItemDlg>(this, false);
		}

		// Token: 0x060118C7 RID: 71879 RVA: 0x0051B421 File Offset: 0x00519821
		[UIEventHandle("Cancle")]
		private void OnCancle()
		{
			this.frameMgr.CloseFrame<SubmitItemDlg>(this, false);
		}

		// Token: 0x060118C8 RID: 71880 RVA: 0x0051B430 File Offset: 0x00519830
		private ulong GetSelectItem()
		{
			if (this.itemList.Count <= 0)
			{
				return 0UL;
			}
			if (this.itemSelectIndex < 0 || this.itemSelectIndex >= this.itemList.Count)
			{
				return 0UL;
			}
			return this.itemList[this.itemSelectIndex];
		}

		// Token: 0x060118C9 RID: 71881 RVA: 0x0051B488 File Offset: 0x00519888
		private void SetSelectItem(int index)
		{
			if (index < 0 || index >= this.itemList.Count)
			{
				return;
			}
			for (int i = 0; i < this.itemSelectImage.Length; i++)
			{
				if (this.itemSelectImage[i] != null)
				{
					this.itemSelectImage[i].enabled = false;
				}
			}
			if (this.itemSelectImage[index] != null)
			{
				this.itemSelectImage[index].enabled = true;
			}
			this.itemSelectIndex = index;
		}

		// Token: 0x0400B687 RID: 46727
		protected uint param1;

		// Token: 0x0400B688 RID: 46728
		protected uint param2;

		// Token: 0x0400B689 RID: 46729
		protected uint param3;

		// Token: 0x0400B68A RID: 46730
		protected List<ulong> itemList = new List<ulong>();

		// Token: 0x0400B68B RID: 46731
		protected int itemSelectIndex;

		// Token: 0x0400B68C RID: 46732
		protected ItemData materialItem;

		// Token: 0x0400B68D RID: 46733
		private ComUIListScript submitEquip;

		// Token: 0x0400B68E RID: 46734
		protected Image[] itemImage = new Image[0];

		// Token: 0x0400B68F RID: 46735
		protected Image[] itemSelectImage = new Image[0];

		// Token: 0x0400B690 RID: 46736
		protected Text[] itemNum = new Text[0];

		// Token: 0x0400B691 RID: 46737
		[UIObject("ItemGroupBg/Text")]
		protected GameObject textShowNoItem;

		// Token: 0x0400B692 RID: 46738
		[UIControl("ItemGroupBg/Text", null, 0)]
		protected Text textShow;
	}
}
