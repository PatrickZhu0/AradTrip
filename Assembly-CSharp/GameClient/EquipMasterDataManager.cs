using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200123D RID: 4669
	public class EquipMasterDataManager : DataManager<EquipMasterDataManager>
	{
		// Token: 0x17001AC7 RID: 6855
		// (get) Token: 0x0600B38A RID: 45962 RVA: 0x0027F205 File Offset: 0x0027D605
		// (set) Token: 0x0600B38B RID: 45963 RVA: 0x0027F20D File Offset: 0x0027D60D
		public bool HasMasterRedPointHinted { get; set; }

		// Token: 0x0600B38C RID: 45964 RVA: 0x0027F216 File Offset: 0x0027D616
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.EquipMasterDataManager;
		}

		// Token: 0x0600B38D RID: 45965 RVA: 0x0027F21C File Offset: 0x0027D61C
		public override void Initialize()
		{
			this.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<EquipMasterTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				EquipMasterTable equipMasterTable = keyValuePair.Value as EquipMasterTable;
				if (equipMasterTable != null)
				{
					EquipMasterData equipMasterData = new EquipMasterData();
					equipMasterData.id = this._GetMasterID(equipMasterTable.JobID, equipMasterTable.Quality, equipMasterTable.Part, equipMasterTable.MaterialType);
					equipMasterData.jobID = equipMasterTable.JobID;
					equipMasterData.quality = equipMasterTable.Quality;
					equipMasterData.part = equipMasterTable.Part;
					equipMasterData.materialType = equipMasterTable.MaterialType;
					equipMasterData.masterItem = equipMasterTable;
					this._InitParams(equipMasterData, 0, equipMasterTable.Atk);
					this._InitParams(equipMasterData, 1, equipMasterTable.MagicAtk);
					this._InitParams(equipMasterData, 2, equipMasterTable.Def);
					this._InitParams(equipMasterData, 3, equipMasterTable.MagicDef);
					this._InitParams(equipMasterData, 4, equipMasterTable.Strenth);
					this._InitParams(equipMasterData, 5, equipMasterTable.Intellect);
					this._InitParams(equipMasterData, 6, equipMasterTable.Spirit);
					this._InitParams(equipMasterData, 7, equipMasterTable.Stamina);
					this._InitParams(equipMasterData, 12, equipMasterTable.HPMax);
					this._InitParams(equipMasterData, 13, equipMasterTable.MPMax);
					this._InitParams(equipMasterData, 14, equipMasterTable.HPRecover);
					this._InitParams(equipMasterData, 15, equipMasterTable.MPRecover);
					this._InitParams(equipMasterData, 16, equipMasterTable.AttackSpeedRate);
					this._InitParams(equipMasterData, 17, equipMasterTable.FireSpeedRate);
					this._InitParams(equipMasterData, 18, equipMasterTable.MoveSpeedRate);
					this._InitParams(equipMasterData, 30, equipMasterTable.HitRate);
					this._InitParams(equipMasterData, 31, equipMasterTable.AvoidRate);
					this._InitParams(equipMasterData, 32, equipMasterTable.PhysicCrit);
					this._InitParams(equipMasterData, 33, equipMasterTable.MagicCrit);
					this._InitParams(equipMasterData, 34, equipMasterTable.Spasticity);
					this.m_materDataDict.Add(equipMasterData.id, equipMasterData);
					if (!this.m_jobMasterDescDict.ContainsKey(this._GetMasterID2(equipMasterTable.JobID, equipMasterTable.MaterialType)))
					{
						EquipMasterDataManager.JobMasterDesc jobMasterDesc = new EquipMasterDataManager.JobMasterDesc();
						jobMasterDesc.jobID = equipMasterTable.JobID;
						jobMasterDesc.masterType = equipMasterTable.MaterialType;
						jobMasterDesc.isMaster = equipMasterTable.IsMaster;
						if (equipMasterTable.Descs.Count > 0)
						{
							jobMasterDesc.title = equipMasterTable.Descs[0];
						}
						if (equipMasterTable.Descs.Count > 1)
						{
							jobMasterDesc.effectDesc = equipMasterTable.Descs[1];
						}
						if (equipMasterTable.Descs.Count > 2)
						{
							jobMasterDesc.attrDesc = equipMasterTable.Descs[2];
						}
						this.m_jobMasterDescDict.Add(this._GetMasterID2(equipMasterTable.JobID, equipMasterTable.MaterialType), jobMasterDesc);
					}
				}
			}
		}

		// Token: 0x0600B38E RID: 45966 RVA: 0x0027F501 File Offset: 0x0027D901
		public override void Clear()
		{
			this.m_materDataDict.Clear();
			this.m_jobMasterDescDict.Clear();
			this.HasMasterRedPointHinted = false;
		}

		// Token: 0x0600B38F RID: 45967 RVA: 0x0027F520 File Offset: 0x0027D920
		public ItemProperty GetEquipMasterPropByIDs(int jobID, List<int> itemIDs)
		{
			EquipProp equipProp = new EquipProp();
			for (int i = 0; i < itemIDs.Count; i++)
			{
				ItemData equip = ItemDataManager.CreateItemDataFromTable(itemIDs[i], 100, 0);
				EquipProp equipMasterProp = this.GetEquipMasterProp(jobID, equip);
				if (equipMasterProp != null)
				{
					equipProp += equipMasterProp;
				}
			}
			return equipProp.ToItemProp(0, 0, EGrowthAttrType.GAT_NONE, 0);
		}

		// Token: 0x0600B390 RID: 45968 RVA: 0x0027F57C File Offset: 0x0027D97C
		public EquipProp GetEquipMasterProp(int jobID, ItemData equip)
		{
			if (equip == null)
			{
				return null;
			}
			int key = this._GetMasterID(jobID, (int)equip.Quality, equip.SubType, (int)equip.ThirdType);
			EquipMasterData equipMasterData;
			this.m_materDataDict.TryGetValue(key, out equipMasterData);
			if (equipMasterData != null)
			{
				return equipMasterData.GetEquipProp(equip.LevelLimit);
			}
			return null;
		}

		// Token: 0x0600B391 RID: 45969 RVA: 0x0027F5D0 File Offset: 0x0027D9D0
		public EquipProp GetEquipMasterProp(int jobID, int quality, int subType, int thirdType, int levelLimit)
		{
			int key = this._GetMasterID(jobID, quality, subType, thirdType);
			EquipMasterData equipMasterData;
			this.m_materDataDict.TryGetValue(key, out equipMasterData);
			if (equipMasterData != null)
			{
				return equipMasterData.GetEquipProp(levelLimit);
			}
			return null;
		}

		// Token: 0x0600B392 RID: 45970 RVA: 0x0027F608 File Offset: 0x0027DA08
		public EquipMasterDataManager.JobMasterDesc GetJobMasterDesc(int a_jobID, int material)
		{
			EquipMasterDataManager.JobMasterDesc result;
			this.m_jobMasterDescDict.TryGetValue(this._GetMasterID2(a_jobID, material), out result);
			return result;
		}

		// Token: 0x0600B393 RID: 45971 RVA: 0x0027F62C File Offset: 0x0027DA2C
		public bool IsPunish(int a_jobID, int quality, int part, int material)
		{
			int key = this._GetMasterID(a_jobID, quality, part, material);
			if (this.m_materDataDict.ContainsKey(key))
			{
				EquipMasterData equipMasterData = this.m_materDataDict[key];
				if (equipMasterData != null && equipMasterData.masterItem != null)
				{
					return equipMasterData.masterItem.IsMaster == 0;
				}
			}
			return false;
		}

		// Token: 0x0600B394 RID: 45972 RVA: 0x0027F684 File Offset: 0x0027DA84
		public int GetMasterPriority(int a_jobID, int quality, int part, int material)
		{
			if (this.IsPunish(a_jobID, quality, part, material))
			{
				return 2;
			}
			if (this.IsMaster(a_jobID, material))
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x0600B395 RID: 45973 RVA: 0x0027F6AC File Offset: 0x0027DAAC
		private void _InitParams(EquipMasterData masterData, int propID, IList<int> values)
		{
			if (values.Count > 1)
			{
				masterData.qualityParam[propID] = values[0];
				masterData.partParam[propID] = values[1];
				masterData.fixParam[propID] = 0;
			}
			else
			{
				masterData.qualityParam[propID] = 0;
				masterData.partParam[propID] = 0;
				masterData.fixParam[propID] = values[0];
			}
		}

		// Token: 0x0600B396 RID: 45974 RVA: 0x0027F768 File Offset: 0x0027DB68
		public bool IsMaster(int a_JobID, int material)
		{
			EquipMasterDataManager.JobMasterDesc jobMasterDesc;
			this.m_jobMasterDescDict.TryGetValue(this._GetMasterID2(a_JobID, material), out jobMasterDesc);
			return jobMasterDesc != null && jobMasterDesc.isMaster == 1;
		}

		// Token: 0x0600B397 RID: 45975 RVA: 0x0027F79C File Offset: 0x0027DB9C
		private int _GetMasterID(int jobID, int quality, int part, int materialType)
		{
			return jobID * 1000000 + quality * 10000 + part * 100 + materialType;
		}

		// Token: 0x0600B398 RID: 45976 RVA: 0x0027F7B5 File Offset: 0x0027DBB5
		private int _GetMasterID2(int jobID, int materialType)
		{
			return jobID * 10000 + materialType;
		}

		// Token: 0x0400653C RID: 25916
		private Dictionary<int, EquipMasterData> m_materDataDict = new Dictionary<int, EquipMasterData>();

		// Token: 0x0400653D RID: 25917
		private Dictionary<int, EquipMasterDataManager.JobMasterDesc> m_jobMasterDescDict = new Dictionary<int, EquipMasterDataManager.JobMasterDesc>();

		// Token: 0x0200123E RID: 4670
		public class JobMasterDesc
		{
			// Token: 0x0400653F RID: 25919
			public int jobID;

			// Token: 0x04006540 RID: 25920
			public int masterType;

			// Token: 0x04006541 RID: 25921
			public int isMaster;

			// Token: 0x04006542 RID: 25922
			public string title;

			// Token: 0x04006543 RID: 25923
			public string effectDesc;

			// Token: 0x04006544 RID: 25924
			public string attrDesc;
		}
	}
}
