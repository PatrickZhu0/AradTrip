using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010A5 RID: 4261
	public class DungeonChatRecordFrame : ClientFrame
	{
		// Token: 0x0600A0A9 RID: 41129 RVA: 0x00206B57 File Offset: 0x00204F57
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Chat/DungeonChatRecordFrame";
		}

		// Token: 0x0600A0AA RID: 41130 RVA: 0x00206B5E File Offset: 0x00204F5E
		protected override void _bindExUI()
		{
			this.mChatRecordList = this.mBind.GetCom<ComUIListScript>("chatRecordList");
			if (this.mChatRecordList != null)
			{
				this._InitChatRecordUIListScrollListBind();
			}
			this._bindUIEvent();
		}

		// Token: 0x0600A0AB RID: 41131 RVA: 0x00206B93 File Offset: 0x00204F93
		protected override void _unbindExUI()
		{
			this.mChatRecordList = null;
			this._unBindUIEvent();
		}

		// Token: 0x0600A0AC RID: 41132 RVA: 0x00206BA2 File Offset: 0x00204FA2
		private void _bindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonChatMsgDataUpdate, new ClientEventSystem.UIEventHandler(this._onReceiveChatDataMsg));
		}

		// Token: 0x0600A0AD RID: 41133 RVA: 0x00206BBF File Offset: 0x00204FBF
		private void _unBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonChatMsgDataUpdate, new ClientEventSystem.UIEventHandler(this._onReceiveChatDataMsg));
		}

		// Token: 0x0600A0AE RID: 41134 RVA: 0x00206BDC File Offset: 0x00204FDC
		protected override void _OnOpenFrame()
		{
			object[] array = this.userData as object[];
			if (array == null)
			{
				return;
			}
			ChatBlock chatBlock = array[0] as ChatBlock;
			if (chatBlock == null)
			{
				return;
			}
			bool flag = (bool)array[1];
			if (flag && DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType == ChatType.CT_TEAM)
			{
				DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType = ChatType.CT_TEAM_COPY_TEAM;
			}
			this.mChatDataList = new List<ChatBlock>();
			this.mChatDataList.Add(chatBlock);
			this.mChatRecordList.SetElementAmount(this.mChatDataList.Count, this.GetChatDataArraySize());
			if (this.mChatDataList.Count > 0)
			{
				this.mChatRecordList.EnsureElementVisable(this.mChatDataList.Count - 1);
			}
		}

		// Token: 0x0600A0AF RID: 41135 RVA: 0x00206C93 File Offset: 0x00205093
		protected override void _OnCloseFrame()
		{
			if (this.mChatDataList != null)
			{
				this.mChatDataList.Clear();
			}
			this.mChatDataList = null;
			this.timer = 0f;
		}

		// Token: 0x0600A0B0 RID: 41136 RVA: 0x00206CBD File Offset: 0x002050BD
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A0B1 RID: 41137 RVA: 0x00206CC0 File Offset: 0x002050C0
		protected override void _OnUpdate(float timeElapsed)
		{
			this.timer += timeElapsed;
			if (this.timer > 3f)
			{
				this.timer = 0f;
				base.Close(false);
			}
		}

		// Token: 0x0600A0B2 RID: 41138 RVA: 0x00206CF2 File Offset: 0x002050F2
		private void _InitChatRecordUIListScrollListBind()
		{
			this.mChatRecordList.Initialize();
			this.mChatRecordList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item != null && item.m_index >= 0)
				{
					ComCommonBind component = item.GetComponent<ComCommonBind>();
					if (component == null)
					{
						return;
					}
					LinkParse com = component.GetCom<LinkParse>("linkParse");
					Image com2 = component.GetCom<Image>("Index");
					if (com == null)
					{
						return;
					}
					ChatBlock chatBlockByIndex = this.GetChatBlockByIndex(item.m_index);
					if (chatBlockByIndex == null)
					{
						return;
					}
					try
					{
						if (chatBlockByIndex.chatData != null)
						{
							if (DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType == ChatType.CT_TEAM)
							{
								if (com2 != null)
								{
									com2.gameObject.SetActive(false);
								}
								com.SetText(string.Format("{0}{1}:{2}", chatBlockByIndex.chatData.GetChannelString(), chatBlockByIndex.chatData.objname, chatBlockByIndex.chatData.GetWords()), true);
							}
							else
							{
								int num = TeamDuplicationUtility.GetTeamDuplicationCaptainIdByPlayerGuid(chatBlockByIndex.chatData.objid) - 1;
								if (com2 != null)
								{
									com2.gameObject.SetActive(true);
									if (num >= 0 && num < DungeonChatRecordFrame.INDEX_PATH_ARRAY.Length)
									{
										ETCImageLoader.LoadSprite(ref com2, DungeonChatRecordFrame.INDEX_PATH_ARRAY[num], true);
									}
								}
								com.SetText(string.Format("<color=#00000000>XX</color>{0}{1}:{2}", chatBlockByIndex.chatData.GetChannelString(), chatBlockByIndex.chatData.objname, chatBlockByIndex.chatData.GetWords()), true);
							}
						}
					}
					catch (Exception ex)
					{
						Logger.LogError(ex.ToString());
					}
				}
			};
		}

		// Token: 0x0600A0B3 RID: 41139 RVA: 0x00206D18 File Offset: 0x00205118
		private void _onReceiveChatDataMsg(UIEvent ui)
		{
			ChatBlock chatBlock = ui.Param1 as ChatBlock;
			if (chatBlock == null || this.mChatDataList == null)
			{
				return;
			}
			this.mChatDataList.Add(chatBlock);
			this.mChatRecordList.SetElementAmount(this.mChatDataList.Count, this.GetChatDataArraySize());
			if (this.mChatDataList.Count > 0)
			{
				this.mChatRecordList.EnsureElementVisable(this.mChatDataList.Count - 1);
			}
			this.timer = 0f;
		}

		// Token: 0x0600A0B4 RID: 41140 RVA: 0x00206D9F File Offset: 0x0020519F
		private ChatBlock GetChatBlockByIndex(int index)
		{
			if (this.mChatDataList == null || index < 0 || index >= this.mChatDataList.Count)
			{
				return null;
			}
			return this.mChatDataList[index];
		}

		// Token: 0x0600A0B5 RID: 41141 RVA: 0x00206DD4 File Offset: 0x002051D4
		private List<Vector2> GetChatDataArraySize()
		{
			List<Vector2> list = new List<Vector2>();
			for (int i = 0; i < this.mChatDataList.Count; i++)
			{
				if (this.mChatDataList[i] == null)
				{
					List<Vector2> list2 = list;
					Vector2 item = default(Vector2);
					item.x = 0f;
					item.y = 0f;
					list2.Add(item);
				}
				List<Vector2> list3 = list;
				Vector2 item2 = default(Vector2);
				item2.x = 268f;
				item2.y = (float)this.mChatDataList[i].chatData.height + 58.8f;
				list3.Add(item2);
			}
			return list;
		}

		// Token: 0x0400593E RID: 22846
		private ComUIListScript mChatRecordList;

		// Token: 0x0400593F RID: 22847
		private List<ChatBlock> mChatDataList;

		// Token: 0x04005940 RID: 22848
		private const float frameCloseSec = 3f;

		// Token: 0x04005941 RID: 22849
		private float timer;

		// Token: 0x04005942 RID: 22850
		private static string[] INDEX_PATH_ARRAY = new string[]
		{
			"UI/Image/Packed/p_UI_Battle_Pve.png:UI_Battle_Shuzi_1",
			"UI/Image/Packed/p_UI_Battle_Pve.png:UI_Battle_Shuzi_2",
			"UI/Image/Packed/p_UI_Battle_Pve.png:UI_Battle_Shuzi_3",
			"UI/Image/Packed/p_UI_Battle_Pve.png:UI_Battle_Shuzi_4"
		};
	}
}
