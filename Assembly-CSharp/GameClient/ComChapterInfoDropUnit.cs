using System;
using System.Collections.Generic;
using ActivityLimitTime;
using GamePool;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E87 RID: 3719
	public class ComChapterInfoDropUnit : MonoBehaviour
	{
		// Token: 0x0600932B RID: 37675 RVA: 0x001B6520 File Offset: 0x001B4920
		public void Load(int id)
		{
			this.mID = id;
			this.mType = this._getType(id);
			this._createItemCollection(id);
			this._bind();
		}

		// Token: 0x0600932C RID: 37676 RVA: 0x001B6544 File Offset: 0x001B4944
		public void ShowName(bool show)
		{
			if (null != this.mBind)
			{
				Text com = this.mBind.GetCom<Text>("name");
				com.enabled = show;
			}
		}

		// Token: 0x0600932D RID: 37677 RVA: 0x001B657C File Offset: 0x001B497C
		public void ShowLevel(bool show)
		{
			if (null != this.mBind)
			{
				Text com = this.mBind.GetCom<Text>("level");
				if (!string.IsNullOrEmpty(com.text))
				{
					com.enabled = show;
				}
			}
		}

		// Token: 0x0600932E RID: 37678 RVA: 0x001B65C4 File Offset: 0x001B49C4
		public void ShowFatigueCombustionBuffRoot(int mDungeonID = 0)
		{
			string text = string.Empty;
			try
			{
				if (null != this.mBind)
				{
					GameObject gameObject = this.mBind.GetGameObject("FatigueCombustionBuff");
					if (gameObject == null)
					{
						text = "[go is empty]";
					}
					if (Singleton<TableManager>.GetInstance() == null)
					{
						text += "[table is null]";
					}
					bool flag = false;
					ActivityLimitTimeData activityLimitTimeData = null;
					if (DataManager<ActivityLimitTimeCombineManager>.GetInstance() == null)
					{
						text += "[ActivityLimitTimeCombineManager is null]";
					}
					if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
					{
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.FindFatigueCombustionActivityIsOpen(ref flag, ref activityLimitTimeData);
					}
					bool flag2 = false;
					DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(mDungeonID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						flag2 = (tableItem.SubType == DungeonTable.eSubType.S_NORMAL || tableItem.SubType == DungeonTable.eSubType.S_WUDAOHUI);
					}
					if (activityLimitTimeData != null)
					{
						bool flag3 = false;
						ActivityLimitTimeDetailData activityLimitTimeDetailData = null;
						for (int i = 0; i < activityLimitTimeData.activityDetailDataList.Count; i++)
						{
							if (activityLimitTimeData.activityDetailDataList[i].ActivityDetailState == ActivityTaskState.Finished)
							{
								flag3 = true;
								activityLimitTimeDetailData = activityLimitTimeData.activityDetailDataList[i];
							}
						}
						if (activityLimitTimeDetailData != null)
						{
							if (TeamUtility.IsEliteDungeonID(mDungeonID))
							{
								flag3 = false;
							}
							bool bActive = flag && flag2 && flag3;
							string text2 = activityLimitTimeDetailData.DataId.ToString();
							string s = text2.Substring(text2.Length - 1);
							int num = 0;
							if (int.TryParse(s, out num))
							{
								if (num == 1)
								{
									if (this.mType == ComChapterInfoDropUnit.eType.Item)
									{
										ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.mID, string.Empty, string.Empty);
										if (tableItem2 != null)
										{
											if (tableItem2.SubType == ItemTable.eSubType.EXP)
											{
												gameObject.CustomActive(bActive);
											}
										}
									}
								}
								else if (this.mType == ComChapterInfoDropUnit.eType.Item)
								{
									ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.mID, string.Empty, string.Empty);
									if (tableItem3 != null)
									{
										if (tableItem3.SubType == ItemTable.eSubType.EXP || tableItem3.Color == ItemTable.eColor.PINK)
										{
											gameObject.CustomActive(bActive);
										}
									}
								}
								else
								{
									ItemCollectionTable tableItem4 = Singleton<TableManager>.instance.GetTableItem<ItemCollectionTable>(this.mID, string.Empty, string.Empty);
									if (tableItem4 != null)
									{
										for (int j = 0; j < tableItem4.Color.Count; j++)
										{
											if (tableItem4.Color[j] == 5)
											{
												gameObject.CustomActive(bActive);
											}
										}
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("ShowFatigueCombustionBuffRoot:{0} reason {1}", new object[]
				{
					ex.Message,
					text
				});
			}
		}

		// Token: 0x0600932F RID: 37679 RVA: 0x001B68C8 File Offset: 0x001B4CC8
		public void CloseFatigueCombustionBuffRoot()
		{
			GameObject gameObject = this.mBind.GetGameObject("FatigueCombustionBuff");
			if (null != gameObject)
			{
				gameObject.CustomActive(false);
			}
		}

		// Token: 0x06009330 RID: 37680 RVA: 0x001B68FC File Offset: 0x001B4CFC
		public void SetSize(Vector2 size)
		{
			if (null != this.mBind)
			{
				LayoutElement com = this.mBind.GetCom<LayoutElement>("layout");
				if (size.x > 0f)
				{
					com.preferredWidth = size.x;
				}
				if (size.y > 0f)
				{
					com.preferredHeight = size.y;
				}
			}
		}

		// Token: 0x06009331 RID: 37681 RVA: 0x001B6967 File Offset: 0x001B4D67
		public void Unload()
		{
			this._unbind();
		}

		// Token: 0x06009332 RID: 37682 RVA: 0x001B6970 File Offset: 0x001B4D70
		private ComChapterInfoDropUnit.eType _getType(int id)
		{
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return ComChapterInfoDropUnit.eType.Item;
			}
			ItemCollectionTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ItemCollectionTable>(id, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				return ComChapterInfoDropUnit.eType.ItemCollection;
			}
			Logger.LogErrorFormat("无法找到 id 为 {0} 的道具和集合", new object[]
			{
				id
			});
			return ComChapterInfoDropUnit.eType.None;
		}

		// Token: 0x06009333 RID: 37683 RVA: 0x001B69D4 File Offset: 0x001B4DD4
		private void _showItemTips(int id)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x06009334 RID: 37684 RVA: 0x001B6A04 File Offset: 0x001B4E04
		private void _onClick()
		{
			ComChapterInfoDropUnit.eType eType = this.mType;
			if (eType != ComChapterInfoDropUnit.eType.Item)
			{
				if (eType == ComChapterInfoDropUnit.eType.ItemCollection)
				{
					ItemCollectionTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemCollectionTable>(this.mID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.TipsType == ItemCollectionTable.eTipsType.COLLECTION)
						{
							List<int[]> list = ListPool<int[]>.Get();
							for (int i = 0; i < tableItem.TipsContent.Count; i++)
							{
								if (tableItem.TipsContent[i].valueType == UnionCellType.union_everyvalue && tableItem.TipsContent[i].eValues.everyValues != null)
								{
									FlatBufferArray<int> everyValues = tableItem.TipsContent[i].eValues.everyValues;
									int[] array = new int[everyValues.Count];
									for (int j = 0; j < everyValues.Count; j++)
									{
										array[j] = everyValues[i];
									}
									list.Add(array);
								}
							}
							if (list.Count > 0)
							{
								ChapterInfoDropTipsFrame.ShowTips(list);
							}
							ListPool<int[]>.Release(list);
						}
						else if (tableItem.TipsType == ItemCollectionTable.eTipsType.SINGLE)
						{
							ChapterTempTipsFrame.Show(this.mID);
						}
					}
				}
			}
			else
			{
				this._showItemTips(this.mID);
			}
		}

		// Token: 0x06009335 RID: 37685 RVA: 0x001B6B50 File Offset: 0x001B4F50
		private void _bind()
		{
			if (null != this.mBind)
			{
				Button com = this.mBind.GetCom<Button>("button");
				if (null != com)
				{
					com.onClick.AddListener(new UnityAction(this._onClick));
				}
			}
		}

		// Token: 0x06009336 RID: 37686 RVA: 0x001B6BA4 File Offset: 0x001B4FA4
		private void _unbind()
		{
			if (null != this.mBind)
			{
				Button com = this.mBind.GetCom<Button>("button");
				if (null != com)
				{
					com.onClick.RemoveListener(new UnityAction(this._onClick));
				}
			}
		}

		// Token: 0x06009337 RID: 37687 RVA: 0x001B6BF6 File Offset: 0x001B4FF6
		private string _getColorString(string color, string name)
		{
			return string.Format("<color={0}>{1}</color>", color, name);
		}

		// Token: 0x06009338 RID: 37688 RVA: 0x001B6C04 File Offset: 0x001B5004
		private void _createItemCollection(int id)
		{
			string text = string.Empty;
			string slvl = string.Empty;
			string sicon = string.Empty;
			string sname = string.Empty;
			ItemTable.eColor bgColor = ItemTable.eColor.WHITE;
			int num = 0;
			ItemData itemData = null;
			ComChapterInfoDropUnit.eType eType = this.mType;
			if (eType != ComChapterInfoDropUnit.eType.Item)
			{
				if (eType == ComChapterInfoDropUnit.eType.ItemCollection)
				{
					ItemCollectionTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemCollectionTable>(id, string.Empty, string.Empty);
					if (tableItem != null)
					{
						List<int> list = new List<int>(tableItem.Color);
						list.Sort();
						slvl = tableItem.Level;
						sicon = tableItem.Icon;
						ItemData.QualityInfo qualityInfo = null;
						ItemData.QualityInfo qualityInfo2 = null;
						if (list.Count > 0)
						{
							try
							{
								qualityInfo = ItemData.GetQualityInfo((ItemTable.eColor)list[list.Count - 1], false, false);
								qualityInfo2 = ItemData.GetQualityInfo((ItemTable.eColor)list[0], false, false);
								bgColor = (ItemTable.eColor)list[list.Count - 1];
								num = tableItem.Color2;
								if (num == 3)
								{
									if (qualityInfo2.Quality == ItemTable.eColor.PINK)
									{
										qualityInfo2 = ItemData.GetQualityInfo((ItemTable.eColor)list[0], num);
									}
									if (qualityInfo.Quality == ItemTable.eColor.PINK)
									{
										qualityInfo = ItemData.GetQualityInfo((ItemTable.eColor)list[list.Count - 1], num);
									}
								}
							}
							catch
							{
								qualityInfo = ItemData.GetQualityInfo(ItemTable.eColor.WHITE, false, false);
								qualityInfo2 = ItemData.GetQualityInfo(ItemTable.eColor.WHITE, false, false);
								bgColor = ItemTable.eColor.WHITE;
								num = 0;
							}
							text = qualityInfo.Background;
							if (qualityInfo == qualityInfo2 || qualityInfo.Quality == qualityInfo2.Quality)
							{
								sname = string.Format("{0}", this._getColorString(qualityInfo.ColStr, qualityInfo.Desc));
							}
							else
							{
								sname = string.Format("{0}-{1}", this._getColorString(qualityInfo2.ColStr, qualityInfo2.Desc), this._getColorString(qualityInfo.ColStr, qualityInfo.Desc));
							}
						}
					}
				}
			}
			else
			{
				ItemTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ItemTable>(id, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					ItemData.QualityInfo qualityInfo3 = ItemData.GetQualityInfo(tableItem2.Color, tableItem2.Color2);
					sname = this._getColorString(qualityInfo3.ColStr, tableItem2.Name);
					slvl = string.Format("{0}级{1}", tableItem2.NeedLevel, tableItem2.SubTypeName);
					sicon = tableItem2.Icon;
					text = qualityInfo3.Background;
					bgColor = tableItem2.Color;
					num = tableItem2.Color2;
					slvl = string.Empty;
					itemData = ItemDataManager.CreateItemDataFromTable(tableItem2.ID, 100, 0);
				}
			}
			this._createItemByQuality(bgColor, sicon, sname, slvl, num, itemData);
		}

		// Token: 0x06009339 RID: 37689 RVA: 0x001B6EA4 File Offset: 0x001B52A4
		private void _createItemByQuality(ItemTable.eColor bgColor, string sicon, string sname, string slvl, int color2 = 0, ItemData itemData = null)
		{
			if (null != this.mBind)
			{
				Image com = this.mBind.GetCom<Image>("bg");
				Image com2 = this.mBind.GetCom<Image>("icon");
				Text com3 = this.mBind.GetCom<Text>("name");
				Text com4 = this.mBind.GetCom<Text>("level");
				GameObject gameObject = this.mBind.GetGameObject("TimeLimit");
				this._getBgSprite(bgColor, ref com, color2);
				ETCImageLoader.LoadSprite(ref com2, sicon, true);
				com3.text = sname.Trim();
				com4.text = slvl.Trim();
				if (string.IsNullOrEmpty(com4.text))
				{
					com4.enabled = false;
				}
				if (itemData != null && gameObject != null)
				{
					int num;
					bool flag;
					itemData.GetTimeLeft(out num, out flag);
					if ((flag && num > 0) || itemData.IsTimeLimit)
					{
						gameObject.CustomActive(true);
					}
					else
					{
						gameObject.CustomActive(false);
					}
				}
			}
		}

		// Token: 0x0600933A RID: 37690 RVA: 0x001B6FAC File Offset: 0x001B53AC
		private void _getBgSprite(ItemTable.eColor color, ref Image image, int color2 = 0)
		{
			if (null == this.mBind)
			{
				return;
			}
			switch (color)
			{
			case ItemTable.eColor.CL_NONE:
			case ItemTable.eColor.WHITE:
				this.mBind.GetSprite("white", ref image);
				return;
			case ItemTable.eColor.BLUE:
				this.mBind.GetSprite("blue", ref image);
				return;
			case ItemTable.eColor.PURPLE:
				this.mBind.GetSprite("purple", ref image);
				return;
			case ItemTable.eColor.GREEN:
				this.mBind.GetSprite("green", ref image);
				return;
			case ItemTable.eColor.PINK:
				if (color2 == 3)
				{
					ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(ItemTable.eColor.PINK, color2);
					if (qualityInfo != null)
					{
						ETCImageLoader.LoadSprite(ref image, qualityInfo.Background, true);
						return;
					}
				}
				this.mBind.GetSprite("pink", ref image);
				return;
			case ItemTable.eColor.YELLOW:
				this.mBind.GetSprite("yellow", ref image);
				return;
			default:
				this.mBind.GetSprite("white", ref image);
				return;
			}
		}

		// Token: 0x04004A46 RID: 19014
		public ComCommonBind mBind;

		// Token: 0x04004A47 RID: 19015
		private ComChapterInfoDropUnit.eType mType;

		// Token: 0x04004A48 RID: 19016
		private int mID = -1;

		// Token: 0x02000E88 RID: 3720
		private enum eType
		{
			// Token: 0x04004A4A RID: 19018
			None,
			// Token: 0x04004A4B RID: 19019
			Item,
			// Token: 0x04004A4C RID: 19020
			ItemCollection
		}
	}
}
