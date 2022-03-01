using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001251 RID: 4689
	public class EquipUpgradeDataManager : DataManager<EquipUpgradeDataManager>
	{
		// Token: 0x0600B424 RID: 46116 RVA: 0x00284982 File Offset: 0x00282D82
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600B425 RID: 46117 RVA: 0x00284986 File Offset: 0x00282D86
		public sealed override void Clear()
		{
			this.mEquipUpgradeDataDic.Clear();
			this._UnRegisterNetHandler();
			this.UnbindEvent();
		}

		// Token: 0x0600B426 RID: 46118 RVA: 0x0028499F File Offset: 0x00282D9F
		public sealed override void Initialize()
		{
			this._RegisterNetHandler();
			this.BindEvent();
		}

		// Token: 0x0600B427 RID: 46119 RVA: 0x002849AD File Offset: 0x00282DAD
		private void BindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this.OnJobIDChanged));
		}

		// Token: 0x0600B428 RID: 46120 RVA: 0x002849C7 File Offset: 0x00282DC7
		private void UnbindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this.OnJobIDChanged));
		}

		// Token: 0x0600B429 RID: 46121 RVA: 0x002849E1 File Offset: 0x00282DE1
		private void OnJobIDChanged(UIEvent uiEvent)
		{
			this.InitEquipUpgradeTable();
		}

		// Token: 0x0600B42A RID: 46122 RVA: 0x002849E9 File Offset: 0x00282DE9
		private void _RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(501049U, new Action<MsgDATA>(this.OnSyncSceneEquieUpdateRes));
		}

		// Token: 0x0600B42B RID: 46123 RVA: 0x00284A01 File Offset: 0x00282E01
		private void _UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(501049U, new Action<MsgDATA>(this.OnSyncSceneEquieUpdateRes));
		}

		// Token: 0x0600B42C RID: 46124 RVA: 0x00284A1C File Offset: 0x00282E1C
		private void OnSyncSceneEquieUpdateRes(MsgDATA msg)
		{
			SceneEquieUpdateRes sceneEquieUpdateRes = new SceneEquieUpdateRes();
			sceneEquieUpdateRes.decode(msg.bytes);
			if (sceneEquieUpdateRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneEquieUpdateRes.code, string.Empty);
			}
			else
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(sceneEquieUpdateRes.equipUid);
				if (item == null)
				{
					Logger.LogErrorFormat("装备升级返回装备GUID有误", new object[0]);
				}
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<EquipUpgradeResultFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<EquipUpgradeResultFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipUpgradeResultFrame>(FrameLayer.Middle, item, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnEquipUpgradeSuccess, null, null, null, null);
			}
		}

		// Token: 0x0600B42D RID: 46125 RVA: 0x00284AC4 File Offset: 0x00282EC4
		public void OnSendSceneEquieUpdateReq(ulong guid)
		{
			SceneEquieUpdateReq sceneEquieUpdateReq = new SceneEquieUpdateReq();
			sceneEquieUpdateReq.equipUid = guid;
			NetManager.Instance().SendCommand<SceneEquieUpdateReq>(ServerType.GATE_SERVER, sceneEquieUpdateReq);
		}

		// Token: 0x0600B42E RID: 46126 RVA: 0x00284AEC File Offset: 0x00282EEC
		public EquipUpgradeDataModel GetEquipUpgradeData(int equipId)
		{
			EquipUpgradeDataModel result = null;
			if (this.mEquipUpgradeDataDic.ContainsKey(equipId))
			{
				result = this.mEquipUpgradeDataDic[equipId];
			}
			return result;
		}

		// Token: 0x0600B42F RID: 46127 RVA: 0x00284B1C File Offset: 0x00282F1C
		public List<ItemSimpleData> GetMaterialConsume(int equipId, int strenthLevel, EEquipType equipType)
		{
			List<ItemSimpleData> result = new List<ItemSimpleData>();
			EquipUpgradeDataModel equipUpgradeData = this.GetEquipUpgradeData(equipId);
			if (equipUpgradeData != null)
			{
				if (equipType == EEquipType.ET_COMMON)
				{
					for (int i = 0; i < equipUpgradeData.mMaterialConsumeData.Count; i++)
					{
						if (strenthLevel >= equipUpgradeData.mMaterialConsumeData[i].mMinStrenthLevel && strenthLevel <= equipUpgradeData.mMaterialConsumeData[i].mMaxStrenthLevel)
						{
							return equipUpgradeData.mMaterialConsumeData[i].mItemSimpleDatas;
						}
					}
				}
				else if (equipType == EEquipType.ET_REDMARK)
				{
					for (int j = 0; j < equipUpgradeData.mGrowthEquipMaterialConsumeData.Count; j++)
					{
						if (strenthLevel >= equipUpgradeData.mGrowthEquipMaterialConsumeData[j].mMinStrenthLevel && strenthLevel <= equipUpgradeData.mGrowthEquipMaterialConsumeData[j].mMaxStrenthLevel)
						{
							return equipUpgradeData.mGrowthEquipMaterialConsumeData[j].mItemSimpleDatas;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600B430 RID: 46128 RVA: 0x00284C08 File Offset: 0x00283008
		public void InitEquipUpgradeTable()
		{
			this.mEquipUpgradeDataDic.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<EquieUpdateTable>())
			{
				EquieUpdateTable equieUpdateTable = keyValuePair.Value as EquieUpdateTable;
				if (equieUpdateTable != null)
				{
					if (equieUpdateTable.JobID == DataManager<PlayerBaseData>.GetInstance().JobTableID || equieUpdateTable.JobID == 0)
					{
						if (!this.mEquipUpgradeDataDic.ContainsKey(equieUpdateTable.EquieID))
						{
							EquipUpgradeDataModel equipUpgradeDataModel = new EquipUpgradeDataModel();
							equipUpgradeDataModel.mUpgradeEquipID = equieUpdateTable.NextLvEquieID;
							equipUpgradeDataModel.mMaterialConsumeData = new List<MaterialConsumeData>();
							equipUpgradeDataModel.mGrowthEquipMaterialConsumeData = new List<MaterialConsumeData>();
							equipUpgradeDataModel.mMaterialConsumeData.AddRange(this.AddMaterialConsumeData(equieUpdateTable.MaterialConsume));
							equipUpgradeDataModel.mGrowthEquipMaterialConsumeData.AddRange(this.AddMaterialConsumeData(equieUpdateTable.IncreaseMaterialConsume));
							this.mEquipUpgradeDataDic.Add(equieUpdateTable.EquieID, equipUpgradeDataModel);
						}
					}
				}
			}
		}

		// Token: 0x0600B431 RID: 46129 RVA: 0x00284D04 File Offset: 0x00283104
		private List<MaterialConsumeData> AddMaterialConsumeData(string materialConsume)
		{
			List<MaterialConsumeData> list = new List<MaterialConsumeData>();
			string[] array = materialConsume.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				MaterialConsumeData materialConsumeData = new MaterialConsumeData();
				string[] array2 = array[i].Split(new char[]
				{
					','
				});
				materialConsumeData.mItemSimpleDatas = new List<ItemSimpleData>();
				for (int j = 0; j < array2.Length; j++)
				{
					int mMinStrenthLevel = 0;
					int mMaxStrenthLevel = 0;
					int itemID = 0;
					int count = 0;
					if (j == 0)
					{
						int.TryParse(array2[j], out mMinStrenthLevel);
						materialConsumeData.mMinStrenthLevel = mMinStrenthLevel;
					}
					else if (j == 1)
					{
						int.TryParse(array2[j], out mMaxStrenthLevel);
						materialConsumeData.mMaxStrenthLevel = mMaxStrenthLevel;
					}
					else
					{
						string[] array3 = array2[j].Split(new char[]
						{
							'_'
						});
						if (array3.Length >= 2)
						{
							int.TryParse(array3[0], out itemID);
							int.TryParse(array3[1], out count);
							ItemSimpleData itemSimpleData = new ItemSimpleData();
							itemSimpleData.ItemID = itemID;
							itemSimpleData.Count = count;
							materialConsumeData.mItemSimpleDatas.Add(itemSimpleData);
						}
					}
				}
				list.Add(materialConsumeData);
			}
			return list;
		}

		// Token: 0x0600B432 RID: 46130 RVA: 0x00284E34 File Offset: 0x00283234
		public bool FindEquipUpgradeTableID(int tableID)
		{
			bool result = false;
			if (this.mEquipUpgradeDataDic.ContainsKey(tableID))
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600B433 RID: 46131 RVA: 0x00284E58 File Offset: 0x00283258
		public List<ulong> GetAllEquipments()
		{
			List<ulong> list = new List<ulong>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			this.OnAddElement(itemsByPackageType, ref list);
			this.OnAddElement(itemsByPackageType2, ref list);
			list.RemoveAll(delegate(ulong x)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(x);
				return item == null || !this.FindEquipUpgradeTableID(item.TableID) || item.EquipType == EEquipType.ET_BREATH || item.HasTransfered;
			});
			list.Sort(new Comparison<ulong>(this.SortEquipments));
			return list;
		}

		// Token: 0x0600B434 RID: 46132 RVA: 0x00284EBC File Offset: 0x002832BC
		private int SortEquipments(ulong x, ulong y)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(x);
			ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(y);
			if (item.PackageType != item2.PackageType)
			{
				return item2.PackageType - item.PackageType;
			}
			if (item.IsItemInUnUsedEquipPlan != item2.IsItemInUnUsedEquipPlan)
			{
				if (item.IsItemInUnUsedEquipPlan)
				{
					return -1;
				}
				if (item2.IsItemInUnUsedEquipPlan)
				{
					return 1;
				}
			}
			if (item.Quality != item2.Quality)
			{
				return item2.Quality - item.Quality;
			}
			if (item.SubType != item2.SubType)
			{
				return item.SubType - item2.SubType;
			}
			if (item.StrengthenLevel != item2.StrengthenLevel)
			{
				return item2.StrengthenLevel - item.StrengthenLevel;
			}
			return item2.LevelLimit - item.LevelLimit;
		}

		// Token: 0x0600B435 RID: 46133 RVA: 0x00284F98 File Offset: 0x00283398
		private void OnAddElement(List<ulong> items, ref List<ulong> allitems)
		{
			for (int i = 0; i < items.Count; i++)
			{
				allitems.Add(items[i]);
			}
		}

		// Token: 0x0400658D RID: 25997
		private Dictionary<int, EquipUpgradeDataModel> mEquipUpgradeDataDic = new Dictionary<int, EquipUpgradeDataModel>();
	}
}
