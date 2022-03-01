using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001169 RID: 4457
	internal class RecoveryRoleCachedObject : CachedNormalObject<RoleData>
	{
		// Token: 0x17001A2A RID: 6698
		// (get) Token: 0x0600AA5B RID: 43611 RVA: 0x002453AE File Offset: 0x002437AE
		public static uint ms_max_life_time
		{
			get
			{
				return 604800U;
			}
		}

		// Token: 0x0600AA5C RID: 43612 RVA: 0x002453B5 File Offset: 0x002437B5
		public static bool OnFilterAlive(RoleInfo roleInfo)
		{
			return roleInfo != null && roleInfo.deleteTime == 0U;
		}

		// Token: 0x17001A2B RID: 6699
		// (get) Token: 0x0600AA5D RID: 43613 RVA: 0x002453D0 File Offset: 0x002437D0
		public static int HasOwnedRoles
		{
			get
			{
				int num = 0;
				if (ClientApplication.playerinfo != null)
				{
					RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
					for (int i = 0; i < roleinfo.Length; i++)
					{
						if (RecoveryRoleCachedObject.OnFilterAlive(roleinfo[i]))
						{
							num++;
						}
					}
				}
				return num;
			}
		}

		// Token: 0x17001A2C RID: 6700
		// (get) Token: 0x0600AA5E RID: 43614 RVA: 0x0024541C File Offset: 0x0024381C
		public static int EnabledRoleField
		{
			get
			{
				int result = 0;
				if (ClientApplication.playerinfo != null)
				{
					if (RecoveryRoleCachedObject.ms_max_roles_count != (int)ClientApplication.playerinfo.baseRoleFieldNum)
					{
						result = RecoveryRoleCachedObject.ms_max_roles_count + (int)ClientApplication.playerinfo.unLockedExtendRoleFieldNum;
					}
					else
					{
						result = (int)(ClientApplication.playerinfo.baseRoleFieldNum + ClientApplication.playerinfo.unLockedExtendRoleFieldNum);
					}
				}
				return result;
			}
		}

		// Token: 0x0600AA5F RID: 43615 RVA: 0x00245478 File Offset: 0x00243878
		public static bool OnFilter(RoleInfo roleInfo)
		{
			if (roleInfo != null)
			{
				uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
				return roleInfo.deleteTime != 0U && roleInfo.deleteTime <= serverTime && serverTime - roleInfo.deleteTime <= RecoveryRoleCachedObject.ms_max_life_time;
			}
			return false;
		}

		// Token: 0x0600AA60 RID: 43616 RVA: 0x002454C4 File Offset: 0x002438C4
		public override void Initialize()
		{
			this.comRoleConfig = this.goLocal.GetComponent<ComRecoveryRole>();
			this.comRoleConfig.button.onClick.AddListener(new UnityAction(this.OnClickRecoveryRole));
			ComRecoveryRole comRecoveryRole = this.comRoleConfig;
			comRecoveryRole.onTick = (ComRecoveryRole.OnTick)Delegate.Combine(comRecoveryRole.onTick, new ComRecoveryRole.OnTick(this.OnTick));
		}

		// Token: 0x0600AA61 RID: 43617 RVA: 0x0024552C File Offset: 0x0024392C
		public override void UnInitialize()
		{
			this.comRoleConfig.button.onClick.RemoveListener(new UnityAction(this.OnClickRecoveryRole));
			ComRecoveryRole comRecoveryRole = this.comRoleConfig;
			comRecoveryRole.onTick = (ComRecoveryRole.OnTick)Delegate.Remove(comRecoveryRole.onTick, new ComRecoveryRole.OnTick(this.OnTick));
			this.comRoleConfig = null;
		}

		// Token: 0x0600AA62 RID: 43618 RVA: 0x00245588 File Offset: 0x00243988
		public void _LoadJobHeadIcon(ref Image image)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)base.Value.roleInfo.occupation, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref image, tableItem2.IconPath, true);
		}

		// Token: 0x0600AA63 RID: 43619 RVA: 0x002455F4 File Offset: 0x002439F4
		public override void OnUpdate()
		{
			this._LoadJobHeadIcon(ref this.comRoleConfig.headIcon);
			this.comRoleConfig.LvInfo.text = "Lv." + base.Value.roleInfo.level;
			this.comRoleConfig.RoleName.text = base.Value.roleInfo.name;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)base.Value.roleInfo.occupation, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.comRoleConfig.JobName.text = tableItem.Name;
			}
		}

		// Token: 0x0600AA64 RID: 43620 RVA: 0x002456A4 File Offset: 0x00243AA4
		private void OnClickRecoveryRole()
		{
			int hasOwnedRoles = RecoveryRoleCachedObject.HasOwnedRoles;
			if (hasOwnedRoles >= RecoveryRoleCachedObject.EnabledRoleField)
			{
				SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("recovery_failed_roles_full"), hasOwnedRoles), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			GateRecoverRoleReq gateRecoverRoleReq = new GateRecoverRoleReq();
			gateRecoverRoleReq.roleId = base.Value.roleInfo.roleId;
			NetManager.Instance().SendCommand<GateRecoverRoleReq>(ServerType.GATE_SERVER, gateRecoverRoleReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<GateRecoverRoleRes>(delegate(GateRecoverRoleRes msgRet)
			{
				if (msgRet.result != 0U)
				{
					if (msgRet.result == 200021U)
					{
						SystemNotifyManager.SysNotifyTextAnimation(msgRet.roleUpdateLimit, CommonTipsDesc.eShowMode.SI_UNIQUE);
					}
					else
					{
						SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					}
				}
				else
				{
					RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
					for (int i = 0; i < roleinfo.Length; i++)
					{
						if (roleinfo[i].roleId == msgRet.roleId)
						{
							roleinfo[i].deleteTime = 0U;
							break;
						}
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RoleRecoveryUpdate, msgRet.roleId, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600AA65 RID: 43621 RVA: 0x00245738 File Offset: 0x00243B38
		private void OnTick()
		{
			if (this.goLocal.activeSelf)
			{
				uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
				uint num = (serverTime < base.Value.roleInfo.deleteTime) ? 0U : (serverTime - base.Value.roleInfo.deleteTime);
				if (num < RecoveryRoleCachedObject.ms_max_life_time)
				{
					num = RecoveryRoleCachedObject.ms_max_life_time - num;
				}
				else
				{
					num = 0U;
				}
				uint num2 = num / 86400U;
				uint num3 = num / 3600U % 24U;
				uint num4 = num / 60U % 60U;
				uint num5 = num % 60U;
				this.comRoleConfig.LifeTime.text = string.Format(RecoveryRoleCachedObject.formatTimeString, new object[]
				{
					num2,
					num3,
					num4,
					num5
				});
				this.comRoleConfig.grayRecovery.enabled = (num == 0U);
			}
		}

		// Token: 0x04005F76 RID: 24438
		private ComRecoveryRole comRoleConfig;

		// Token: 0x04005F77 RID: 24439
		public static int ms_max_roles_count = 8;

		// Token: 0x04005F78 RID: 24440
		public static string formatTimeString = "{0:D2}天{1:D2}时{2:D2}分{3:D2}秒";
	}
}
