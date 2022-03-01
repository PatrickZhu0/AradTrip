using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012F0 RID: 4848
	public class StorageDataManager : DataManager<StorageDataManager>
	{
		// Token: 0x0600BC2B RID: 48171 RVA: 0x002BDE92 File Offset: 0x002BC292
		public override void Initialize()
		{
			this.BindEvents();
		}

		// Token: 0x0600BC2C RID: 48172 RVA: 0x002BDE9A File Offset: 0x002BC29A
		public override void Clear()
		{
			this.ClearData();
			this.UnBindEvents();
		}

		// Token: 0x0600BC2D RID: 48173 RVA: 0x002BDEA8 File Offset: 0x002BC2A8
		private void ClearData()
		{
			this._roleStorageCurrentSelectedIndex = 0;
			this._roleStorageOwnerStorageNumber = 0;
			this._roleStorageSetNameDic.Clear();
			this.CurrentStorageType = StorageType.RoleStorage;
		}

		// Token: 0x0600BC2E RID: 48174 RVA: 0x002BDECC File Offset: 0x002BC2CC
		private void BindEvents()
		{
			NetProcess.AddMsgHandler(501099U, new Action<MsgDATA>(this.OnReceiveSceneUnLockRoleStorageRes));
			NetProcess.AddMsgHandler(500911U, new Action<MsgDATA>(this.OnReceiveStoreItemRes));
			NetProcess.AddMsgHandler(500963U, new Action<MsgDATA>(this.OnReceiveSceneMoveItemRes));
		}

		// Token: 0x0600BC2F RID: 48175 RVA: 0x002BDF1C File Offset: 0x002BC31C
		private void UnBindEvents()
		{
			NetProcess.RemoveMsgHandler(501099U, new Action<MsgDATA>(this.OnReceiveSceneUnLockRoleStorageRes));
			NetProcess.RemoveMsgHandler(500911U, new Action<MsgDATA>(this.OnReceiveStoreItemRes));
			NetProcess.RemoveMsgHandler(500963U, new Action<MsgDATA>(this.OnReceiveSceneMoveItemRes));
		}

		// Token: 0x0600BC30 RID: 48176 RVA: 0x002BDF6C File Offset: 0x002BC36C
		public void OnSendStoreItemReq(ItemData item, int count)
		{
			if (item == null)
			{
				return;
			}
			if (count <= 0)
			{
				return;
			}
			bool flag = false;
			StorageType currentStorageType = this.CurrentStorageType;
			EPackageType epackageType = EPackageType.Storage;
			if (currentStorageType == StorageType.RoleStorage)
			{
				epackageType = EPackageType.RoleStorage;
			}
			if (currentStorageType == StorageType.AccountStorage)
			{
				if (item.HasTransfered || item.BindAttr == ItemTable.eOwner.NOTBIND || item.BindAttr == ItemTable.eOwner.ACCBIND || (item.Packing && item.BindAttr == ItemTable.eOwner.ROLEBIND))
				{
					flag = true;
				}
			}
			else if (currentStorageType == StorageType.RoleStorage)
			{
				flag = true;
			}
			if (!flag)
			{
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.GetLimitNum != 0)
			{
				int storageItemCount = StorageUtility.GetStorageItemCount(item.TableID, epackageType);
				if (tableItem.GetLimitNum < storageItemCount + count)
				{
					SystemNotifyManager.SystemNotify(9104, string.Empty);
					return;
				}
			}
			if (currentStorageType == StorageType.AccountStorage)
			{
				ScenePushStorage scenePushStorage = new ScenePushStorage();
				scenePushStorage.uid = item.GUID;
				scenePushStorage.num = (ushort)count;
				scenePushStorage.storageType = (byte)epackageType;
				NetManager netManager = NetManager.Instance();
				if (netManager != null)
				{
					netManager.SendCommand<ScenePushStorage>(ServerType.GATE_SERVER, scenePushStorage);
				}
			}
			else
			{
				SceneMoveItem sceneMoveItem = new SceneMoveItem();
				sceneMoveItem.itemId = item.GUID;
				sceneMoveItem.num = (ushort)count;
				int roleStorageCurrentSelectedIndex = this.GetRoleStorageCurrentSelectedIndex();
				int num = (roleStorageCurrentSelectedIndex - 1) * 30;
				if (num < 0)
				{
					num = 0;
				}
				sceneMoveItem.targetPos = new ItemPos
				{
					type = (byte)epackageType,
					index = (uint)num
				};
				NetManager netManager2 = NetManager.Instance();
				if (netManager2 != null)
				{
					netManager2.SendCommand<SceneMoveItem>(ServerType.GATE_SERVER, sceneMoveItem);
				}
			}
		}

		// Token: 0x0600BC31 RID: 48177 RVA: 0x002BE118 File Offset: 0x002BC518
		private void OnReceiveStoreItemRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			ScenePushStorageRet scenePushStorageRet = new ScenePushStorageRet();
			scenePushStorageRet.decode(msgData.bytes);
			if (scenePushStorageRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)scenePushStorageRet.code, string.Empty);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemStoreSuccess, null, null, null, null);
		}

		// Token: 0x0600BC32 RID: 48178 RVA: 0x002BE170 File Offset: 0x002BC570
		private void OnReceiveSceneMoveItemRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneMoveItemRes sceneMoveItemRes = new SceneMoveItemRes();
			sceneMoveItemRes.decode(msgData.bytes);
			if (sceneMoveItemRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneMoveItemRes.code, string.Empty);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemStoreSuccess, null, null, null, null);
		}

		// Token: 0x0600BC33 RID: 48179 RVA: 0x002BE1C8 File Offset: 0x002BC5C8
		public void OnSendSceneUnlockRoleStorageReq()
		{
			SceneUnlockRoleStorageReq cmd = new SceneUnlockRoleStorageReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneUnlockRoleStorageReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600BC34 RID: 48180 RVA: 0x002BE1F8 File Offset: 0x002BC5F8
		private void OnReceiveSceneUnLockRoleStorageRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneUnlockRoleStorageRes sceneUnlockRoleStorageRes = new SceneUnlockRoleStorageRes();
			sceneUnlockRoleStorageRes.decode(msgData.bytes);
			if (sceneUnlockRoleStorageRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneUnlockRoleStorageRes.retCode, string.Empty);
				return;
			}
			uint curOpenNum = sceneUnlockRoleStorageRes.curOpenNum;
			DataManager<CountDataManager>.GetInstance().SetCountWithoutUiEvent("role_storage_open_num", curOpenNum);
			int roleStorageOwnerStorageNumber = this.GetRoleStorageOwnerStorageNumber();
			int num = roleStorageOwnerStorageNumber;
			string roleStorageDefaultNameByStorageIndex = StorageUtility.GetRoleStorageDefaultNameByStorageIndex(num);
			string msgContent = TR.Value("storage_unlock_name_format", roleStorageDefaultNameByStorageIndex);
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveRoleStorageUnlockMessage, roleStorageOwnerStorageNumber, num, null, null);
		}

		// Token: 0x0600BC35 RID: 48181 RVA: 0x002BE296 File Offset: 0x002BC696
		public void UpdateRoleStorageSetNameByRoleStorageIndex(int index, string name)
		{
			if (this._roleStorageSetNameDic == null)
			{
				this._roleStorageSetNameDic = new Dictionary<int, string>();
			}
			this._roleStorageSetNameDic[index] = name;
		}

		// Token: 0x0600BC36 RID: 48182 RVA: 0x002BE2BC File Offset: 0x002BC6BC
		public string GetRoleStorageSetNameByRoleStorageIndex(int index)
		{
			if (this._roleStorageSetNameDic == null || this._roleStorageSetNameDic.Count <= 0)
			{
				return string.Empty;
			}
			if (this._roleStorageSetNameDic.ContainsKey(index))
			{
				return this._roleStorageSetNameDic[index];
			}
			return string.Empty;
		}

		// Token: 0x0600BC37 RID: 48183 RVA: 0x002BE310 File Offset: 0x002BC710
		public int GetRoleStorageOwnerStorageNumber()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount("role_storage_open_num");
			this._roleStorageOwnerStorageNumber = count + 1;
			if (this._roleStorageOwnerStorageNumber <= 0)
			{
				return 1;
			}
			if (this._roleStorageOwnerStorageNumber >= 9)
			{
				return 9;
			}
			return this._roleStorageOwnerStorageNumber;
		}

		// Token: 0x0600BC38 RID: 48184 RVA: 0x002BE35A File Offset: 0x002BC75A
		public void SetRoleStorageCurrentSelectedIndex(int index)
		{
			this._roleStorageCurrentSelectedIndex = index;
		}

		// Token: 0x0600BC39 RID: 48185 RVA: 0x002BE363 File Offset: 0x002BC763
		public int GetRoleStorageCurrentSelectedIndex()
		{
			if (this._roleStorageCurrentSelectedIndex <= 0)
			{
				return 1;
			}
			return this._roleStorageCurrentSelectedIndex;
		}

		// Token: 0x040069D5 RID: 27093
		public StorageType CurrentStorageType;

		// Token: 0x040069D6 RID: 27094
		public const string RoleStorageUnLockNumberStr = "role_storage_open_num";

		// Token: 0x040069D7 RID: 27095
		private int _roleStorageOwnerStorageNumber;

		// Token: 0x040069D8 RID: 27096
		public const int RoleStorageTotalNumber = 9;

		// Token: 0x040069D9 RID: 27097
		public const int RoleStorageNameMaxNumber = 5;

		// Token: 0x040069DA RID: 27098
		public const int RoleStorageMaxGridInOnePage = 30;

		// Token: 0x040069DB RID: 27099
		private int _roleStorageCurrentSelectedIndex;

		// Token: 0x040069DC RID: 27100
		private Dictionary<int, string> _roleStorageSetNameDic = new Dictionary<int, string>();
	}
}
