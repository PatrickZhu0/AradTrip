using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015F6 RID: 5622
	internal class GuildBattleResultFrame : ClientFrame
	{
		// Token: 0x0600DC56 RID: 56406 RVA: 0x0037A4E9 File Offset: 0x003788E9
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildBattleResult";
		}

		// Token: 0x0600DC57 RID: 56407 RVA: 0x0037A4F0 File Offset: 0x003788F0
		protected override void _OnOpenFrame()
		{
			this._InitUI();
			this._RegisterUIEvent();
		}

		// Token: 0x0600DC58 RID: 56408 RVA: 0x0037A4FE File Offset: 0x003788FE
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DC59 RID: 56409 RVA: 0x0037A50C File Offset: 0x0037890C
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0600DC5A RID: 56410 RVA: 0x0037A50E File Offset: 0x0037890E
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600DC5B RID: 56411 RVA: 0x0037A510 File Offset: 0x00378910
		private void _InitUI()
		{
			this.m_objTemplate.SetActive(false);
			GuildBattleEndInfo[] array = this.userData as GuildBattleEndInfo[];
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.m_objTemplate);
					gameObject.transform.SetParent(this.m_objRoot.transform, false);
					gameObject.SetActive(true);
					GuildBattleEndInfo guildBattleEndInfo = array[i];
					Utility.GetComponetInChild<Text>(gameObject, "Text0").text = guildBattleEndInfo.terrName;
					Utility.GetComponetInChild<Text>(gameObject, "Text1").text = ((!string.IsNullOrEmpty(guildBattleEndInfo.guildName)) ? guildBattleEndInfo.guildName : "-");
					Utility.GetComponetInChild<Text>(gameObject, "Text2").text = ((!string.IsNullOrEmpty(guildBattleEndInfo.guildLeaderName)) ? guildBattleEndInfo.guildLeaderName : "-");
				}
			}
		}

		// Token: 0x0600DC5C RID: 56412 RVA: 0x0037A5F3 File Offset: 0x003789F3
		private void _ClearUI()
		{
		}

		// Token: 0x0600DC5D RID: 56413 RVA: 0x0037A5F5 File Offset: 0x003789F5
		[UIEventHandle("Content/Close")]
		private void _OnCloseClicked()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<GuildBattleResultFrame>(this, false);
		}

		// Token: 0x0600DC5E RID: 56414 RVA: 0x0037A603 File Offset: 0x00378A03
		[UIEventHandle("Content/JumpToMail")]
		private void _OnJumpToMailClicked()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<MailNewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x04008203 RID: 33283
		[UIObject("Content/ScrollView/Viewport/Content/Template")]
		private GameObject m_objTemplate;

		// Token: 0x04008204 RID: 33284
		[UIObject("Content/ScrollView/Viewport/Content")]
		private GameObject m_objRoot;
	}
}
