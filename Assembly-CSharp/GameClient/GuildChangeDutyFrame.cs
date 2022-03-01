using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001601 RID: 5633
	internal class GuildChangeDutyFrame : ClientFrame
	{
		// Token: 0x0600DCB6 RID: 56502 RVA: 0x0037C6A6 File Offset: 0x0037AAA6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildChangeDuty";
		}

		// Token: 0x0600DCB7 RID: 56503 RVA: 0x0037C6B0 File Offset: 0x0037AAB0
		protected override void _OnOpenFrame()
		{
			this.m_changeData = (GuildChangeDutyData)this.userData;
			if (this.m_changeData == null)
			{
				Logger.LogErrorFormat("open guild change duty frame, need userData", new object[0]);
				return;
			}
			this.m_uSelectMemberID = 0UL;
			this.m_objMemberTemplate.SetActive(false);
			List<GuildMemberData> membersByDuty = DataManager<GuildDataManager>.GetInstance().GetMembersByDuty(this.m_changeData.eDuty);
			for (int i = 0; i < membersByDuty.Count; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.m_objMemberTemplate);
				gameObject.transform.SetParent(this.m_objMemberRoot.transform, false);
				gameObject.SetActive(true);
				Utility.GetComponetInChild<Text>(gameObject, "Name/Text").text = membersByDuty[i].strName;
				Utility.GetComponetInChild<Text>(gameObject, "Duty/Text").text = TR.Value(membersByDuty[i].eGuildDuty.GetDescription(true));
				Toggle componetInChild = Utility.GetComponetInChild<Toggle>(gameObject, "Oper/Check");
				ulong id = membersByDuty[i].uGUID;
				if (i == 0)
				{
					componetInChild.isOn = true;
					this.m_uSelectMemberID = id;
				}
				else
				{
					componetInChild.isOn = false;
				}
				componetInChild.onValueChanged.RemoveAllListeners();
				componetInChild.onValueChanged.AddListener(delegate(bool a_bChecked)
				{
					if (a_bChecked)
					{
						this.m_uSelectMemberID = id;
					}
				});
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
		}

		// Token: 0x0600DCB8 RID: 56504 RVA: 0x0037C82F File Offset: 0x0037AC2F
		protected override void _OnCloseFrame()
		{
			this.m_uSelectMemberID = 0UL;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
		}

		// Token: 0x0600DCB9 RID: 56505 RVA: 0x0037C854 File Offset: 0x0037AC54
		private void _OnGuildDismissed(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildChangeDutyFrame>(this, false);
		}

		// Token: 0x0600DCBA RID: 56506 RVA: 0x0037C864 File Offset: 0x0037AC64
		[UIEventHandle("Ok")]
		private void _OnOkClicked()
		{
			if (this.m_uSelectMemberID > 0UL)
			{
				DataManager<GuildDataManager>.GetInstance().ChangeMemberDuty(this.m_changeData.uMemberGUID, this.m_changeData.eDuty, this.m_uSelectMemberID);
				this.frameMgr.CloseFrame<GuildChangeDutyFrame>(this, false);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_replace_duty_need_select_one"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600DCBB RID: 56507 RVA: 0x0037C8C6 File Offset: 0x0037ACC6
		[UIEventHandle("Cancel")]
		private void _OnCancelClicked()
		{
			this.frameMgr.CloseFrame<GuildChangeDutyFrame>(this, false);
		}

		// Token: 0x0400823D RID: 33341
		[UIObject("Content/List/Viewport/Content")]
		private GameObject m_objMemberRoot;

		// Token: 0x0400823E RID: 33342
		[UIObject("Content/List/Viewport/Content/Template")]
		private GameObject m_objMemberTemplate;

		// Token: 0x0400823F RID: 33343
		private ulong m_uSelectMemberID;

		// Token: 0x04008240 RID: 33344
		private GuildChangeDutyData m_changeData;
	}
}
