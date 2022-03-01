using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000021 RID: 33
	internal class ComChatElementNew : MonoBehaviour
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x000092C0 File Offset: 0x000076C0
		public ChatType ChatType
		{
			get
			{
				return this.chatData.eChatType;
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000092D0 File Offset: 0x000076D0
		public void OnCreate(ClientFrame frame)
		{
			this.THIS = (frame as RelationFriendFrame);
			if (this.voicePlayBtn != null)
			{
				this.voicePlayBtn.onClick.RemoveAllListeners();
				this.voicePlayBtn.onClick.AddListener(new UnityAction(this.OnVoicePlayButtonClick));
			}
			if (this.headIconBtn != null)
			{
				this.headIconBtn.onClick.RemoveAllListeners();
				this.headIconBtn.onClick.AddListener(new UnityAction(this.OnHeadClick));
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00009364 File Offset: 0x00007764
		private void OnDestroy()
		{
			if (this.voicePlayBtn != null)
			{
				this.voicePlayBtn.onClick.RemoveAllListeners();
				this.voicePlayBtn = null;
			}
			if (this.headIconBtn != null)
			{
				this.headIconBtn.onClick.RemoveAllListeners();
				this.headIconBtn = null;
			}
			this.goHornParent = null;
			this.kHornContent = null;
			this.auvElement = null;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000093D6 File Offset: 0x000077D6
		public void OnRecycle()
		{
			this.chatData = null;
			this.THIS = null;
			if (this.auvElement != null)
			{
				this.auvElement.RecyclePlayVoiceTex();
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00009404 File Offset: 0x00007804
		public void OnItemVisible(ChatData chatData, int index, List<ChatData> chatDatas)
		{
			this.chatData = chatData;
			try
			{
				if (chatData != null)
				{
					this.ShowVoiceContent();
					this.kName.SetText(chatData.GetNameLink(), true);
					if (!chatData.bHorn)
					{
						this.kContent.SetText(chatData.GetWords(), chatData.bLink == 1);
						this.goChatWordBG.CustomActive(!chatData.IsWordsEmpty());
						this.kNormalChat.CustomActive(true);
					}
					else
					{
						this.goChatWordBG.CustomActive(false);
						if (null != this.kHornContent)
						{
							this.kHornContent.SetText(chatData.GetWords(), chatData.bLink == 1);
						}
						this.kNormalChat.CustomActive(false);
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
						else if (chatData.bAddFriend)
						{
							chatData.GetSystemIcon(ref this.kIcon);
							if (this.mReplaceHeadPortraitFrame != null)
							{
								this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
							}
						}
						else
						{
							ETCImageLoader.LoadSprite(ref this.kIcon, path, true);
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
					}
					else
					{
						chatData.GetSystemIcon(ref this.kIcon);
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
					this.kTime.text = string.Empty;
					if (index == chatDatas.Count - 1)
					{
						ChatData chatData2 = chatDatas[index];
						if (index - 1 >= 0)
						{
							ChatData chatData3 = chatDatas[index - 1];
							if (chatData2.timeStamp - chatData3.timeStamp >= 60U)
							{
								this.kTime.text = chatData.shortTimeString;
								chatData.isShowTimeStamp = true;
							}
						}
						else
						{
							this.kTime.text = chatData.shortTimeString;
							chatData.isShowTimeStamp = true;
						}
					}
					if (chatData.isShowTimeStamp)
					{
						this.kTime.text = chatData.shortTimeString;
					}
					if (this.kTime.text == string.Empty)
					{
						this.goHuaWenLeft.CustomActive(false);
						this.goHuawenRight.CustomActive(false);
					}
					else
					{
						this.goHuaWenLeft.CustomActive(true);
						this.goHuawenRight.CustomActive(true);
					}
					chatData = null;
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00009744 File Offset: 0x00007B44
		private void OnHeadClick()
		{
			if (this.THIS != null)
			{
				this.THIS.OnPopupMenu();
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000975C File Offset: 0x00007B5C
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

		// Token: 0x060000D0 RID: 208 RVA: 0x000097F4 File Offset: 0x00007BF4
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

		// Token: 0x0400009D RID: 157
		public StateController mState;

		// Token: 0x0400009E RID: 158
		public Image kIcon;

		// Token: 0x0400009F RID: 159
		public LinkParse kName;

		// Token: 0x040000A0 RID: 160
		public Text kTime;

		// Token: 0x040000A1 RID: 161
		public Text kNormalChat;

		// Token: 0x040000A2 RID: 162
		public LinkParse kContent;

		// Token: 0x040000A3 RID: 163
		public Button headIconBtn;

		// Token: 0x040000A4 RID: 164
		public GameObject goHornParent;

		// Token: 0x040000A5 RID: 165
		private LinkParse kHornContent;

		// Token: 0x040000A6 RID: 166
		public GameObject goChatWordBG;

		// Token: 0x040000A7 RID: 167
		public GameObject goLvRoot;

		// Token: 0x040000A8 RID: 168
		public Text lv;

		// Token: 0x040000A9 RID: 169
		public Button voicePlayBtn;

		// Token: 0x040000AA RID: 170
		public Text voiceDuration;

		// Token: 0x040000AB RID: 171
		public AudioVoiceElement auvElement;

		// Token: 0x040000AC RID: 172
		public GameObject goHuaWenLeft;

		// Token: 0x040000AD RID: 173
		public GameObject goHuawenRight;

		// Token: 0x040000AE RID: 174
		public ReplaceHeadPortraitFrame mReplaceHeadPortraitFrame;

		// Token: 0x040000AF RID: 175
		protected ChatData chatData;

		// Token: 0x040000B0 RID: 176
		protected RelationFriendFrame THIS;
	}
}
