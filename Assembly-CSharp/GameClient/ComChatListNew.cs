using System;
using System.Collections.Generic;
using System.Text;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200154C RID: 5452
	internal class ComChatListNew
	{
		// Token: 0x17001C00 RID: 7168
		// (get) Token: 0x0600D529 RID: 54569 RVA: 0x00354B9F File Offset: 0x00352F9F
		public bool Initilized
		{
			get
			{
				return this.bInitialize;
			}
		}

		// Token: 0x0600D52A RID: 54570 RVA: 0x00354BA8 File Offset: 0x00352FA8
		private ComChatElementConvertNew _OnBindItemDelegate(GameObject itemObject)
		{
			ComChatElementConvertNew component = itemObject.GetComponent<ComChatElementConvertNew>();
			if (component != null)
			{
				component.OnCreate(this.clientFrame);
			}
			return component;
		}

		// Token: 0x0600D52B RID: 54571 RVA: 0x00354BD8 File Offset: 0x00352FD8
		public void Initialize(ClientFrame clientFrame, GameObject gameObject, RelationData relationData)
		{
			if (this.bInitialize)
			{
				return;
			}
			this.bInitialize = true;
			this.clientFrame = clientFrame;
			this.gameObject = gameObject;
			this.relationData = relationData;
			this.comUIListScript = this.gameObject.GetComponent<ComUIListScript>();
			this.comUIListScript.Initialize();
			ComUIListScript comUIListScript = this.comUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.comUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
		}

		// Token: 0x0600D52C RID: 54572 RVA: 0x00354C77 File Offset: 0x00353077
		public void RefreshChatData(RelationData data)
		{
			this.relationData = data;
			this._LoadAllChatdatas();
		}

		// Token: 0x0600D52D RID: 54573 RVA: 0x00354C88 File Offset: 0x00353088
		private void _LoadAllChatdatas()
		{
			this.chatDatas.Clear();
			this.size.Clear();
			if (this.relationData != null)
			{
				List<ChatBlock> privateChat = DataManager<ChatManager>.GetInstance().GetPrivateChat(this.relationData.uid);
				if (privateChat != null)
				{
					for (int i = 0; i < privateChat.Count; i++)
					{
						ChatData chatData = privateChat[i].chatData;
						this.chatDatas.Add(chatData);
						StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
						LinkParse._TryToken(stringBuilder, chatData.word, 0, null, LinkParse.EmotionSizeType.EST_72);
						string text = stringBuilder.ToString();
						chatData.height = (int)(DataManager<ChatManager>.GetInstance().GetContentHeightByGeneratorNew(text) + 0.5f);
						StringBuilderCache.Release(stringBuilder);
						float num = (!chatData.bVoice) ? 0f : 60f;
						float num2 = 0f;
						if (chatData.bVoice && !string.IsNullOrEmpty(chatData.word))
						{
							num2 = 0f;
						}
						float num3 = (float)chatData.height + 32f;
						num3 = Mathf.Max(num3, 90f);
						num3 = num3 + 40f + num + num2;
						Vector2 vector = default(Vector2);
						vector.x = 984f;
						vector.y = num3 + 32f;
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

		// Token: 0x0600D52E RID: 54574 RVA: 0x00354E30 File Offset: 0x00353230
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComChatElementConvertNew comChatElementConvertNew = item.gameObjectBindScript as ComChatElementConvertNew;
			if (comChatElementConvertNew != null && item.m_index >= 0 && item.m_index < this.chatDatas.Count)
			{
				comChatElementConvertNew.OnItemVisible(this.chatDatas[item.m_index], item.m_index, this.chatDatas);
			}
		}

		// Token: 0x0600D52F RID: 54575 RVA: 0x00354E9C File Offset: 0x0035329C
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
			this.relationData = null;
			this.gameObject = null;
			this.clientFrame = null;
			this.chatDatas.Clear();
			this.bInitialize = false;
		}

		// Token: 0x04007D2D RID: 32045
		private bool bInitialize;

		// Token: 0x04007D2E RID: 32046
		private ClientFrame clientFrame;

		// Token: 0x04007D2F RID: 32047
		private GameObject gameObject;

		// Token: 0x04007D30 RID: 32048
		private ComUIListScript comUIListScript;

		// Token: 0x04007D31 RID: 32049
		private List<ChatData> chatDatas = new List<ChatData>();

		// Token: 0x04007D32 RID: 32050
		private List<Vector2> size = new List<Vector2>();

		// Token: 0x04007D33 RID: 32051
		private RelationData relationData;
	}
}
