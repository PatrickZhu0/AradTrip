using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020019BC RID: 6588
	internal class Pk3v3CrossTeamMainMenuFrame : ClientFrame
	{
		// Token: 0x0601019B RID: 65947 RVA: 0x0047A3D7 File Offset: 0x004787D7
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/Pk3v3CrossTeamMainMenu";
		}

		// Token: 0x0601019C RID: 65948 RVA: 0x0047A3DE File Offset: 0x004787DE
		protected override void _OnOpenFrame()
		{
			this._Initialize();
			this._BindUIEvent();
		}

		// Token: 0x0601019D RID: 65949 RVA: 0x0047A3EC File Offset: 0x004787EC
		protected override void _OnCloseFrame()
		{
			this._Clear();
		}

		// Token: 0x0601019E RID: 65950 RVA: 0x0047A3F4 File Offset: 0x004787F4
		private void _Clear()
		{
			this._UnBindUIEvent();
		}

		// Token: 0x0601019F RID: 65951 RVA: 0x0047A3FC File Offset: 0x004787FC
		private void _BindUIEvent()
		{
		}

		// Token: 0x060101A0 RID: 65952 RVA: 0x0047A3FE File Offset: 0x004787FE
		private void _UnBindUIEvent()
		{
		}

		// Token: 0x060101A1 RID: 65953 RVA: 0x0047A400 File Offset: 0x00478800
		private void SendCancelOnePersonMatchGameReq()
		{
			WorldMatchCancelReq cmd = new WorldMatchCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x060101A2 RID: 65954 RVA: 0x0047A424 File Offset: 0x00478824
		[UIEventHandle("Content/funcs/CreateTeam/Button")]
		private void _OnCreateTeamClicked()
		{
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo != null && (long)pkInfo.nCurPkCount >= (long)((ulong)Pk3v3CrossDataManager.MAX_PK_COUNT))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("挑战次数已达上限，操作失败", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.frameMgr.IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			DataManager<Pk3v3CrossDataManager>.GetInstance().SendCreateRoomReq(RoomType.ROOM_TYPE_THREE_SCORE_WAR);
		}

		// Token: 0x060101A3 RID: 65955 RVA: 0x0047A48A File Offset: 0x0047888A
		[UIEventHandle("Content/funcs/MyTeam/Button")]
		private void _OnMyTeamClicked()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossMyTeamFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060101A4 RID: 65956 RVA: 0x0047A49E File Offset: 0x0047889E
		[UIEventHandle("Content/funcs/TeamList/Button")]
		private void _OnTeamListClicked()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossTeamListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060101A5 RID: 65957 RVA: 0x0047A4B2 File Offset: 0x004788B2
		[UIEventHandle("TeamList")]
		private void _OnTeamListClicked1()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossTeamListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060101A6 RID: 65958 RVA: 0x0047A4C6 File Offset: 0x004788C6
		private void _Initialize()
		{
			this._SetupFuncBtns();
		}

		// Token: 0x060101A7 RID: 65959 RVA: 0x0047A4D0 File Offset: 0x004788D0
		private void _SetupFuncBtns()
		{
			bool flag = DataManager<TeamDataManager>.GetInstance().HasTeam();
			flag = false;
			Utility.FindGameObject(this.m_content, "funcs/CreateTeam", true).SetActive(!flag);
			Utility.FindGameObject(this.m_content, "funcs/MyTeam", true).SetActive(flag);
		}

		// Token: 0x060101A8 RID: 65960 RVA: 0x0047A51B File Offset: 0x0047891B
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060101A9 RID: 65961 RVA: 0x0047A51E File Offset: 0x0047891E
		protected override void _OnUpdate(float timeElapsed)
		{
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam())
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3CrossTeamMainMenuFrame>(null, false);
			}
		}

		// Token: 0x0400A281 RID: 41601
		[UIObject("Content")]
		private GameObject m_content;

		// Token: 0x020019BD RID: 6589
		private class TeamMainMenuData
		{
			// Token: 0x0400A282 RID: 41602
			public Vector2 uiPos;
		}
	}
}
