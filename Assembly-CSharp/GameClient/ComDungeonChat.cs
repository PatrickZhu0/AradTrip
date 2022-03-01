using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000026 RID: 38
	public class ComDungeonChat : MonoBehaviour
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00009EC5 File Offset: 0x000082C5
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00009ECD File Offset: 0x000082CD
		private bool dirtyFlag
		{
			get
			{
				return this.mDirtyFlag;
			}
			set
			{
				if (this.mDirtyFlag != value)
				{
					this.mDirtyFlag = value;
					if (null != this.redPoint)
					{
						this.redPoint.SetActive(this.mDirtyFlag);
					}
				}
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00009F04 File Offset: 0x00008304
		private void Awake()
		{
			this._bindUIEvent();
			DataManager<BattleEasyChatDataManager>.GetInstance().SetReceiveNetMsg();
			if (null != this.onTeamChatButton)
			{
				this.onTeamChatButton.onClick.AddListener(new UnityAction(this._onClickChat));
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00009F43 File Offset: 0x00008343
		private void OnDestroy()
		{
			this._unBindUIEvent();
			DataManager<BattleEasyChatDataManager>.GetInstance().SetRejectNetMsg();
			if (null != this.onTeamChatButton)
			{
				this.onTeamChatButton.onClick.RemoveListener(new UnityAction(this._onClickChat));
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00009F82 File Offset: 0x00008382
		private void _bindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonChatInputFieldOpen, new ClientEventSystem.UIEventHandler(this._onInputFieldOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonChatInputFieldClose, new ClientEventSystem.UIEventHandler(this._onCloseFieldClose));
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00009FBA File Offset: 0x000083BA
		private void _unBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonChatInputFieldOpen, new ClientEventSystem.UIEventHandler(this._onInputFieldOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonChatInputFieldClose, new ClientEventSystem.UIEventHandler(this._onCloseFieldClose));
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00009FF2 File Offset: 0x000083F2
		private void _onUpdateRedPointState(UIEvent ui)
		{
			if (!Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonTeamChatFrame>(null))
			{
				this.dirtyFlag = true;
				Logger.LogError("设置红点");
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000A015 File Offset: 0x00008415
		private void _onInputFieldOpen(UIEvent ui)
		{
			this.isInputFieldOpen = true;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000A01E File Offset: 0x0000841E
		private void _onCloseFieldClose(UIEvent ui)
		{
			this.isInputFieldOpen = false;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000A028 File Offset: 0x00008428
		private void _onClickChat()
		{
			if (this.isInputFieldOpen)
			{
				return;
			}
			if (!Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonTeamChatFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<DungeonChatRecordFrame>(null, false);
				Singleton<ClientSystemManager>.instance.OpenFrame<DungeonTeamChatFrame>((BattleMain.battleType != BattleType.RaidPVE) ? FrameLayer.Middle : FrameLayer.HorseLamp, new object[]
				{
					BattleMain.battleType == BattleType.RaidPVE,
					this.dirtyFlag
				}, string.Empty);
				this._clearDirtyFlag();
			}
			else
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<DungeonTeamChatFrame>(null, false);
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000A0BC File Offset: 0x000084BC
		private void _clearDirtyFlag()
		{
			this.dirtyFlag = false;
		}

		// Token: 0x040000C8 RID: 200
		public GameObject redPoint;

		// Token: 0x040000C9 RID: 201
		public Button onTeamChatButton;

		// Token: 0x040000CA RID: 202
		private bool mDirtyFlag;

		// Token: 0x040000CB RID: 203
		private bool isInputFieldOpen;
	}
}
