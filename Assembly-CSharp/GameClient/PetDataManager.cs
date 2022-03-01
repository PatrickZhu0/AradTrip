using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020012BC RID: 4796
	public class PetDataManager : DataManager<PetDataManager>
	{
		// Token: 0x17001B4F RID: 6991
		// (get) Token: 0x0600B927 RID: 47399 RVA: 0x002A6CC2 File Offset: 0x002A50C2
		// (set) Token: 0x0600B926 RID: 47398 RVA: 0x002A6CB9 File Offset: 0x002A50B9
		public ulong SelectPetId
		{
			get
			{
				return this.selectPetIndex;
			}
			set
			{
				this.selectPetIndex = value;
			}
		}

		// Token: 0x0600B928 RID: 47400 RVA: 0x002A6CCA File Offset: 0x002A50CA
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600B929 RID: 47401 RVA: 0x002A6CD0 File Offset: 0x002A50D0
		public override void Initialize()
		{
			this.Clear();
			this._BindNetMsg();
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(240, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError("PetDataManager init failed : SystemValueTable data is null");
			}
			this.PetHungryLimit = tableItem.Value;
		}

		// Token: 0x0600B92A RID: 47402 RVA: 0x002A6D20 File Offset: 0x002A5120
		public override void Clear()
		{
			this._UnBindNetMsg();
			this.mIsUserClickFeedCount = false;
			this.mIsUserClickPetTab = false;
			this.mMaxGoldFeedNum = -1;
			this.PetInfoList.Clear();
			this.OnUsePetInfoList.Clear();
			this.SetPetData(this.FollowPet, new PetInfo());
			this.SetPetData(this.NewOpenPet, new PetInfo());
			this.bHasActivieFeedPet = false;
			this.fTimeIntrval = 0f;
		}

		// Token: 0x0600B92B RID: 47403 RVA: 0x002A6D92 File Offset: 0x002A5192
		public void ClearChijiPetData()
		{
			this.PetInfoList.Clear();
			this.OnUsePetInfoList.Clear();
			this.SetPetData(this.FollowPet, new PetInfo());
			this.SetPetData(this.NewOpenPet, new PetInfo());
		}

		// Token: 0x0600B92C RID: 47404 RVA: 0x002A6DCC File Offset: 0x002A51CC
		private void _BindNetMsg()
		{
			if (!this.m_bNetBind)
			{
				NetProcess.AddMsgHandler(502201U, new Action<MsgDATA>(this._OnNetSyncInitPetList));
				NetProcess.AddMsgHandler(502202U, new Action<MsgDATA>(this._OnNetSyncUpdatePetList));
				NetProcess.AddMsgHandler(502214U, new Action<MsgDATA>(this._OnNetSyncSetPetFollowRes));
				NetProcess.AddMsgHandler(502206U, new Action<MsgDATA>(this._OnNetSyncSetPetSoltRes));
				NetProcess.AddMsgHandler(502208U, new Action<MsgDATA>(this._OnNetSyncFeedPetRes));
				NetProcess.AddMsgHandler(502203U, new Action<MsgDATA>(this._OnNetSyncDeletePetRes));
				NetProcess.AddMsgHandler(502210U, new Action<MsgDATA>(this._OnNetSyncSellPetRes));
				NetProcess.AddMsgHandler(502212U, new Action<MsgDATA>(this._OnNetSyncChangePetSkillRes));
				NetProcess.AddMsgHandler(502216U, new Action<MsgDATA>(this._OnNetSyncEatPetRes));
				this.m_bNetBind = true;
			}
		}

		// Token: 0x0600B92D RID: 47405 RVA: 0x002A6EB4 File Offset: 0x002A52B4
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(502201U, new Action<MsgDATA>(this._OnNetSyncInitPetList));
			NetProcess.RemoveMsgHandler(502202U, new Action<MsgDATA>(this._OnNetSyncUpdatePetList));
			NetProcess.RemoveMsgHandler(502214U, new Action<MsgDATA>(this._OnNetSyncSetPetFollowRes));
			NetProcess.RemoveMsgHandler(502206U, new Action<MsgDATA>(this._OnNetSyncSetPetSoltRes));
			NetProcess.RemoveMsgHandler(502208U, new Action<MsgDATA>(this._OnNetSyncFeedPetRes));
			NetProcess.RemoveMsgHandler(502203U, new Action<MsgDATA>(this._OnNetSyncDeletePetRes));
			NetProcess.RemoveMsgHandler(502210U, new Action<MsgDATA>(this._OnNetSyncSellPetRes));
			NetProcess.RemoveMsgHandler(502212U, new Action<MsgDATA>(this._OnNetSyncChangePetSkillRes));
			NetProcess.RemoveMsgHandler(502216U, new Action<MsgDATA>(this._OnNetSyncEatPetRes));
			this.m_bNetBind = false;
		}

		// Token: 0x0600B92E RID: 47406 RVA: 0x002A6F90 File Offset: 0x002A5390
		private void _OnNetSyncInitPetList(MsgDATA msg)
		{
			SceneSyncPetList sceneSyncPetList = new SceneSyncPetList();
			sceneSyncPetList.decode(msg.bytes);
			this.PetInfoList.Clear();
			this.OnUsePetInfoList.Clear();
			for (int i = 0; i < sceneSyncPetList.petList.Length; i++)
			{
				bool flag = false;
				for (int j = 0; j < sceneSyncPetList.battlePets.Length; j++)
				{
					if (sceneSyncPetList.petList[i].id == sceneSyncPetList.battlePets[j])
					{
						this.OnUsePetInfoList.Add(sceneSyncPetList.petList[i]);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					this.PetInfoList.Add(sceneSyncPetList.petList[i]);
				}
			}
			for (int k = 0; k < this.OnUsePetInfoList.Count; k++)
			{
				if (this.OnUsePetInfoList[k].id == sceneSyncPetList.followPetId)
				{
					this.SetPetData(this.FollowPet, this.OnUsePetInfoList[k]);
					break;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PetInfoInited, null, null, null, null);
		}

		// Token: 0x0600B92F RID: 47407 RVA: 0x002A70BC File Offset: 0x002A54BC
		private void _OnNetSyncUpdatePetList(MsgDATA msg)
		{
			int num = 0;
			Pet pet = PetDecoder.Decode(msg.bytes, ref num, msg.bytes.Length);
			if (pet.id == this.FollowPet.id)
			{
				this.UpdateSyncPetData(this.FollowPet, pet);
				for (int i = 0; i < pet.dirtyFields.Count; i++)
				{
					if (pet.dirtyFields[i] == 3)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FollowPetSatietyChanged, null, null, null, null);
					}
				}
			}
			bool flag = false;
			for (int j = 0; j < this.OnUsePetInfoList.Count; j++)
			{
				if (this.OnUsePetInfoList[j].id == pet.id)
				{
					this.UpdateSyncPetData(this.OnUsePetInfoList[j], pet);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				for (int k = 0; k < this.PetInfoList.Count; k++)
				{
					if (this.PetInfoList[k].id == pet.id)
					{
						this.UpdateSyncPetData(this.PetInfoList[k], pet);
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				PetInfo petInfo = new PetInfo();
				petInfo.id = pet.id;
				petInfo.dataId = pet.dataId;
				this.UpdateSyncPetData(petInfo, pet);
				this.PetInfoList.Add(petInfo);
				this.SetPetData(this.NewOpenPet, petInfo);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PetItemsInfoUpdate, null, null, null, null);
		}

		// Token: 0x0600B930 RID: 47408 RVA: 0x002A725C File Offset: 0x002A565C
		private void _OnNetSyncSetPetFollowRes(MsgDATA msg)
		{
			SceneSetPetFollowRes sceneSetPetFollowRes = new SceneSetPetFollowRes();
			sceneSetPetFollowRes.decode(msg.bytes);
			if (sceneSetPetFollowRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneSetPetFollowRes.result, string.Empty);
				return;
			}
			if (sceneSetPetFollowRes.petId <= 0UL)
			{
				this.SetPetData(this.FollowPet, new PetInfo());
			}
			else
			{
				for (int i = 0; i < this.OnUsePetInfoList.Count; i++)
				{
					if (this.OnUsePetInfoList[i].id == sceneSetPetFollowRes.petId)
					{
						this.SetPetData(this.FollowPet, this.OnUsePetInfoList[i]);
						break;
					}
				}
			}
			if (sceneSetPetFollowRes.petId > 0UL)
			{
				SystemNotifyManager.SystemNotify(8508, string.Empty);
			}
		}

		// Token: 0x0600B931 RID: 47409 RVA: 0x002A7330 File Offset: 0x002A5730
		private void _OnNetSyncSetPetSoltRes(MsgDATA msg)
		{
			SceneSetPetSoltRes sceneSetPetSoltRes = new SceneSetPetSoltRes();
			sceneSetPetSoltRes.decode(msg.bytes);
			if (sceneSetPetSoltRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneSetPetSoltRes.result, string.Empty);
				return;
			}
			PetInfo petInfo = null;
			PetInfo petInfo2 = null;
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < this.OnUsePetInfoList.Count; i++)
			{
				bool flag3 = false;
				for (int j = 0; j < sceneSetPetSoltRes.battlePets.Length; j++)
				{
					if (this.OnUsePetInfoList[i].id == sceneSetPetSoltRes.battlePets[j])
					{
						flag3 = true;
						break;
					}
				}
				if (this.OnUsePetInfoList[i].id == sceneSetPetSoltRes.followPetId)
				{
					flag2 = true;
					this.SetPetData(this.FollowPet, this.OnUsePetInfoList[i]);
				}
				if (!flag3)
				{
					petInfo = new PetInfo();
					this.SetPetData(petInfo, this.OnUsePetInfoList[i]);
					this.PetInfoList.Add(petInfo);
					PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)petInfo.dataId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						num = tableItem.PetType - PetTable.ePetType.PT_ATTACK;
						break;
					}
				}
			}
			for (int k = 0; k < sceneSetPetSoltRes.battlePets.Length; k++)
			{
				bool flag4 = false;
				int index = 0;
				for (int l = 0; l < this.PetInfoList.Count; l++)
				{
					if (sceneSetPetSoltRes.battlePets[k] == this.PetInfoList[l].id)
					{
						flag4 = true;
						index = l;
						break;
					}
				}
				if (flag4)
				{
					if (this.PetInfoList[index].id == sceneSetPetSoltRes.followPetId)
					{
						flag2 = true;
						this.SetPetData(this.FollowPet, this.PetInfoList[index]);
					}
					petInfo2 = new PetInfo();
					this.SetPetData(petInfo2, this.PetInfoList[index]);
					this.OnUsePetInfoList.Add(petInfo2);
					this.PetInfoList.RemoveAt(index);
					PetTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)petInfo2.dataId, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						num = tableItem2.PetType - PetTable.ePetType.PT_ATTACK;
						flag = true;
						break;
					}
				}
			}
			if (!flag2)
			{
				this.SetPetData(this.FollowPet, new PetInfo());
			}
			if (petInfo != null)
			{
				for (int m = 0; m < this.OnUsePetInfoList.Count; m++)
				{
					if (petInfo.id == this.OnUsePetInfoList[m].id)
					{
						this.OnUsePetInfoList.RemoveAt(m);
						break;
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PetSlotChanged, num, flag, null, null);
			if (petInfo != null || petInfo2 != null)
			{
				this.ShowPetPropertyChange(petInfo, petInfo2);
			}
		}

		// Token: 0x0600B932 RID: 47410 RVA: 0x002A7638 File Offset: 0x002A5A38
		private void _OnNetSyncFeedPetRes(MsgDATA msg)
		{
			SceneFeedPetRes sceneFeedPetRes = new SceneFeedPetRes();
			sceneFeedPetRes.decode(msg.bytes);
			if (sceneFeedPetRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneFeedPetRes.result, string.Empty);
				return;
			}
			if (sceneFeedPetRes.value == 0U)
			{
				SystemNotifyManager.SystemNotify(8507, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PetFeedSuccess, sceneFeedPetRes.value, sceneFeedPetRes.isCritical, null, null);
		}

		// Token: 0x0600B933 RID: 47411 RVA: 0x002A76B4 File Offset: 0x002A5AB4
		private void _OnNetSyncDeletePetRes(MsgDATA msg)
		{
			SceneDeletePet sceneDeletePet = new SceneDeletePet();
			sceneDeletePet.decode(msg.bytes);
			for (int i = 0; i < this.PetInfoList.Count; i++)
			{
				if (this.PetInfoList[i].id == sceneDeletePet.id)
				{
					this.PetInfoList.RemoveAt(i);
					break;
				}
			}
		}

		// Token: 0x0600B934 RID: 47412 RVA: 0x002A771C File Offset: 0x002A5B1C
		private void _OnNetSyncSellPetRes(MsgDATA msg)
		{
			SceneSellPetRes sceneSellPetRes = new SceneSellPetRes();
			sceneSellPetRes.decode(msg.bytes);
			if (sceneSellPetRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneSellPetRes.result, string.Empty);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect("宠物出售成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PetItemsInfoUpdate, null, null, null, null);
		}

		// Token: 0x0600B935 RID: 47413 RVA: 0x002A7778 File Offset: 0x002A5B78
		private void _OnNetSyncChangePetSkillRes(MsgDATA msg)
		{
			SceneChangePetSkillRes sceneChangePetSkillRes = new SceneChangePetSkillRes();
			sceneChangePetSkillRes.decode(msg.bytes);
			if (sceneChangePetSkillRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneChangePetSkillRes.result, string.Empty);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect("修改成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PetPropertyReselect, sceneChangePetSkillRes.petId, null, null, null);
		}

		// Token: 0x0600B936 RID: 47414 RVA: 0x002A77DC File Offset: 0x002A5BDC
		private void _OnNetSyncEatPetRes(MsgDATA msg)
		{
			SceneDevourPetRes sceneDevourPetRes = new SceneDevourPetRes();
			sceneDevourPetRes.decode(msg.bytes);
			if (sceneDevourPetRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneDevourPetRes.result, string.Empty);
				return;
			}
			byte b = 0;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EatPetSuccess, sceneDevourPetRes.exp, b, null, null);
		}

		// Token: 0x0600B937 RID: 47415 RVA: 0x002A783B File Offset: 0x002A5C3B
		public List<PetInfo> GetPetList()
		{
			return this.PetInfoList;
		}

		// Token: 0x0600B938 RID: 47416 RVA: 0x002A7843 File Offset: 0x002A5C43
		public List<PetInfo> GetOnUsePetList()
		{
			return this.OnUsePetInfoList;
		}

		// Token: 0x17001B50 RID: 6992
		// (get) Token: 0x0600B939 RID: 47417 RVA: 0x002A784C File Offset: 0x002A5C4C
		protected int maxGoldFeedNum
		{
			get
			{
				if (this.mMaxGoldFeedNum < 0)
				{
					SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(228, string.Empty, string.Empty);
					if (tableItem != null)
					{
						this.mMaxGoldFeedNum = tableItem.Value;
					}
				}
				return this.mMaxGoldFeedNum;
			}
		}

		// Token: 0x0600B93A RID: 47418 RVA: 0x002A7898 File Offset: 0x002A5C98
		public bool IsSelectPetsContainGoldFeedCount()
		{
			List<PetInfo> onUsePetList = this.GetOnUsePetList();
			if (onUsePetList == null)
			{
				return false;
			}
			for (int i = 0; i < onUsePetList.Count; i++)
			{
				int num = int.MaxValue;
				PetTable tableItem = Singleton<TableManager>.instance.GetTableItem<PetTable>((int)onUsePetList[i].dataId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					num = tableItem.MaxLv;
				}
				if (this.SelectPetId == onUsePetList[i].id && (int)onUsePetList[i].goldFeedCount < this.maxGoldFeedNum && (int)onUsePetList[i].level < num)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B93B RID: 47419 RVA: 0x002A7944 File Offset: 0x002A5D44
		public int GetPetsContainGoldFeedCountTypeIndex()
		{
			List<PetInfo> onUsePetList = this.GetOnUsePetList();
			if (onUsePetList == null)
			{
				return -1;
			}
			for (int i = 0; i < onUsePetList.Count; i++)
			{
				int num = int.MaxValue;
				PetTable tableItem = Singleton<TableManager>.instance.GetTableItem<PetTable>((int)onUsePetList[i].dataId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					num = tableItem.MaxLv;
				}
				if ((int)onUsePetList[i].goldFeedCount < this.maxGoldFeedNum && (int)onUsePetList[i].level < num)
				{
					return tableItem.PetType - PetTable.ePetType.PT_ATTACK;
				}
			}
			return -1;
		}

		// Token: 0x0600B93C RID: 47420 RVA: 0x002A79E0 File Offset: 0x002A5DE0
		public bool IsOnUsePetsContainGoldFeedCount()
		{
			List<PetInfo> onUsePetList = this.GetOnUsePetList();
			if (onUsePetList == null)
			{
				return false;
			}
			for (int i = 0; i < onUsePetList.Count; i++)
			{
				int num = int.MaxValue;
				PetTable tableItem = Singleton<TableManager>.instance.GetTableItem<PetTable>((int)onUsePetList[i].dataId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					num = tableItem.MaxLv;
				}
				if ((int)onUsePetList[i].goldFeedCount < this.maxGoldFeedNum && (int)onUsePetList[i].level < num)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x17001B51 RID: 6993
		// (get) Token: 0x0600B93D RID: 47421 RVA: 0x002A7A73 File Offset: 0x002A5E73
		// (set) Token: 0x0600B93E RID: 47422 RVA: 0x002A7A7B File Offset: 0x002A5E7B
		public bool IsUserClickFeedCount
		{
			get
			{
				return this.mIsUserClickFeedCount;
			}
			set
			{
				this.mIsUserClickFeedCount = value;
			}
		}

		// Token: 0x0600B93F RID: 47423 RVA: 0x002A7A84 File Offset: 0x002A5E84
		public bool IsNeedShowOnUsePetsRedPoint()
		{
			return !this.IsUserClickFeedCount && this.IsOnUsePetsContainGoldFeedCount();
		}

		// Token: 0x0600B940 RID: 47424 RVA: 0x002A7A9A File Offset: 0x002A5E9A
		public bool SelectPetsNeedShowRedPoint()
		{
			return !this.IsUserClickFeedCount && this.IsSelectPetsContainGoldFeedCount();
		}

		// Token: 0x0600B941 RID: 47425 RVA: 0x002A7AB0 File Offset: 0x002A5EB0
		public bool IsContainNewPetEgg()
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ulong id = itemsByPackageType[i];
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
				if (item != null)
				{
					if (this.IsPetEggItem(item.TableID) && item.IsNew)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600B942 RID: 47426 RVA: 0x002A7B28 File Offset: 0x002A5F28
		public bool IsContainEquipPetPosition()
		{
			List<PetInfo> onUsePetList = this.GetOnUsePetList();
			return onUsePetList != null && onUsePetList.Count >= 3;
		}

		// Token: 0x0600B943 RID: 47427 RVA: 0x002A7B50 File Offset: 0x002A5F50
		public bool IsContainFitPet2Equip()
		{
			List<PetInfo> onUsePetList = this.GetOnUsePetList();
			if (onUsePetList == null)
			{
				return false;
			}
			List<PetTable.ePetType> list = new List<PetTable.ePetType>();
			list.Add(PetTable.ePetType.PT_ATTACK);
			list.Add(PetTable.ePetType.PT_PROPERTY);
			list.Add(PetTable.ePetType.PT_SUPPORT);
			for (int i = 0; i < onUsePetList.Count; i++)
			{
				PetTable tableItem = Singleton<TableManager>.instance.GetTableItem<PetTable>((int)onUsePetList[i].dataId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					list.Remove(tableItem.PetType);
				}
			}
			if (list.Count <= 0)
			{
				return false;
			}
			List<PetInfo> petList = this.GetPetList();
			for (int j = 0; j < petList.Count; j++)
			{
				PetTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<PetTable>((int)petList[j].dataId, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					for (int k = 0; k < list.Count; k++)
					{
						if (list[k] == tableItem2.PetType)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600B944 RID: 47428 RVA: 0x002A7C64 File Offset: 0x002A6064
		private void _initPetEGGIDMinMax()
		{
			if (this.mPetQueryInfo != null)
			{
				return;
			}
			this.mPetQueryInfo = new List<PetDataManager.PetQueryInfo>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<PetTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				PetTable petTable = keyValuePair.Value as PetTable;
				if (petTable != null)
				{
					this.mPetQueryInfo.Add(new PetDataManager.PetQueryInfo(petTable.ID, petTable.PetType, petTable.PetEggID));
				}
			}
		}

		// Token: 0x0600B945 RID: 47429 RVA: 0x002A7CF0 File Offset: 0x002A60F0
		public bool IsPetEggItemType(int petItemId, PetTable.ePetType type)
		{
			this._initPetEGGIDMinMax();
			for (int i = 0; i < this.mPetQueryInfo.Count; i++)
			{
				if (this.mPetQueryInfo[i].petEggId == petItemId && this.mPetQueryInfo[i].type == type)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B946 RID: 47430 RVA: 0x002A7D50 File Offset: 0x002A6150
		public bool IsPetEggItem(int itemid)
		{
			this._initPetEGGIDMinMax();
			for (int i = 0; i < this.mPetQueryInfo.Count; i++)
			{
				if (this.mPetQueryInfo[i].petEggId == itemid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B947 RID: 47431 RVA: 0x002A7D99 File Offset: 0x002A6199
		public bool IsNeedShowPetEggRedPoint()
		{
			return this.IsContainNewPetEgg();
		}

		// Token: 0x0600B948 RID: 47432 RVA: 0x002A7DA1 File Offset: 0x002A61A1
		public bool IsNeedShowPetRedPoint()
		{
			return !this.IsUseClickPetTab && this.IsContainFitPet2Equip();
		}

		// Token: 0x17001B52 RID: 6994
		// (get) Token: 0x0600B949 RID: 47433 RVA: 0x002A7DB6 File Offset: 0x002A61B6
		// (set) Token: 0x0600B94A RID: 47434 RVA: 0x002A7DBE File Offset: 0x002A61BE
		public bool IsUseClickPetTab
		{
			get
			{
				return this.mIsUserClickPetTab;
			}
			set
			{
				this.mIsUserClickPetTab = value;
			}
		}

		// Token: 0x0600B94B RID: 47435 RVA: 0x002A7DC8 File Offset: 0x002A61C8
		public bool IsSelfPet(PetItemTipsData petItem)
		{
			if (petItem != null && petItem.petinfo != null)
			{
				for (int i = 0; i < this.OnUsePetInfoList.Count; i++)
				{
					if (this.OnUsePetInfoList[i].id == petItem.petinfo.id)
					{
						return true;
					}
				}
				for (int j = 0; j < this.PetInfoList.Count; j++)
				{
					if (this.PetInfoList[j].id == petItem.petinfo.id)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600B94C RID: 47436 RVA: 0x002A7E68 File Offset: 0x002A6268
		public PetItemTipsData GetSelfOnUsePetByType(PetItemTipsData petItem)
		{
			if (petItem == null)
			{
				return null;
			}
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)petItem.petinfo.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			for (int i = 0; i < this.OnUsePetInfoList.Count; i++)
			{
				if (this.OnUsePetInfoList[i].id == petItem.petinfo.id)
				{
					return null;
				}
			}
			for (int j = 0; j < this.OnUsePetInfoList.Count; j++)
			{
				PetTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.OnUsePetInfoList[j].dataId, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					if (tableItem2.PetType == tableItem.PetType)
					{
						PetItemTipsData petItemTipsData = new PetItemTipsData();
						petItemTipsData.petinfo = new PetInfo();
						this.SetPetData(petItemTipsData.petinfo, this.OnUsePetInfoList[j]);
						petItemTipsData.petTipsType = PetTipsType.OnUsePetTip;
						petItemTipsData.PlayerJobID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
						return petItemTipsData;
					}
				}
			}
			return null;
		}

		// Token: 0x0600B94D RID: 47437 RVA: 0x002A7F8B File Offset: 0x002A638B
		public PetInfo GetFollowPet()
		{
			return this.FollowPet;
		}

		// Token: 0x0600B94E RID: 47438 RVA: 0x002A7F94 File Offset: 0x002A6394
		public bool IsFollowPetHungry()
		{
			return this.FollowPet != null && this.FollowPet.id > 0UL && this.FollowPet.dataId > 0U && (int)this.FollowPet.hunger <= this.PetHungryLimit;
		}

		// Token: 0x0600B94F RID: 47439 RVA: 0x002A7FE9 File Offset: 0x002A63E9
		public PetInfo GetNewOpenPet()
		{
			return this.NewOpenPet;
		}

		// Token: 0x0600B950 RID: 47440 RVA: 0x002A7FF1 File Offset: 0x002A63F1
		public void SetActiveFeed(bool bActive)
		{
			this.bHasActivieFeedPet = bActive;
		}

		// Token: 0x0600B951 RID: 47441 RVA: 0x002A7FFA File Offset: 0x002A63FA
		public bool GetIsActiveFeed()
		{
			return this.bHasActivieFeedPet;
		}

		// Token: 0x0600B952 RID: 47442 RVA: 0x002A8004 File Offset: 0x002A6404
		public string GetColorName(string name, PetTable.eQuality PetQuality)
		{
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo((ItemTable.eColor)PetQuality, false, false);
			if (qualityInfo != null)
			{
				return TR.Value("common_color_text", qualityInfo.ColStr, name);
			}
			return string.Empty;
		}

		// Token: 0x0600B953 RID: 47443 RVA: 0x002A8038 File Offset: 0x002A6438
		public string GetQualityDesc(PetTable.eQuality PetQuality)
		{
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo((ItemTable.eColor)PetQuality, false, false);
			if (qualityInfo != null)
			{
				return string.Format("<color={0}>{1}</color>", qualityInfo.ColStr, qualityInfo.Desc);
			}
			return string.Empty;
		}

		// Token: 0x0600B954 RID: 47444 RVA: 0x002A8070 File Offset: 0x002A6470
		public string GetQualityTipTitleBackGround(PetTable.eQuality PetQuality)
		{
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo((ItemTable.eColor)PetQuality, false, false);
			if (qualityInfo == null)
			{
				return string.Empty;
			}
			return qualityInfo.TipTitleBackGround;
		}

		// Token: 0x0600B955 RID: 47445 RVA: 0x002A8098 File Offset: 0x002A6498
		public string GetQualityIconBack(PetTable.eQuality PetQuality)
		{
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo((ItemTable.eColor)PetQuality, false, false);
			if (qualityInfo != null)
			{
				return qualityInfo.Background;
			}
			return string.Empty;
		}

		// Token: 0x0600B956 RID: 47446 RVA: 0x002A80C0 File Offset: 0x002A64C0
		public string GetQualityTitleBack(PetTable.eQuality PetQuality)
		{
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo((ItemTable.eColor)PetQuality, false, false);
			if (qualityInfo != null)
			{
				return qualityInfo.TitleBG;
			}
			return string.Empty;
		}

		// Token: 0x0600B957 RID: 47447 RVA: 0x002A80E8 File Offset: 0x002A64E8
		public string GetPetTypeDesc(PetTable.ePetType petType)
		{
			if (petType == PetTable.ePetType.PT_ATTACK)
			{
				return "主动型";
			}
			if (petType == PetTable.ePetType.PT_PROPERTY)
			{
				return "技能型";
			}
			if (petType == PetTable.ePetType.PT_SUPPORT)
			{
				return "辅助型";
			}
			return string.Empty;
		}

		// Token: 0x0600B958 RID: 47448 RVA: 0x002A8116 File Offset: 0x002A6516
		public string GetPetTypeIconPath(PetTable.ePetType petType)
		{
			if (petType == PetTable.ePetType.PT_ATTACK)
			{
				return "UI/Image/Packed/p_UI_Pet.png:UI_Pet_Tubiao_Gongjixing";
			}
			if (petType == PetTable.ePetType.PT_PROPERTY)
			{
				return "UI/Image/Packed/p_UI_Pet.png:UI_Pet_Tubiao_Shuxingxing";
			}
			if (petType == PetTable.ePetType.PT_SUPPORT)
			{
				return "UI/Image/Packed/p_UI_Pet.png:UI_Pet_Tubiao_Zhiyuanxing";
			}
			return string.Empty;
		}

		// Token: 0x0600B959 RID: 47449 RVA: 0x002A8144 File Offset: 0x002A6544
		public int GetMaxShowStarNums(int iMaxLevel)
		{
			return iMaxLevel / 10;
		}

		// Token: 0x0600B95A RID: 47450 RVA: 0x002A814A File Offset: 0x002A654A
		public int ShowPetHalfStarNum(int iPetLevel)
		{
			return iPetLevel / 5;
		}

		// Token: 0x0600B95B RID: 47451 RVA: 0x002A8150 File Offset: 0x002A6550
		public void UpdateStarsShow(PetTable petData, PetInfo CurSelPetInfo, int addLevel, ref UIGray[] starsGray, ref Image[] HalfStars, ref Image[] HalfShadowStars, bool bWillPlayStarEffect = false, int iStarGrayIndex = -1)
		{
			int maxShowStarNums = this.GetMaxShowStarNums(petData.MaxLv);
			int num = this.ShowPetHalfStarNum((int)CurSelPetInfo.level);
			int num2 = (int)CurSelPetInfo.level + addLevel;
			num2 = IntMath.Min(num2, petData.MaxLv);
			int a = this.ShowPetHalfStarNum(petData.MaxLv);
			int num3 = this.ShowPetHalfStarNum(num2);
			num3 = IntMath.Min(a, num3);
			for (int i = 0; i < starsGray.Length; i++)
			{
				if (i < maxShowStarNums)
				{
					if (i * 2 < num)
					{
						HalfStars[i * 2].gameObject.CustomActive(true);
					}
					else
					{
						HalfStars[i * 2].gameObject.CustomActive(false);
					}
					if (i * 2 < HalfShadowStars.Length)
					{
						if (i * 2 < num3)
						{
							HalfShadowStars[i * 2].gameObject.CustomActive(true);
						}
						else
						{
							HalfShadowStars[i * 2].gameObject.CustomActive(false);
						}
					}
					if (bWillPlayStarEffect && iStarGrayIndex == i)
					{
						HalfStars[i * 2 + 1].gameObject.CustomActive(false);
						if (i * 2 + 1 < HalfShadowStars.Length)
						{
							HalfShadowStars[i * 2 + 1].gameObject.CustomActive(true);
						}
					}
					else
					{
						if (i * 2 + 1 < num)
						{
							HalfStars[i * 2 + 1].gameObject.CustomActive(true);
						}
						else
						{
							HalfStars[i * 2 + 1].gameObject.CustomActive(false);
						}
						if (i * 2 + 1 < HalfShadowStars.Length)
						{
							if (i * 2 + 1 < num3)
							{
								HalfShadowStars[i * 2 + 1].gameObject.CustomActive(true);
							}
							else
							{
								HalfShadowStars[i * 2 + 1].gameObject.CustomActive(false);
							}
						}
					}
					if (starsGray[i] != null && starsGray[i].gameObject != null)
					{
						starsGray[i].gameObject.CustomActive(true);
					}
				}
				else
				{
					HalfStars[i * 2].gameObject.CustomActive(false);
					HalfStars[i * 2 + 1].gameObject.CustomActive(false);
					if (i * 2 < HalfShadowStars.Length)
					{
						HalfShadowStars[i * 2].gameObject.CustomActive(false);
					}
					if (i * 2 + 1 < HalfShadowStars.Length)
					{
						HalfShadowStars[i * 2 + 1].gameObject.CustomActive(false);
					}
					if (starsGray[i] != null && starsGray[i].gameObject != null)
					{
						starsGray[i].gameObject.CustomActive(false);
					}
				}
			}
		}

		// Token: 0x0600B95C RID: 47452 RVA: 0x002A8404 File Offset: 0x002A6804
		public void UpdatePetStarImage(int iGrayStarIndex, ref Image[] HalfStars)
		{
			for (int i = 0; i < HalfStars.Length; i++)
			{
				if (i == iGrayStarIndex * 2 + 1)
				{
					HalfStars[i].gameObject.CustomActive(true);
					break;
				}
			}
		}

		// Token: 0x0600B95D RID: 47453 RVA: 0x002A8448 File Offset: 0x002A6848
		public int GetFeedNeedMoney(PetInfo SelPetInfo, PetFeedTable.eType Feedtype, ref int Exp)
		{
			PetFeedTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetFeedTable>((int)Feedtype, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return -1;
			}
			int index = 0;
			if (Feedtype == PetFeedTable.eType.PET_FEED_GOLD)
			{
				if ((int)SelPetInfo.goldFeedCount >= tableItem.ConsumeItem.Count)
				{
					index = tableItem.ConsumeItem.Count - 1;
				}
			}
			else if (Feedtype == PetFeedTable.eType.PET_FEED_POINT)
			{
				if ((int)SelPetInfo.pointFeedCount >= tableItem.ConsumeItem.Count)
				{
					index = tableItem.ConsumeItem.Count - 1;
				}
			}
			string text = string.Empty;
			if (Feedtype == PetFeedTable.eType.PET_FEED_GOLD)
			{
				text = tableItem.ConsumeItem[index];
			}
			else if (Feedtype == PetFeedTable.eType.PET_FEED_POINT)
			{
				text = tableItem.ConsumeItem[index];
			}
			string[] array = text.Split(new char[]
			{
				'_'
			});
			if (array.Length < 3)
			{
				return -1;
			}
			int result = int.Parse(array[1]);
			Exp = int.Parse(array[2]);
			return result;
		}

		// Token: 0x0600B95E RID: 47454 RVA: 0x002A853C File Offset: 0x002A693C
		public int GetPetFoodNum(ref int FoodItemTableID)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Pet);
			if (itemsByPackageType == null)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					if (i == 0)
					{
						FoodItemTableID = item.TableID;
					}
					num += item.Count;
				}
			}
			return num;
		}

		// Token: 0x0600B95F RID: 47455 RVA: 0x002A85AC File Offset: 0x002A69AC
		public string GetPetPropertyTips(PetTable Petdata, int CurPetLevel = 1)
		{
			string str = string.Empty;
			str = "<color=#50ef44ff>[属性加成]</color>\n";
			return str + DataManager<SkillDataManager>.GetInstance().UpdateSkillDescription(Petdata.InnateSkill, (byte)CurPetLevel, (byte)CurPetLevel, FightTypeLabel.PVE);
		}

		// Token: 0x0600B960 RID: 47456 RVA: 0x002A85E4 File Offset: 0x002A69E4
		public string GetPetCurSkillTips(PetTable Petdata, int JobTableID, int CurSkillIndex = 0, int CurPetLevel = 1, bool bNeedHead = true)
		{
			string text = string.Empty;
			int petSkillIDByIndex = this.GetPetSkillIDByIndex(Petdata, CurSkillIndex, JobTableID);
			if (petSkillIDByIndex < 0)
			{
				return text;
			}
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(petSkillIDByIndex, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return text;
			}
			List<int> petSkillIDsByJob = this.GetPetSkillIDsByJob(Petdata, JobTableID);
			if (petSkillIDsByJob.Count <= 0)
			{
				return text;
			}
			if (bNeedHead)
			{
				if (Petdata.PetType == PetTable.ePetType.PT_ATTACK)
				{
					text = string.Format("<color=#50ef44ff>当前技能：{0}</color>\n", tableItem.Name);
				}
				else
				{
					text = string.Format("<color=#50ef44ff>当前属性：{0}</color>\n", tableItem.Name);
				}
			}
			int skillID;
			if (CurSkillIndex >= 0 && CurSkillIndex < petSkillIDsByJob.Count)
			{
				skillID = petSkillIDsByJob[CurSkillIndex];
			}
			else
			{
				skillID = petSkillIDsByJob[0];
			}
			return text + DataManager<SkillDataManager>.GetInstance().UpdatePetSkillDescription(skillID, (byte)CurPetLevel, (byte)CurPetLevel, FightTypeLabel.PVE);
		}

		// Token: 0x0600B961 RID: 47457 RVA: 0x002A86C4 File Offset: 0x002A6AC4
		public string GetCanSelectSkillTips(PetTable Petdata, int PlayerJobID, int CurSkillIndex = 0, int CurPetLevel = 1)
		{
			string text = string.Empty;
			if (CurSkillIndex != 0)
			{
				if (Petdata.PetType == PetTable.ePetType.PT_ATTACK)
				{
					text = "<color=#9FA2B8FF>可选技能：\n";
				}
				else
				{
					text = "<color=#9FA2B8FF>可选属性：\n";
				}
			}
			else if (Petdata.PetType == PetTable.ePetType.PT_ATTACK)
			{
				text = "<color=#50ef44ff>可选技能：</color>\n";
			}
			else
			{
				text = "<color=#50ef44ff>可选属性：</color>\n";
			}
			List<int> petSkillIDsByJob = this.GetPetSkillIDsByJob(Petdata, PlayerJobID);
			if (petSkillIDsByJob.Count <= 0)
			{
				return text;
			}
			for (int i = 0; i < petSkillIDsByJob.Count; i++)
			{
				if (i != CurSkillIndex)
				{
					SkillDescriptionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(petSkillIDsByJob[i], string.Empty, string.Empty);
					if (tableItem != null)
					{
						text += string.Format("[{0}]\n", tableItem.Name);
						List<string> petSkillDesList = DataManager<SkillDataManager>.GetInstance().GetPetSkillDesList(tableItem.ID, (byte)CurPetLevel, FightTypeLabel.PVE);
						for (int j = 0; j < petSkillDesList.Count; j++)
						{
							text += string.Format("{0}\n", petSkillDesList[j]);
						}
					}
				}
			}
			if (CurSkillIndex != 0)
			{
				text += "</color>";
			}
			if (text.Length <= 31 || text.Length <= 23)
			{
				text = string.Empty;
			}
			return text;
		}

		// Token: 0x0600B962 RID: 47458 RVA: 0x002A8814 File Offset: 0x002A6C14
		public int GetPetSkillIDByIndex(PetTable Petdata, int iIndex, int JobTableID)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < Petdata.Skills.Count; i++)
			{
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(Petdata.Skills[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					bool flag = false;
					for (int j = 0; j < tableItem.JobID.Count; j++)
					{
						if (tableItem.JobID[0] == 0)
						{
							flag = true;
							break;
						}
						if (tableItem.JobID[j] == JobTableID)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						list.Add(Petdata.Skills[i]);
					}
				}
			}
			if (list.Count <= 0 || iIndex >= list.Count)
			{
				return list[0];
			}
			return list[iIndex];
		}

		// Token: 0x0600B963 RID: 47459 RVA: 0x002A8904 File Offset: 0x002A6D04
		public List<int> GetPetSkillIDsByJob(PetTable Petdata, int PlayerJobID)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < Petdata.Skills.Count; i++)
			{
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(Petdata.Skills[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					bool flag = false;
					for (int j = 0; j < tableItem.JobID.Count; j++)
					{
						if (tableItem.JobID[0] == 0)
						{
							flag = true;
							break;
						}
						if (tableItem.JobID[j] == PlayerJobID)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						list.Add(Petdata.Skills[i]);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B964 RID: 47460 RVA: 0x002A89CC File Offset: 0x002A6DCC
		public static int GetPetSkillIDByJob(int iPetTableID, int iJobID, int iIndex)
		{
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>(iPetTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return -1;
			}
			List<int> list = new List<int>();
			for (int i = 0; i < tableItem.Skills.Count; i++)
			{
				SkillTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(tableItem.Skills[i], string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					bool flag = false;
					for (int j = 0; j < tableItem2.JobID.Count; j++)
					{
						if (tableItem2.JobID[0] == 0)
						{
							flag = true;
							break;
						}
						if (tableItem2.JobID[j] == iJobID)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						list.Add(tableItem.Skills[i]);
					}
				}
			}
			if (list.Count <= 0 || iIndex >= list.Count)
			{
				return -1;
			}
			return list[iIndex];
		}

		// Token: 0x0600B965 RID: 47461 RVA: 0x002A8AD8 File Offset: 0x002A6ED8
		public List<PetInfo> GetPetSortListBySortType(List<PetInfo> UnSortPetInfoList, ref int iCount, PetItemSortType SortType = PetItemSortType.QualitySort, int MaxNum = 0)
		{
			List<PetInfo> list = new List<PetInfo>();
			int num = UnSortPetInfoList.Count;
			if (MaxNum != 0)
			{
				num = MaxNum;
			}
			int num2 = 0;
			while (num2 < UnSortPetInfoList.Count && num2 < num)
			{
				PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)UnSortPetInfoList[num2].dataId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					PetInfo petInfo = new PetInfo();
					this.SetPetData(petInfo, UnSortPetInfoList[num2]);
					if (list.Count <= 0)
					{
						list.Add(petInfo);
					}
					else
					{
						for (int i = 0; i < list.Count; i++)
						{
							PetTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)list[i].dataId, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (SortType == PetItemSortType.QualitySort)
								{
									if (tableItem.Quality > tableItem2.Quality)
									{
										list.Insert(i, petInfo);
										break;
									}
								}
								else if (SortType == PetItemSortType.PetTypeSort && tableItem.PetType < tableItem2.PetType)
								{
									list.Insert(i, petInfo);
									break;
								}
								if (i == list.Count - 1)
								{
									list.Add(petInfo);
									break;
								}
							}
						}
					}
					iCount++;
				}
				num2++;
			}
			for (int j = 0; j < list.Count; j++)
			{
				PetTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)list[j].dataId, string.Empty, string.Empty);
				if (tableItem3 != null)
				{
					for (int k = j + 1; k < list.Count; k++)
					{
						PetTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)list[k].dataId, string.Empty, string.Empty);
						if (tableItem4 != null)
						{
							bool flag = false;
							if (SortType == PetItemSortType.QualitySort)
							{
								if (tableItem4.Quality == tableItem3.Quality && list[k].level > list[j].level)
								{
									flag = true;
								}
							}
							else if (SortType == PetItemSortType.PetTypeSort && tableItem4.PetType == tableItem3.PetType && list[k].level > list[j].level)
							{
								flag = true;
							}
							if (flag)
							{
								PetInfo petInfo2 = new PetInfo();
								this.SetPetData(petInfo2, list[j]);
								PetInfo petInfo3 = new PetInfo();
								this.SetPetData(petInfo3, list[k]);
								list[j] = petInfo3;
								list[k] = petInfo2;
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600B966 RID: 47462 RVA: 0x002A8D98 File Offset: 0x002A7198
		public void SetPetItemData(GameObject root, PetInfo petinfo, int PlayerJobID, PetTipsType petTipsType = PetTipsType.None, bool bIsCoverState = false)
		{
			if (root == null)
			{
				return;
			}
			ComCommonBind component = root.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)petinfo.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			Image com = component.GetCom<Image>("IconRoot");
			Image com2 = component.GetCom<Image>("Icon");
			Button com3 = component.GetCom<Button>("btPetItem");
			Text com4 = component.GetCom<Text>("Level");
			Image com5 = component.GetCom<Image>("TypeIcon");
			GameObject gameObject = component.GetGameObject("StarsRoot");
			Image com6 = component.GetCom<Image>("Cover");
			if (!string.IsNullOrEmpty(tableItem.IconPath) && tableItem.IconPath != "-")
			{
				ETCImageLoader.LoadSprite(ref com2, tableItem.IconPath, true);
			}
			string qualityIconBack = this.GetQualityIconBack(tableItem.Quality);
			if (!string.IsNullOrEmpty(qualityIconBack) && qualityIconBack != "-")
			{
				ETCImageLoader.LoadSprite(ref com, qualityIconBack, true);
			}
			string petTypeIconPath = this.GetPetTypeIconPath(tableItem.PetType);
			if (!string.IsNullOrEmpty(petTypeIconPath) && petTypeIconPath != "-")
			{
				ETCImageLoader.LoadSprite(ref com5, petTypeIconPath, true);
			}
			com4.text = string.Format("Lv.{0}", petinfo.level);
			com.gameObject.CustomActive(true);
			if (petTipsType != PetTipsType.OnUsePetTip)
			{
				com3.onClick.AddListener(delegate()
				{
					this.OnShowPetTips(petinfo, PlayerJobID, petTipsType);
				});
			}
			Image[] componentsInChildren = gameObject.GetComponentsInChildren<Image>(true);
			int num = this.ShowPetHalfStarNum((int)petinfo.level);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (i < num)
				{
					componentsInChildren[i].gameObject.CustomActive(true);
				}
				else
				{
					componentsInChildren[i].gameObject.CustomActive(false);
				}
			}
			if (com6 != null)
			{
				if (bIsCoverState)
				{
					com6.gameObject.CustomActive(true);
				}
				else
				{
					com6.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x0600B967 RID: 47463 RVA: 0x002A8FF4 File Offset: 0x002A73F4
		public void OnShowPetTips(PetInfo petinfo, int PlayerJobID, PetTipsType petTipsType = PetTipsType.None)
		{
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			PetItemTipsData petItemTipsData = new PetItemTipsData();
			petItemTipsData.petinfo = new PetInfo();
			this.SetPetData(petItemTipsData.petinfo, petinfo);
			petItemTipsData.petTipsType = petTipsType;
			petItemTipsData.PlayerJobID = PlayerJobID;
			petItemTipsData.bFunc = this.IsSelfPet(petItemTipsData);
			PetItemTipsData selfOnUsePetByType = this.GetSelfOnUsePetByType(petItemTipsData);
			if (selfOnUsePetByType != null)
			{
				selfOnUsePetByType.bFunc = false;
			}
			DataManager<ItemTipManager>.GetInstance().ShowPetTips(petItemTipsData, selfOnUsePetByType);
		}

		// Token: 0x0600B968 RID: 47464 RVA: 0x002A9068 File Offset: 0x002A7468
		public void ShowPetPropertyChange(PetInfo bef, PetInfo aft)
		{
			List<BetterEquipmentData> petPropChanges = this.GetPetPropChanges(bef, aft);
			if (petPropChanges != null)
			{
				this.PopUpChangedAttrbutes(petPropChanges);
			}
		}

		// Token: 0x0600B969 RID: 47465 RVA: 0x002A908C File Offset: 0x002A748C
		private List<BetterEquipmentData> GetPetPropChanges(PetInfo bef, PetInfo aft)
		{
			List<BetterEquipmentData> list = new List<BetterEquipmentData>();
			if (bef == null && aft == null)
			{
				return list;
			}
			if (bef == null)
			{
				PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)aft.dataId, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return list;
				}
				List<string> skillDesList = DataManager<SkillDataManager>.GetInstance().GetSkillDesList(tableItem.InnateSkill, (byte)aft.level, FightTypeLabel.PVE);
				for (int i = 0; i < skillDesList.Count; i++)
				{
					string[] array = skillDesList[i].Split(new char[]
					{
						':'
					});
					if (array.Length >= 2)
					{
						list.Add(new BetterEquipmentData
						{
							PreData = string.Empty,
							CurData = array[0] + ":+" + array[1]
						});
					}
				}
			}
			else if (aft == null)
			{
				PetTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)bef.dataId, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					return list;
				}
				List<string> skillDesList2 = DataManager<SkillDataManager>.GetInstance().GetSkillDesList(tableItem2.InnateSkill, (byte)bef.level, FightTypeLabel.PVE);
				for (int j = 0; j < skillDesList2.Count; j++)
				{
					string[] array2 = skillDesList2[j].Split(new char[]
					{
						':'
					});
					if (array2.Length >= 2)
					{
						list.Add(new BetterEquipmentData
						{
							PreData = array2[0] + ":-" + array2[1],
							CurData = string.Empty
						});
					}
				}
			}
			else
			{
				PetTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)bef.dataId, string.Empty, string.Empty);
				PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)aft.dataId, string.Empty, string.Empty);
				if (tableItem2 == null || tableItem == null)
				{
					return list;
				}
				List<string> skillDesList2 = DataManager<SkillDataManager>.GetInstance().GetSkillDesList(tableItem2.InnateSkill, (byte)bef.level, FightTypeLabel.PVE);
				List<string> skillDesList = DataManager<SkillDataManager>.GetInstance().GetSkillDesList(tableItem.InnateSkill, (byte)aft.level, FightTypeLabel.PVE);
				List<float> skillDataList = DataManager<SkillDataManager>.GetInstance().GetSkillDataList(tableItem2.InnateSkill, (byte)bef.level, FightTypeLabel.PVE);
				List<float> skillDataList2 = DataManager<SkillDataManager>.GetInstance().GetSkillDataList(tableItem.InnateSkill, (byte)aft.level, FightTypeLabel.PVE);
				List<int> list2 = new List<int>();
				for (int k = 0; k < skillDesList2.Count; k++)
				{
					string[] array3 = skillDesList2[k].Split(new char[]
					{
						':'
					});
					if (array3.Length >= 2)
					{
						bool flag = false;
						for (int l = 0; l < skillDesList.Count; l++)
						{
							string[] array4 = skillDesList[l].Split(new char[]
							{
								':'
							});
							if (array4.Length < 2)
							{
								list2.Add(l);
							}
							else if (string.Equals(array3[0], array4[0]))
							{
								list2.Add(l);
								if (skillDataList[k] == skillDataList2[l])
								{
									flag = true;
									break;
								}
								BetterEquipmentData item = default(BetterEquipmentData);
								item.PreData = array3[0] + ":";
								if (skillDataList[k] > skillDataList2[l])
								{
									item.CurData = "-" + Utility.GetStringByFloat(skillDataList[k] - skillDataList2[l]);
								}
								else
								{
									item.CurData = "+" + Utility.GetStringByFloat(skillDataList2[l] - skillDataList[k]);
								}
								list.Add(item);
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							list.Add(new BetterEquipmentData
							{
								PreData = array3[0] + ":-" + array3[1],
								CurData = string.Empty
							});
						}
					}
				}
				for (int m = 0; m < skillDesList.Count; m++)
				{
					bool flag2 = false;
					for (int n = 0; n < list2.Count; n++)
					{
						if (m == list2[n])
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						string[] array5 = skillDesList[m].Split(new char[]
						{
							':'
						});
						if (array5.Length >= 2)
						{
							list.Add(new BetterEquipmentData
							{
								PreData = string.Empty,
								CurData = array5[0] + ":+" + array5[1]
							});
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600B96A RID: 47466 RVA: 0x002A9548 File Offset: 0x002A7948
		private void PopUpChangedAttrbutes(List<BetterEquipmentData> data)
		{
			for (int i = 0; i < data.Count; i++)
			{
				string msgContent = string.Empty;
				if (data[i].PreData == string.Empty)
				{
					msgContent = data[i].CurData;
				}
				else if (data[i].CurData == string.Empty)
				{
					msgContent = data[i].PreData;
				}
				else
				{
					msgContent = data[i].PreData + data[i].CurData;
				}
				SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600B96B RID: 47467 RVA: 0x002A9608 File Offset: 0x002A7A08
		public void OpenPetInfoFrame(PetInfoTabType tabType, PetInfo SourcePetInfo)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PetInfoFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<PetInfoFrame>(null, false);
			}
			InitPetData initPetData = default(InitPetData);
			initPetData.PetTabType = tabType;
			initPetData.petinfo = new PetInfo();
			this.SetPetData(initPetData.petinfo, SourcePetInfo);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PetInfoFrame>(FrameLayer.Middle, initPetData, string.Empty);
		}

		// Token: 0x0600B96C RID: 47468 RVA: 0x002A9674 File Offset: 0x002A7A74
		public void SetPetData(PetInfo ReceivePetData, PetInfo GivePetData)
		{
			ReceivePetData.id = GivePetData.id;
			ReceivePetData.dataId = GivePetData.dataId;
			ReceivePetData.level = GivePetData.level;
			ReceivePetData.exp = GivePetData.exp;
			ReceivePetData.skillIndex = GivePetData.skillIndex;
			ReceivePetData.hunger = GivePetData.hunger;
			ReceivePetData.goldFeedCount = GivePetData.goldFeedCount;
			ReceivePetData.pointFeedCount = GivePetData.pointFeedCount;
			ReceivePetData.selectSkillCount = GivePetData.selectSkillCount;
			ReceivePetData.petScore = GivePetData.petScore;
		}

		// Token: 0x0600B96D RID: 47469 RVA: 0x002A96FC File Offset: 0x002A7AFC
		public void UpdateSyncPetData(PetInfo ReceivePetData, Pet GivePetData)
		{
			for (int i = 0; i < GivePetData.dirtyFields.Count; i++)
			{
				if (GivePetData.dirtyFields[i] == 2)
				{
					ReceivePetData.exp = GivePetData.exp;
				}
				else if (GivePetData.dirtyFields[i] == 1)
				{
					ReceivePetData.level = GivePetData.level;
				}
				else if (GivePetData.dirtyFields[i] == 3)
				{
					ReceivePetData.hunger = GivePetData.hunger;
				}
				else if (GivePetData.dirtyFields[i] == 4)
				{
					ReceivePetData.skillIndex = GivePetData.skillIndex;
				}
				else if (GivePetData.dirtyFields[i] == 5)
				{
					ReceivePetData.goldFeedCount = GivePetData.goldFeedCount;
				}
				else if (GivePetData.dirtyFields[i] == 6)
				{
					ReceivePetData.pointFeedCount = GivePetData.pointFeedCount;
				}
				else if (GivePetData.dirtyFields[i] == 7)
				{
					ReceivePetData.selectSkillCount = GivePetData.selectSkillCount;
				}
				else if (GivePetData.dirtyFields[i] == 8)
				{
					ReceivePetData.petScore = GivePetData.petScore;
				}
			}
		}

		// Token: 0x0600B96E RID: 47470 RVA: 0x002A9838 File Offset: 0x002A7C38
		public void SendFeedPetReq(PetFeedTable.eType type, ulong PetGUID, bool isAutoSend = false)
		{
			SceneFeedPetReq sceneFeedPetReq = new SceneFeedPetReq();
			sceneFeedPetReq.id = PetGUID;
			sceneFeedPetReq.feedType = (byte)type;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneFeedPetReq>(ServerType.GATE_SERVER, sceneFeedPetReq);
			if (type == PetFeedTable.eType.PET_FEED_ITEM)
			{
				PetInfo followPet = this.GetFollowPet();
				if (PetGUID == followPet.id)
				{
					if (isAutoSend)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayActiveFeedPetAction, null, null, null, null);
					}
					else
					{
						this.SetActiveFeed(true);
					}
				}
			}
		}

		// Token: 0x0600B96F RID: 47471 RVA: 0x002A98A8 File Offset: 0x002A7CA8
		public void OnUpdate(float timeElapsed)
		{
			this.fTimeIntrval += timeElapsed;
			if (this.fTimeIntrval > this.CheckHungerTime)
			{
				this.fTimeIntrval = 0f;
				if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
				{
					return;
				}
				if (this.OnUsePetInfoList == null || this.OnUsePetInfoList.Count <= 0)
				{
					return;
				}
				int num = 0;
				int num2 = this.GetPetFoodNum(ref num);
				for (int i = 0; i < this.OnUsePetInfoList.Count; i++)
				{
					if ((int)this.OnUsePetInfoList[i].hunger < this.PetHungryLimit && num2 > 0)
					{
						this.SendFeedPetReq(PetFeedTable.eType.PET_FEED_ITEM, this.OnUsePetInfoList[i].id, true);
						num2--;
					}
				}
			}
		}

		// Token: 0x0400683E RID: 26686
		private bool m_bNetBind;

		// Token: 0x0400683F RID: 26687
		private float CheckHungerTime = 5f;

		// Token: 0x04006840 RID: 26688
		private int PetHungryLimit;

		// Token: 0x04006841 RID: 26689
		private List<PetInfo> PetInfoList = new List<PetInfo>();

		// Token: 0x04006842 RID: 26690
		private List<PetInfo> OnUsePetInfoList = new List<PetInfo>();

		// Token: 0x04006843 RID: 26691
		private PetInfo FollowPet = new PetInfo();

		// Token: 0x04006844 RID: 26692
		private PetInfo NewOpenPet = new PetInfo();

		// Token: 0x04006845 RID: 26693
		private bool bHasActivieFeedPet;

		// Token: 0x04006846 RID: 26694
		private float fTimeIntrval;

		// Token: 0x04006847 RID: 26695
		private ulong selectPetIndex;

		// Token: 0x04006848 RID: 26696
		private int mMaxGoldFeedNum = -1;

		// Token: 0x04006849 RID: 26697
		private bool mIsUserClickFeedCount;

		// Token: 0x0400684A RID: 26698
		private List<PetDataManager.PetQueryInfo> mPetQueryInfo;

		// Token: 0x0400684B RID: 26699
		private bool mIsUserClickPetTab;

		// Token: 0x020012BD RID: 4797
		private class PetQueryInfo
		{
			// Token: 0x0600B970 RID: 47472 RVA: 0x002A997A File Offset: 0x002A7D7A
			public PetQueryInfo(int id, PetTable.ePetType type, int petEggId)
			{
				this.id = id;
				this.type = type;
				this.petEggId = petEggId;
			}

			// Token: 0x17001B53 RID: 6995
			// (get) Token: 0x0600B971 RID: 47473 RVA: 0x002A9997 File Offset: 0x002A7D97
			// (set) Token: 0x0600B972 RID: 47474 RVA: 0x002A999F File Offset: 0x002A7D9F
			public int id { get; private set; }

			// Token: 0x17001B54 RID: 6996
			// (get) Token: 0x0600B973 RID: 47475 RVA: 0x002A99A8 File Offset: 0x002A7DA8
			// (set) Token: 0x0600B974 RID: 47476 RVA: 0x002A99B0 File Offset: 0x002A7DB0
			public PetTable.ePetType type { get; private set; }

			// Token: 0x17001B55 RID: 6997
			// (get) Token: 0x0600B975 RID: 47477 RVA: 0x002A99B9 File Offset: 0x002A7DB9
			// (set) Token: 0x0600B976 RID: 47478 RVA: 0x002A99C1 File Offset: 0x002A7DC1
			public int petEggId { get; private set; }
		}
	}
}
