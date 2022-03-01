using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200116F RID: 4463
	internal class RoleRecoveryFrame : ClientFrame
	{
		// Token: 0x0600AAA5 RID: 43685 RVA: 0x0024757B File Offset: 0x0024597B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SelecteRoleNew/RoleRecoveryFrame";
		}

		// Token: 0x0600AAA6 RID: 43686 RVA: 0x00247582 File Offset: 0x00245982
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleRecoveryUpdate, new ClientEventSystem.UIEventHandler(this._OnRecoveryUpdate));
			this._UpdateRecoveryRoles();
		}

		// Token: 0x0600AAA7 RID: 43687 RVA: 0x002475A8 File Offset: 0x002459A8
		private void _UpdateRecoveryRoles()
		{
			GameObject gameObject = Utility.FindChild(this.frame, "Dlg/ScrollView/Viewport/Content");
			GameObject gameObject2 = Utility.FindChild(gameObject, "RecoveryRoleInfo");
			gameObject2.CustomActive(false);
			this.m_akRolesRecovery.RecycleAllObject();
			RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
			for (int i = 0; i < roleinfo.Length; i++)
			{
				if (RecoveryRoleCachedObject.OnFilter(roleinfo[i]))
				{
					this.m_akRolesRecovery.Create(new object[]
					{
						gameObject,
						gameObject2,
						new RoleData
						{
							roleInfo = roleinfo[i]
						},
						false
					});
				}
			}
		}

		// Token: 0x0600AAA8 RID: 43688 RVA: 0x00247649 File Offset: 0x00245A49
		private void _OnRecoveryUpdate(UIEvent uiEvent)
		{
			this.frameMgr.CloseFrame<RoleRecoveryFrame>(this, false);
		}

		// Token: 0x0600AAA9 RID: 43689 RVA: 0x00247658 File Offset: 0x00245A58
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleRecoveryUpdate, new ClientEventSystem.UIEventHandler(this._OnRecoveryUpdate));
			this.m_akRolesRecovery.DestroyAllObjects();
		}

		// Token: 0x0600AAAA RID: 43690 RVA: 0x00247680 File Offset: 0x00245A80
		[UIEventHandle("Dlg/Close")]
		private void OnClickOk()
		{
			this.frameMgr.CloseFrame<RoleRecoveryFrame>(this, true);
		}

		// Token: 0x04005FA7 RID: 24487
		private CachedObjectListManager<RecoveryRoleCachedObject> m_akRolesRecovery = new CachedObjectListManager<RecoveryRoleCachedObject>();
	}
}
