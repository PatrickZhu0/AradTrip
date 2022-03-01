using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BEC RID: 7148
	internal class TAPDonateFrame : ClientFrame
	{
		// Token: 0x0601184E RID: 71758 RVA: 0x00518B4C File Offset: 0x00516F4C
		public static void Open(RelationData relation)
		{
			if (relation == null)
			{
				return;
			}
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPDonateFrame>(null))
			{
				TAPItemSelectFrameData tapitemSelectFrameData = new TAPItemSelectFrameData();
				tapitemSelectFrameData.relation = relation;
				tapitemSelectFrameData.datas.Clear();
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
				if (itemsByPackageType != null)
				{
					for (int i = 0; i < itemsByPackageType.Count; i++)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
						if (item != null)
						{
							ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
							if (tableItem != null)
							{
								if (tableItem.CanMasterGive != 0)
								{
									if (item.Quality > ItemTable.eColor.CL_NONE && item.Quality <= ItemTable.eColor.PURPLE)
									{
										if ((int)relation.level >= item.LevelLimit)
										{
											bool flag = relation.occu % 10 != 0;
											bool flag2 = false;
											for (int j = 0; j < tableItem.Occu.Count; j++)
											{
												if (tableItem.Occu[j] < 0)
												{
													if (flag)
													{
														flag2 = true;
														break;
													}
												}
												else
												{
													if (tableItem.Occu[j] == 0)
													{
														flag2 = true;
														break;
													}
													if (tableItem.Occu[j] == (int)relation.occu || tableItem.Occu[j] == (int)(relation.occu / 10 * 10))
													{
														flag2 = true;
														break;
													}
												}
											}
											if (flag2)
											{
												if (item.BindAttr == ItemTable.eOwner.NOTBIND || item.Packing)
												{
													tapitemSelectFrameData.datas.Add(item);
												}
											}
										}
									}
								}
							}
						}
					}
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPDonateFrame>(FrameLayer.Middle, tapitemSelectFrameData, string.Empty);
			}
		}

		// Token: 0x0601184F RID: 71759 RVA: 0x00518D33 File Offset: 0x00517133
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAPSystem/TAPDonateframe";
		}

		// Token: 0x06011850 RID: 71760 RVA: 0x00518D3C File Offset: 0x0051713C
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as TAPItemSelectFrameData);
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<TAPDonateFrame>(this, false);
			});
			base._AddButton("BtnApply", new UnityAction(this._Donate));
			if (null != this.comDonateList)
			{
				this.comDonateList.Initialize();
				this.comDonateList.onBindItem = ((GameObject go) => go.GetComponent<ComTapDonate>());
				this.comDonateList.onItemVisiable = delegate(ComUIListElementScript item)
				{
					if (null != item && item.m_index >= 0 && item.m_index < this.data.datas.Count)
					{
						ComTapDonate comTapDonate = item.gameObjectBindScript as ComTapDonate;
						if (null != comTapDonate)
						{
							comTapDonate.OnItemVisible(this.data.datas[item.m_index]);
						}
					}
				};
			}
			this._UpdateItems();
		}

		// Token: 0x06011851 RID: 71761 RVA: 0x00518DEC File Offset: 0x005171EC
		private void _UpdateItems()
		{
			if (null != this.comDonateList)
			{
				List<ItemData> datas = this.data.datas;
				datas.RemoveAll((ItemData value) => value.BEquipIsInsetBead);
				this.comDonateList.SetElementAmount(datas.Count);
				this.donateHint.CustomActive(datas.Count <= 0);
			}
		}

		// Token: 0x06011852 RID: 71762 RVA: 0x00518E62 File Offset: 0x00517262
		protected override void _OnCloseFrame()
		{
			this.data = null;
			if (null != this.comDonateList)
			{
				this.comDonateList.onBindItem = null;
				this.comDonateList.onItemVisiable = null;
				this.comDonateList = null;
			}
			ComTapDonate.Clear();
		}

		// Token: 0x06011853 RID: 71763 RVA: 0x00518EA0 File Offset: 0x005172A0
		private void _Donate()
		{
			if (ComTapDonate.SelectedItems.Count <= 0)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("donate_needs_item"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			MasterGiveEquip masterGiveEquip = new MasterGiveEquip();
			masterGiveEquip.discipleId = this.data.relation.uid;
			masterGiveEquip.itemUids = ComTapDonate.GetSelectedItems();
			NetManager.Instance().SendCommand<MasterGiveEquip>(ServerType.GATE_SERVER, masterGiveEquip);
			ComTapDonate.DelecteAllItems();
			this.frameMgr.CloseFrame<TAPDonateFrame>(this, false);
		}

		// Token: 0x0400B63F RID: 46655
		[UIControl("ScrollView", typeof(ComUIListScript), 0)]
		private ComUIListScript comDonateList;

		// Token: 0x0400B640 RID: 46656
		[UIControl("ScrollView/Hint", typeof(Text), 0)]
		private Text donateHint;

		// Token: 0x0400B641 RID: 46657
		private TAPItemSelectFrameData data;
	}
}
