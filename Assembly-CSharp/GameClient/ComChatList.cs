using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200154B RID: 5451
	internal class ComChatList
	{
		// Token: 0x17001BFF RID: 7167
		// (get) Token: 0x0600D51F RID: 54559 RVA: 0x003546C2 File Offset: 0x00352AC2
		public bool Initilized
		{
			get
			{
				return this.bInitialize;
			}
		}

		// Token: 0x0600D520 RID: 54560 RVA: 0x003546CC File Offset: 0x00352ACC
		private ComChatElementConvert _OnBindItemDelegate(GameObject itemObject)
		{
			ComChatElementConvert component = itemObject.GetComponent<ComChatElementConvert>();
			if (component != null)
			{
				component.OnCreate(this.clientFrame);
			}
			return component;
		}

		// Token: 0x0600D521 RID: 54561 RVA: 0x003546FC File Offset: 0x00352AFC
		public void Initialize(ClientFrame clientFrame, GameObject gameObject, ChatFrameData chatFrameData)
		{
			if (this.bInitialize)
			{
				return;
			}
			this.bInitialize = true;
			this.clientFrame = clientFrame;
			this.gameObject = gameObject;
			this.chatFrameData = chatFrameData;
			this.comUIListScript = this.gameObject.GetComponent<ComUIListScript>();
			this.comUIListScript.Initialize();
			ComUIListScript comUIListScript = this.comUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.comUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			this._LoadAllChatdatas();
		}

		// Token: 0x0600D522 RID: 54562 RVA: 0x003547A1 File Offset: 0x00352BA1
		public void RefreshChatData(ChatFrameData data)
		{
			this.chatFrameData = data;
			this._LoadAllChatdatas();
		}

		// Token: 0x0600D523 RID: 54563 RVA: 0x003547B0 File Offset: 0x00352BB0
		private bool _NormalChatFilter(ChatBlock chatBlock)
		{
			return chatBlock.chatData.eChatType != ChatType.CT_ALL && chatBlock.chatData.eChatType != this.chatFrameData.eChatType;
		}

		// Token: 0x0600D524 RID: 54564 RVA: 0x003547E4 File Offset: 0x00352BE4
		private bool _PrivateChatFilter(ChatBlock chatBlock)
		{
			return chatBlock.chatData.eChatType != this.chatFrameData.eChatType || this.chatFrameData.curPrivate == null || ((chatBlock.chatData.objid != DataManager<PlayerBaseData>.GetInstance().RoleID || chatBlock.chatData.targetID != this.chatFrameData.curPrivate.uid) && (chatBlock.chatData.objid != this.chatFrameData.curPrivate.uid || DataManager<PlayerBaseData>.GetInstance().RoleID != chatBlock.chatData.targetID));
		}

		// Token: 0x0600D525 RID: 54565 RVA: 0x00354898 File Offset: 0x00352C98
		private void _LoadAllChatdatas()
		{
			this.chatDatas.Clear();
			this.size.Clear();
			if (this.chatFrameData.eChatType != ChatType.CT_PRIVATE && this.chatFrameData.eChatType != ChatType.CT_PRIVATE_LIST)
			{
				ChanelType eChanelType = DataManager<ChatManager>.GetInstance()._TransChatType(this.chatFrameData.eChatType);
				List<ChatBlock> chatDataByChanelType = DataManager<ChatManager>.GetInstance().GetChatDataByChanelType(eChanelType);
				if (chatDataByChanelType != null)
				{
					chatDataByChanelType.RemoveAll(new Predicate<ChatBlock>(this._NormalChatFilter));
					for (int i = 0; i < chatDataByChanelType.Count; i++)
					{
						this.chatDatas.Add(chatDataByChanelType[i].chatData);
						float num = (!chatDataByChanelType[i].chatData.bVoice) ? 0f : 75f;
						float num2 = 12f;
						float num3 = 0f;
						if (chatDataByChanelType[i].chatData.bVoice && !string.IsNullOrEmpty(chatDataByChanelType[i].chatData.word))
						{
							num3 = 12f;
						}
						float num4 = (float)chatDataByChanelType[i].chatData.height + 24f + 37.72f + num + num2 + num3;
						num4 = Mathf.Max(num4, 109f);
						if (chatDataByChanelType[i].chatData.bHorn)
						{
							num4 = 212.72f;
						}
						Vector2 vector = default(Vector2);
						vector.x = 850f;
						vector.y = num4 + 24f;
						Vector2 item = vector;
						this.size.Add(item);
					}
				}
			}
			this.comUIListScript.SetElementAmount(this.chatDatas.Count, this.size);
			if (this.chatDatas.Count > 0)
			{
				this.comUIListScript.EnsureElementVisable(this.chatDatas.Count - 1);
			}
		}

		// Token: 0x0600D526 RID: 54566 RVA: 0x00354A80 File Offset: 0x00352E80
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComChatElementConvert comChatElementConvert = item.gameObjectBindScript as ComChatElementConvert;
			if (comChatElementConvert != null && item.m_index >= 0 && item.m_index < this.chatDatas.Count)
			{
				comChatElementConvert.OnItemVisible(this.chatDatas[item.m_index]);
			}
		}

		// Token: 0x0600D527 RID: 54567 RVA: 0x00354AE0 File Offset: 0x00352EE0
		public void UnInitialize()
		{
			if (this.comUIListScript != null)
			{
				ComUIListScript comUIListScript = this.comUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.comUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				this.comUIListScript = null;
			}
			this.chatFrameData = null;
			this.chatType = ChatType.CT_WORLD;
			this.gameObject = null;
			this.clientFrame = null;
			this.chatDatas.Clear();
			this.bInitialize = false;
		}

		// Token: 0x04007D25 RID: 32037
		private bool bInitialize;

		// Token: 0x04007D26 RID: 32038
		private ClientFrame clientFrame;

		// Token: 0x04007D27 RID: 32039
		private GameObject gameObject;

		// Token: 0x04007D28 RID: 32040
		private ComUIListScript comUIListScript;

		// Token: 0x04007D29 RID: 32041
		private List<ChatData> chatDatas = new List<ChatData>();

		// Token: 0x04007D2A RID: 32042
		private List<Vector2> size = new List<Vector2>();

		// Token: 0x04007D2B RID: 32043
		private ChatType chatType = ChatType.CT_WORLD;

		// Token: 0x04007D2C RID: 32044
		private ChatFrameData chatFrameData;
	}
}
