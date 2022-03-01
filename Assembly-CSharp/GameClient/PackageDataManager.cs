using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012BA RID: 4794
	public class PackageDataManager : DataManager<PackageDataManager>
	{
		// Token: 0x17001B4D RID: 6989
		// (get) Token: 0x0600B909 RID: 47369 RVA: 0x002A643E File Offset: 0x002A483E
		// (set) Token: 0x0600B90A RID: 47370 RVA: 0x002A6446 File Offset: 0x002A4846
		public bool AlreadyUseTotalMagicBox { get; set; }

		// Token: 0x17001B4E RID: 6990
		// (get) Token: 0x0600B90B RID: 47371 RVA: 0x002A644F File Offset: 0x002A484F
		// (set) Token: 0x0600B90C RID: 47372 RVA: 0x002A6457 File Offset: 0x002A4857
		public bool AlreadyUseTotalMagicHammer { get; set; }

		// Token: 0x0600B90D RID: 47373 RVA: 0x002A6460 File Offset: 0x002A4860
		public override void Initialize()
		{
			this.BindUiEvents();
			this.BindNetEvents();
		}

		// Token: 0x0600B90E RID: 47374 RVA: 0x002A646E File Offset: 0x002A486E
		public override void Clear()
		{
			this.UnBindUiEvents();
			this.UnBindNetEvents();
		}

		// Token: 0x0600B90F RID: 47375 RVA: 0x002A647C File Offset: 0x002A487C
		private void BindUiEvents()
		{
		}

		// Token: 0x0600B910 RID: 47376 RVA: 0x002A647E File Offset: 0x002A487E
		private void UnBindUiEvents()
		{
		}

		// Token: 0x0600B911 RID: 47377 RVA: 0x002A6480 File Offset: 0x002A4880
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(501028U, new Action<MsgDATA>(this.OnShowFashionWeaponRes));
			NetProcess.AddMsgHandler(500632U, new Action<MsgDATA>(this.OnSceneNotifyIncExp));
		}

		// Token: 0x0600B912 RID: 47378 RVA: 0x002A64AE File Offset: 0x002A48AE
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(501028U, new Action<MsgDATA>(this.OnShowFashionWeaponRes));
			NetProcess.RemoveMsgHandler(500632U, new Action<MsgDATA>(this.OnSceneNotifyIncExp));
		}

		// Token: 0x0600B913 RID: 47379 RVA: 0x002A64DC File Offset: 0x002A48DC
		public bool IsPackageTabShowRedPoint(EPackageType ePackageType)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(ePackageType);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ulong id = itemsByPackageType[i];
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
				if (item != null && this.IsItemShowRedPoint(item))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B914 RID: 47380 RVA: 0x002A6538 File Offset: 0x002A4938
		public bool IsItemShowRedPoint(ItemData itemData)
		{
			if (itemData == null)
			{
				return false;
			}
			if (!this.IsTearOfGodItem(itemData))
			{
				return false;
			}
			ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
			return (int)level >= itemData.LevelLimit && (int)level <= itemData.MaxLevelLimit;
		}

		// Token: 0x0600B915 RID: 47381 RVA: 0x002A6584 File Offset: 0x002A4984
		private void OnSceneNotifyIncExp(MsgDATA msg)
		{
			SceneNotifyIncExp sceneNotifyIncExp = new SceneNotifyIncExp();
			sceneNotifyIncExp.decode(msg.bytes);
			ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
			ulong expByLevel = Singleton<TableManager>.GetInstance().GetExpByLevel((int)level);
			ulong curExp = DataManager<PlayerBaseData>.GetInstance().CurExp;
			float num = 0f;
			if (sceneNotifyIncExp.reason == 1)
			{
				num = sceneNotifyIncExp.value;
			}
			else if (sceneNotifyIncExp.reason == 2)
			{
				float num2 = sceneNotifyIncExp.value / 100f;
				num = num2 * expByLevel;
			}
			if (num + curExp >= expByLevel)
			{
				return;
			}
			ExpUpgradeData userData = new ExpUpgradeData
			{
				reason = (PlayerIncExpReason)sceneNotifyIncExp.reason,
				CurExpValue = curExp,
				MaxExpValue = expByLevel,
				AddExpValue = (ulong)num
			};
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ExpUpgradeFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ExpUpgradeFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ExpUpgradeFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600B916 RID: 47382 RVA: 0x002A667C File Offset: 0x002A4A7C
		public void OnItemUsedSucceed(UIEvent ui)
		{
			if (ui == null)
			{
				return;
			}
			ItemData itemData = ui.Param1 as ItemData;
			if (itemData == null)
			{
				return;
			}
			if (!this.IsTearOfGodItem(itemData))
			{
				return;
			}
			string description = itemData.Description;
			ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
			ulong expByLevel = Singleton<TableManager>.GetInstance().GetExpByLevel((int)level);
			ulong curExp = DataManager<PlayerBaseData>.GetInstance().CurExp;
			int num = description.IndexOf(this._levelStr);
			int num2 = description.IndexOf(this._percentStr);
			if (num == -1 || num2 == -1)
			{
				Logger.LogErrorFormat("ItemData tableID is {0} and description is not valid {1}", new object[]
				{
					itemData.TableID,
					itemData.Description
				});
				return;
			}
			int length = num2 - (num + 3);
			string text = description.Substring(num + 4, length);
			if (!this.IsPercentStr(text))
			{
				return;
			}
			double num3 = Convert.ToDouble(text.TrimEnd(new char[]
			{
				'%'
			})) / 100.0;
			float num4 = (float)num3 * expByLevel;
			if (num4 + curExp >= expByLevel)
			{
				return;
			}
			ExpUpgradeData userData = new ExpUpgradeData
			{
				CurExpValue = curExp,
				MaxExpValue = expByLevel,
				AddExpValue = (ulong)num4
			};
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ExpUpgradeFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ExpUpgradeFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ExpUpgradeFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600B917 RID: 47383 RVA: 0x002A67EE File Offset: 0x002A4BEE
		private bool IsTearOfGodItem(ItemData itemData)
		{
			return itemData != null && itemData.SubType == 41 && itemData.ThirdType == ItemTable.eThirdType.GoddessTear;
		}

		// Token: 0x0600B918 RID: 47384 RVA: 0x002A681A File Offset: 0x002A4C1A
		public void UsingMagicBoxAndMagicHammer()
		{
			this.AlreadyUseTotalMagicBox = true;
			this.AlreadyUseTotalMagicHammer = true;
		}

		// Token: 0x0600B919 RID: 47385 RVA: 0x002A682A File Offset: 0x002A4C2A
		public void ResetMagicBoxAndMagicHammer()
		{
			if (this.AlreadyUseTotalMagicBox)
			{
				this.AlreadyUseTotalMagicBox = false;
			}
			if (this.AlreadyUseTotalMagicHammer)
			{
				this.AlreadyUseTotalMagicHammer = false;
			}
		}

		// Token: 0x0600B91A RID: 47386 RVA: 0x002A6850 File Offset: 0x002A4C50
		private bool IsPercentStr(string percentStr)
		{
			if (percentStr == null)
			{
				return false;
			}
			int length = percentStr.Length;
			if (length <= 1)
			{
				return false;
			}
			if (percentStr[length - 1] != '%')
			{
				return false;
			}
			for (int i = 0; i < length - 1; i++)
			{
				if (percentStr[i] < '0' || percentStr[i] > '9')
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600B91B RID: 47387 RVA: 0x002A68BA File Offset: 0x002A4CBA
		public void ResetSendFashionWeaponReqFlag()
		{
			this._isSendingShowFashionWeapon = false;
		}

		// Token: 0x0600B91C RID: 47388 RVA: 0x002A68C4 File Offset: 0x002A4CC4
		public void SendShowFashionWeaponReq(bool setFashionWeaponFlag)
		{
			if (this._isSendingShowFashionWeapon)
			{
				return;
			}
			this._isSendingShowFashionWeapon = true;
			SceneSetFashionWeaponShowReq sceneSetFashionWeaponShowReq = new SceneSetFashionWeaponShowReq();
			if (setFashionWeaponFlag)
			{
				sceneSetFashionWeaponShowReq.isShow = 1;
			}
			else
			{
				sceneSetFashionWeaponShowReq.isShow = 0;
			}
			if (NetManager.Instance() != null)
			{
				NetManager.Instance().SendCommand<SceneSetFashionWeaponShowReq>(ServerType.GATE_SERVER, sceneSetFashionWeaponShowReq);
			}
		}

		// Token: 0x0600B91D RID: 47389 RVA: 0x002A6920 File Offset: 0x002A4D20
		private void OnShowFashionWeaponRes(MsgDATA data)
		{
			SceneSetFashionWeaponShowRes sceneSetFashionWeaponShowRes = new SceneSetFashionWeaponShowRes();
			sceneSetFashionWeaponShowRes.decode(data.bytes);
			this._isSendingShowFashionWeapon = false;
			if (sceneSetFashionWeaponShowRes.ret != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneSetFashionWeaponShowRes.ret, string.Empty);
				return;
			}
		}

		// Token: 0x0600B91E RID: 47390 RVA: 0x002A6964 File Offset: 0x002A4D64
		public bool IsEquipedFashionWeapon(uint[] equipedItemIds)
		{
			if (equipedItemIds == null || equipedItemIds.Length <= 0)
			{
				return false;
			}
			foreach (int num in equipedItemIds)
			{
				if (num > 0)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
					if (tableItem != null && tableItem.SubType == ItemTable.eSubType.FASHION_WEAPON)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600B91F RID: 47391 RVA: 0x002A69D4 File Offset: 0x002A4DD4
		public bool IsPlayerAvatarNeedChanged(PlayerAvatar curAvatar, PlayerAvatar changeAvatar)
		{
			if (curAvatar == null)
			{
				return changeAvatar != null;
			}
			if (changeAvatar == null)
			{
				return true;
			}
			if (curAvatar.weaponStrengthen != changeAvatar.weaponStrengthen)
			{
				return true;
			}
			if (curAvatar.equipItemIds == null)
			{
				return changeAvatar.equipItemIds != null;
			}
			if (changeAvatar.equipItemIds == null)
			{
				return true;
			}
			int num = curAvatar.equipItemIds.Length;
			int num2 = changeAvatar.equipItemIds.Length;
			if (num != num2)
			{
				return true;
			}
			List<uint> list = new List<uint>();
			for (int i = 0; i < num; i++)
			{
				list.Add(curAvatar.equipItemIds[i]);
			}
			list.Sort((uint x, uint y) => x.CompareTo(y));
			List<uint> list2 = new List<uint>();
			for (int j = 0; j < num2; j++)
			{
				list2.Add(changeAvatar.equipItemIds[j]);
			}
			list2.Sort((uint x, uint y) => x.CompareTo(y));
			int num3 = 0;
			while (num3 < num && num3 < num2)
			{
				if (list[num3] != list2[num3])
				{
					return true;
				}
				num3++;
			}
			if (curAvatar.isShoWeapon != changeAvatar.isShoWeapon)
			{
				if (changeAvatar.isShoWeapon == 1)
				{
					if (DataManager<PackageDataManager>.GetInstance().IsEquipedFashionWeapon(changeAvatar.equipItemIds))
					{
						return true;
					}
				}
				else if (changeAvatar.isShoWeapon == 0 && DataManager<PackageDataManager>.GetInstance().IsEquipedFashionWeapon(changeAvatar.equipItemIds))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B920 RID: 47392 RVA: 0x002A6B7A File Offset: 0x002A4F7A
		public EFashionWearSlotType GetFashionWearSlotTypeByItemFashionWearNewSlotType(EFashionWearNewSlotType fashionWearNewSlotType)
		{
			switch (fashionWearNewSlotType)
			{
			case EFashionWearNewSlotType.Head:
				return EFashionWearSlotType.Head;
			case EFashionWearNewSlotType.UpperBody:
				return EFashionWearSlotType.UpperBody;
			case EFashionWearNewSlotType.Chest:
				return EFashionWearSlotType.Chest;
			case EFashionWearNewSlotType.Waist:
				return EFashionWearSlotType.Waist;
			case EFashionWearNewSlotType.LowerBody:
				return EFashionWearSlotType.LowerBody;
			case EFashionWearNewSlotType.Weapon:
				return EFashionWearSlotType.Weapon;
			case EFashionWearNewSlotType.Halo:
				return EFashionWearSlotType.Halo;
			case EFashionWearNewSlotType.Auras:
				return EFashionWearSlotType.Auras;
			default:
				return EFashionWearSlotType.Invalid;
			}
		}

		// Token: 0x0600B921 RID: 47393 RVA: 0x002A6BBA File Offset: 0x002A4FBA
		public EFashionWearNewSlotType GetFashionWearNewSlotTypeByItemFashionWearSlotType(EFashionWearSlotType fashionWearSlotType)
		{
			switch (fashionWearSlotType)
			{
			case EFashionWearSlotType.Halo:
				return EFashionWearNewSlotType.Halo;
			case EFashionWearSlotType.Head:
				return EFashionWearNewSlotType.Head;
			case EFashionWearSlotType.Waist:
				return EFashionWearNewSlotType.Waist;
			case EFashionWearSlotType.UpperBody:
				return EFashionWearNewSlotType.UpperBody;
			case EFashionWearSlotType.LowerBody:
				return EFashionWearNewSlotType.LowerBody;
			case EFashionWearSlotType.Chest:
				return EFashionWearNewSlotType.Chest;
			case EFashionWearSlotType.Weapon:
				return EFashionWearNewSlotType.Weapon;
			case EFashionWearSlotType.Auras:
				return EFashionWearNewSlotType.Auras;
			default:
				return EFashionWearNewSlotType.Invalid;
			}
		}

		// Token: 0x04006837 RID: 26679
		private readonly string _levelStr = "当前等级";

		// Token: 0x04006838 RID: 26680
		private readonly string _percentStr = "%";

		// Token: 0x0400683B RID: 26683
		private bool _isSendingShowFashionWeapon;
	}
}
