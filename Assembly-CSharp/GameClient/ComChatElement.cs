using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200001E RID: 30
	internal class ComChatElement : MonoBehaviour
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x0000840C File Offset: 0x0000680C
		public ChatType ChatType
		{
			get
			{
				return this.chatData.eChatType;
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000841C File Offset: 0x0000681C
		public void OnCreate(ClientFrame frame)
		{
			this.THIS = (frame as ChatFrame);
			if (this.headIconBtn != null)
			{
				this.headIconBtn.onClick.RemoveAllListeners();
				this.headIconBtn.onClick.AddListener(new UnityAction(this._OnClickHeadIcon));
			}
			if (this.voicePlayBtn != null)
			{
				this.voicePlayBtn.onClick.RemoveAllListeners();
				this.voicePlayBtn.onClick.AddListener(new UnityAction(this.OnVoicePlayButtonClick));
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000084B0 File Offset: 0x000068B0
		private void OnDestroy()
		{
			if (this.headIconBtn != null)
			{
				this.headIconBtn.onClick.RemoveAllListeners();
				this.headIconBtn = null;
			}
			if (this.voicePlayBtn != null)
			{
				this.voicePlayBtn.onClick.RemoveAllListeners();
				this.voicePlayBtn = null;
			}
			this.goHornParent = null;
			this.kHornContent = null;
			this.goHornObject = null;
			this.auvElement = null;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00008529 File Offset: 0x00006929
		public void OnRecycle()
		{
			this.chatData = null;
			this.THIS = null;
			if (this.auvElement != null)
			{
				this.auvElement.RecyclePlayVoiceTex();
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00008558 File Offset: 0x00006958
		private void _OnClickHeadIcon()
		{
			if (this.chatData == null)
			{
				return;
			}
			if (this.chatData.eChatType == ChatType.CT_SYSTEM || this.chatData.objid == 0UL)
			{
				return;
			}
			if (this.chatData.objid == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.instance.IsFrameOpen<RelationMenuFram>(null))
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<RelationMenuFram>(null, false);
			}
			RelationData relationData = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(this.chatData.objid);
			if (relationData == null || relationData.type == 3)
			{
				relationData = new RelationData();
				relationData.uid = this.chatData.objid;
				relationData.name = this.chatData.objname;
				relationData.occu = this.chatData.occu;
				relationData.level = this.chatData.level;
				relationData.isOnline = 1;
				relationData.type = 3;
			}
			relationData.zoneId = this.chatData.zoneId;
			RelationMenuData relationMenuData = new RelationMenuData();
			relationMenuData.m_data = relationData;
			if (this.chatData.channel == 4)
			{
				relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_DEL_PRIVATE_CHAT;
			}
			else
			{
				relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_COMMON;
			}
			if (TeamDuplicationUtility.IsInTeamDuplicationScene())
			{
				relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_TEAMDUPLICATION;
			}
			UIEventSystem.GetInstance().SendUIEvent(new UIEventShowFriendSecMenu(relationMenuData));
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000086B4 File Offset: 0x00006AB4
		private void _TryLoadHornResources()
		{
			if (null == this.goHornObject)
			{
				this.goHornObject = (Singleton<AssetLoader>.instance.LoadRes(ComChatElement.ms_horn_res_path, typeof(GameObject), true, 0U).obj as GameObject);
				if (null != this.goHornParent)
				{
					this.kHornContent = this.goHornObject.GetComponent<LinkParse>();
					Utility.AttachTo(this.goHornObject, this.goHornParent, false);
					this.goHornObject.transform.SetSiblingIndex(0);
				}
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00008744 File Offset: 0x00006B44
		public void OnItemVisible(ChatData chatData)
		{
			this.chatData = chatData;
			try
			{
				if (chatData != null)
				{
					this.ShowVoiceContent();
					this.kName.SetText(chatData.GetNameLink(), true);
					if (chatData.bHorn)
					{
						this._TryLoadHornResources();
					}
					if (!chatData.bHorn)
					{
						this.kContent.SetText(chatData.GetWords(), chatData.bLink == 1);
						this.goChatWordBG.CustomActive(!chatData.IsWordsEmpty());
						this.kNormalChat.CustomActive(true);
						this.goHornObject.CustomActive(false);
					}
					else
					{
						this.goChatWordBG.CustomActive(false);
						if (null != this.kHornContent)
						{
							this.kHornContent.SetText(chatData.GetWords(), chatData.bLink == 1);
						}
						this.kNormalChat.CustomActive(false);
						this.goHornObject.CustomActive(true);
						this.ReplaceHeadPortraitFrame(chatData);
					}
					if (this.ChatType != ChatType.CT_SYSTEM)
					{
						string path = string.Empty;
						JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)chatData.occu, string.Empty, string.Empty);
						if (tableItem != null)
						{
							ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								path = tableItem2.IconPath;
							}
						}
						if (chatData.objid == 0UL)
						{
							chatData.GetSystemIcon(ref this.kIcon);
						}
						else
						{
							ETCImageLoader.LoadSprite(ref this.kIcon, path, true);
							this.ReplaceHeadPortraitFrame(chatData);
						}
					}
					else
					{
						chatData.GetSystemIcon(ref this.kIcon);
						if (this.mReplaceHeadPortraitFrame != null)
						{
							this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
						}
					}
					if (null != this.mState)
					{
						if (chatData.bRedPacket)
						{
							this.mState.Key = "redpacket";
						}
						else
						{
							this.mState.Key = "normal";
						}
					}
					this.kTime.text = chatData.shortTimeString;
					this.kChannel.text = chatData.GetChannelString();
					this.goVip.CustomActive(false);
					chatData = null;
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00008998 File Offset: 0x00006D98
		private void ReplaceHeadPortraitFrame(ChatData chatData)
		{
			if (chatData == null)
			{
				return;
			}
			if (this.mReplaceHeadPortraitFrame != null)
			{
				if (chatData.headFrame != 0U)
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame((int)chatData.headFrame);
				}
				else
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
				}
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000089F0 File Offset: 0x00006DF0
		private void OnVoicePlayButtonClick()
		{
			if (this.chatData == null)
			{
				return;
			}
			if (!this.chatData.bVoice)
			{
				return;
			}
			if (this.THIS == null)
			{
				return;
			}
			if (this.auvElement != null)
			{
				this.auvElement.ResetPlayVoiceTex();
			}
			this.THIS.PlayVoice(this.chatData.voiceKey, this.chatData.shortTimeString, new ChatVoiceInPlay
			{
				VoiceDuration = (int)this.chatData.voiceDuration,
				audioElement = this.auvElement
			});
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00008A88 File Offset: 0x00006E88
		private void ShowVoiceContent()
		{
			if (this.chatData != null)
			{
				if (this.chatData.eChatType == ChatType.CT_SYSTEM)
				{
					this.voiceDuration.transform.parent.gameObject.SetActive(false);
					return;
				}
				this.voiceDuration.text = ((!this.chatData.bVoice) ? string.Empty : ((int)this.chatData.voiceDuration + "\""));
				this.voiceDuration.transform.parent.gameObject.SetActive(this.chatData.bVoice);
			}
		}

		// Token: 0x04000074 RID: 116
		public StateController mState;

		// Token: 0x04000075 RID: 117
		public Image kIcon;

		// Token: 0x04000076 RID: 118
		public LinkParse kName;

		// Token: 0x04000077 RID: 119
		public Text kTime;

		// Token: 0x04000078 RID: 120
		public Text kNormalChat;

		// Token: 0x04000079 RID: 121
		public LinkParse kContent;

		// Token: 0x0400007A RID: 122
		public Text kChannel;

		// Token: 0x0400007B RID: 123
		public GameObject goVip;

		// Token: 0x0400007C RID: 124
		public UINumber kVipLevel;

		// Token: 0x0400007D RID: 125
		public Button headIconBtn;

		// Token: 0x0400007E RID: 126
		public GameObject goHornParent;

		// Token: 0x0400007F RID: 127
		private LinkParse kHornContent;

		// Token: 0x04000080 RID: 128
		private GameObject goHornObject;

		// Token: 0x04000081 RID: 129
		public GameObject goChatWordBG;

		// Token: 0x04000082 RID: 130
		public Button voicePlayBtn;

		// Token: 0x04000083 RID: 131
		public Text voiceDuration;

		// Token: 0x04000084 RID: 132
		public AudioVoiceElement auvElement;

		// Token: 0x04000085 RID: 133
		public ReplaceHeadPortraitFrame mReplaceHeadPortraitFrame;

		// Token: 0x04000086 RID: 134
		protected ChatData chatData;

		// Token: 0x04000087 RID: 135
		protected ChatFrame THIS;

		// Token: 0x04000088 RID: 136
		private static string ms_horn_res_path = "UIFlatten/Prefabs/Chat/LaBa";
	}
}
