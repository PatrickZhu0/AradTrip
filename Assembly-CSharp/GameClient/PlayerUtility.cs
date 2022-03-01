using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020012C9 RID: 4809
	public static class PlayerUtility
	{
		// Token: 0x0600BA55 RID: 47701 RVA: 0x002AFF98 File Offset: 0x002AE398
		public static void LoadPetAvatarRenderEx(int petId, GeAvatarRendererEx geAvatarRenderEx, bool isShowFootSite = true)
		{
			if (geAvatarRenderEx == null)
			{
				Logger.LogError("geAvatarRenderEx is null");
				return;
			}
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>(petId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find PetTable with id:{0}", new object[]
				{
					petId
				});
				return;
			}
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.ModeID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				Logger.LogErrorFormat("can not find ResTable with id:{0}", new object[]
				{
					tableItem.ModeID
				});
				return;
			}
			geAvatarRenderEx.ClearAvatar();
			geAvatarRenderEx.LoadAvatar(tableItem2.ModelPath, -1);
			Vector3 avatarPos = geAvatarRenderEx.avatarPos;
			geAvatarRenderEx.ChangeAction("Anim_Idle01", 1f, true);
			if (isShowFootSite)
			{
				geAvatarRenderEx.CreateEffect("Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", 999999f, avatarPos, 1f, 1f, false, false);
			}
		}

		// Token: 0x0600BA56 RID: 47702 RVA: 0x002B0084 File Offset: 0x002AE484
		public static void LoadPlayerAvatarByPlayerAvatar(GeAvatarRendererEx geAvatarRenderEx, int professionId, PlayerAvatar playerAvatar)
		{
			if (geAvatarRenderEx == null)
			{
				Logger.LogErrorFormat("HeroAvatarRenderer is null", new object[0]);
				return;
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(professionId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("Cannot find JobItem and JobId is {0}", new object[]
				{
					professionId
				});
				return;
			}
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				Logger.LogErrorFormat("Cannot find ResItem with id : {0} ", new object[]
				{
					tableItem.Mode
				});
				return;
			}
			geAvatarRenderEx.ClearAvatar();
			geAvatarRenderEx.LoadAvatar(tableItem2.ModelPath, -1);
			uint[] equipItemIds = new uint[0];
			int weaponStrength = 0;
			byte isShowFashionWeapon = 0;
			if (playerAvatar != null)
			{
				equipItemIds = playerAvatar.equipItemIds;
				weaponStrength = (int)playerAvatar.weaponStrengthen;
				isShowFashionWeapon = playerAvatar.isShoWeapon;
			}
			DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(geAvatarRenderEx, equipItemIds, professionId, weaponStrength, null, false, isShowFashionWeapon, false);
			geAvatarRenderEx.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
			geAvatarRenderEx.SuitAvatar(true, false);
			geAvatarRenderEx.ChangeAction("Anim_Show_Idle", 1f, true);
		}

		// Token: 0x0600BA57 RID: 47703 RVA: 0x002B01AC File Offset: 0x002AE5AC
		public static void LoadPlayerAvatarByProfessionId(GeAvatarRendererEx geAvatarRenderEx, int professionId)
		{
			if (geAvatarRenderEx == null)
			{
				Logger.LogErrorFormat("HeroAvatarRenderer is null", new object[0]);
				return;
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(professionId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("Cannot find JobItem and JobId is {0}", new object[]
				{
					professionId
				});
				return;
			}
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				Logger.LogErrorFormat("Cannot find ResItem with id : {0} ", new object[]
				{
					tableItem.Mode
				});
				return;
			}
			geAvatarRenderEx.ClearAvatar();
			geAvatarRenderEx.LoadAvatar(tableItem2.ModelPath, -1);
			geAvatarRenderEx.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
			geAvatarRenderEx.SuitAvatar(true, false);
			geAvatarRenderEx.ChangeAction("Anim_Show_Idle", 1f, true);
		}

		// Token: 0x0600BA58 RID: 47704 RVA: 0x002B0298 File Offset: 0x002AE698
		public static void LoadPlayerAvatarBySelfPlayer(GeAvatarRendererEx geAvatarRenderEx)
		{
			if (geAvatarRenderEx == null)
			{
				return;
			}
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			geAvatarRenderEx.ClearAvatar();
			geAvatarRenderEx.LoadAvatar(tableItem2.ModelPath, -1);
			DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(geAvatarRenderEx, null, false);
			geAvatarRenderEx.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
			geAvatarRenderEx.SuitAvatar(true, false);
		}

		// Token: 0x0600BA59 RID: 47705 RVA: 0x002B0344 File Offset: 0x002AE744
		public static string GetPlayerProfessionHeadIconPath(int professionId)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(professionId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return null;
			}
			return tableItem2.IconPath;
		}

		// Token: 0x0600BA5A RID: 47706 RVA: 0x002B0398 File Offset: 0x002AE798
		public static string GetPlayerProfessionName(int professionId)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(professionId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			return tableItem.Name;
		}

		// Token: 0x0600BA5B RID: 47707 RVA: 0x002B03CC File Offset: 0x002AE7CC
		public static List<int> GetItemTableSuitMixProfessionIdList(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return null;
			}
			if (itemTable.Occu == null)
			{
				return null;
			}
			List<int> list = itemTable.Occu.ToList<int>();
			if (list == null || list.Count <= 0)
			{
				return null;
			}
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			int selfBaseJobId = CommonUtility.GetSelfBaseJobId();
			List<int> list2 = new List<int>();
			list2.Add(jobTableID);
			for (int i = 0; i < list.Count; i++)
			{
				int num = list[i];
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(num, string.Empty, string.Empty);
				if (tableItem != null)
				{
					int num2 = num;
					if (tableItem.JobType == 1)
					{
						num2 = tableItem.prejob;
					}
					if (num2 > 0)
					{
						if (num2 != jobTableID && num2 != selfBaseJobId)
						{
							if (!list2.Contains(num2))
							{
								list2.Add(num2);
							}
						}
					}
				}
			}
			return list2;
		}

		// Token: 0x0600BA5C RID: 47708 RVA: 0x002B04C8 File Offset: 0x002AE8C8
		public static List<int> GetItemTableSuitBaseProfessionIdList(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return null;
			}
			if (itemTable.Occu == null)
			{
				return null;
			}
			List<int> list = itemTable.Occu.ToList<int>();
			if (list == null || list.Count <= 0)
			{
				return null;
			}
			List<int> list2 = new List<int>();
			for (int i = 0; i < list.Count; i++)
			{
				int num = list[i];
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(num, string.Empty, string.Empty);
				if (tableItem != null)
				{
					int num2 = num;
					if (tableItem.JobType == 1)
					{
						num2 = tableItem.prejob;
					}
					if (num2 > 0)
					{
						if (!list2.Contains(num2))
						{
							list2.Add(num2);
						}
					}
				}
			}
			return list2;
		}

		// Token: 0x0600BA5D RID: 47709 RVA: 0x002B0590 File Offset: 0x002AE990
		public static int GetMaxLevelInAccount()
		{
			ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
			RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
			if (roleinfo != null)
			{
				foreach (RoleInfo roleInfo in roleinfo)
				{
					if (roleInfo != null)
					{
						if (roleInfo.level > level)
						{
							level = roleInfo.level;
						}
					}
				}
			}
			return (int)level;
		}

		// Token: 0x0600BA5E RID: 47710 RVA: 0x002B05F0 File Offset: 0x002AE9F0
		public static ExpTable GetExpTableByMaxLevelInAccount()
		{
			int maxLevelInAccount = PlayerUtility.GetMaxLevelInAccount();
			return Singleton<TableManager>.GetInstance().GetTableItem<ExpTable>(maxLevelInAccount, string.Empty, string.Empty);
		}

		// Token: 0x0600BA5F RID: 47711 RVA: 0x002B061C File Offset: 0x002AEA1C
		public static int GetVipPrivilegeValue(VipPrivilegeTable.eType type)
		{
			VipPrivilegeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<VipPrivilegeTable>((int)type, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			int vipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel;
			if (vipLevel == 0)
			{
				return tableItem.VIP0;
			}
			if (vipLevel == 1)
			{
				return tableItem.VIP1;
			}
			if (vipLevel == 2)
			{
				return tableItem.VIP2;
			}
			if (vipLevel == 3)
			{
				return tableItem.VIP3;
			}
			if (vipLevel == 4)
			{
				return tableItem.VIP4;
			}
			if (vipLevel == 5)
			{
				return tableItem.VIP5;
			}
			if (vipLevel == 6)
			{
				return tableItem.VIP6;
			}
			if (vipLevel == 7)
			{
				return tableItem.VIP7;
			}
			if (vipLevel == 8)
			{
				return tableItem.VIP8;
			}
			if (vipLevel == 9)
			{
				return tableItem.VIP9;
			}
			if (vipLevel == 10)
			{
				return tableItem.VIP10;
			}
			if (vipLevel == 11)
			{
				return tableItem.VIP11;
			}
			return tableItem.VIP0;
		}

		// Token: 0x0600BA60 RID: 47712 RVA: 0x002B0704 File Offset: 0x002AEB04
		public static int GetPreferenceCountInAccount()
		{
			int num = 0;
			if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.roleinfo != null)
			{
				for (int i = 0; i < ClientApplication.playerinfo.roleinfo.Length; i++)
				{
					RoleInfo roleInfo = ClientApplication.playerinfo.roleinfo[i];
					if (roleInfo != null)
					{
						if (roleInfo.addPreferencesTime > 0U)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600BA61 RID: 47713 RVA: 0x002B0778 File Offset: 0x002AEB78
		public static void SortRoleInfoList()
		{
			if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.roleinfo != null)
			{
				List<RoleInfo> list = new List<RoleInfo>();
				List<RoleInfo> list2 = new List<RoleInfo>();
				List<RoleInfo> list3 = new List<RoleInfo>();
				for (int i = 0; i < ClientApplication.playerinfo.roleinfo.Length; i++)
				{
					RoleInfo roleInfo = ClientApplication.playerinfo.roleinfo[i];
					if (roleInfo != null)
					{
						if (roleInfo.addPreferencesTime > 0U)
						{
							list.Add(roleInfo);
						}
						else if (roleInfo.delPreferencesTime > 0U)
						{
							list2.Add(roleInfo);
						}
						else
						{
							list3.Add(roleInfo);
						}
					}
				}
				list.Sort((RoleInfo x, RoleInfo y) => x.addPreferencesTime.CompareTo(y.addPreferencesTime));
				list2.Sort((RoleInfo x, RoleInfo y) => y.delPreferencesTime.CompareTo(x.delPreferencesTime));
				List<RoleInfo> list4 = new List<RoleInfo>();
				list4.AddRange(list);
				list4.AddRange(list2);
				list4.AddRange(list3);
				ClientApplication.playerinfo.roleinfo = new RoleInfo[list4.Count];
				for (int j = 0; j < list4.Count; j++)
				{
					RoleInfo roleInfo2 = list4[j];
					if (roleInfo2 != null)
					{
						ClientApplication.playerinfo.roleinfo[j] = roleInfo2;
					}
				}
			}
		}

		// Token: 0x0600BA62 RID: 47714 RVA: 0x002B08E0 File Offset: 0x002AECE0
		public static int GetFullLevelRoleCount()
		{
			int num = 0;
			int playerMaxLevel = Utility.GetPlayerMaxLevel();
			if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.roleinfo != null)
			{
				for (int i = 0; i < ClientApplication.playerinfo.roleinfo.Length; i++)
				{
					RoleInfo roleInfo = ClientApplication.playerinfo.roleinfo[i];
					if (roleInfo != null)
					{
						if ((int)roleInfo.level >= playerMaxLevel)
						{
							num++;
						}
					}
				}
			}
			return num;
		}
	}
}
