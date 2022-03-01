using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000020 RID: 32
	internal class ComChatElementConvertNew : MonoBehaviour
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x00008F18 File Offset: 0x00007318
		private void _TryLoadChatResource()
		{
			if (this.chatData.objid == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				if (null == this.self)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadRes(this.ms_chat_prefab_self, typeof(GameObject), true, 0U).obj as GameObject;
					if (null != gameObject)
					{
						Utility.AttachTo(gameObject, base.gameObject, false);
						this.self = gameObject.GetComponent<ComChatElementNew>();
						this.canvasSelf = gameObject.GetComponent<CanvasGroup>();
						if (null != this.self)
						{
							this.self.OnCreate(this.relationFriendFrame);
						}
					}
					else
					{
						Logger.LogErrorFormat("can not find gameobject with path = {0}", new object[]
						{
							this.ms_chat_prefab_self
						});
					}
				}
			}
			else if (null == this.other)
			{
				GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadRes(this.ms_chat_prefab_other, typeof(GameObject), true, 0U).obj as GameObject;
				if (null != gameObject2)
				{
					Utility.AttachTo(gameObject2, base.gameObject, false);
					this.other = gameObject2.GetComponent<ComChatElementNew>();
					this.canvasOther = gameObject2.GetComponent<CanvasGroup>();
					if (null != this.other)
					{
						this.other.OnCreate(this.relationFriendFrame);
					}
				}
				else
				{
					Logger.LogErrorFormat("can not find gameobject with path = {0}", new object[]
					{
						this.ms_chat_prefab_other
					});
				}
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00009096 File Offset: 0x00007496
		public void OnCreate(ClientFrame chatFrame)
		{
			this.relationFriendFrame = (chatFrame as RelationFriendFrame);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000090A4 File Offset: 0x000074A4
		public void OnRecycle()
		{
			this.chatData = null;
			this.relationFriendFrame = null;
			if (null != this.canvasOther)
			{
				this.canvasOther.alpha = 0f;
				this.canvasOther.interactable = false;
			}
			if (null != this.canvasSelf)
			{
				this.canvasSelf.alpha = 0f;
				this.canvasSelf.interactable = false;
			}
			this.canvas = null;
			this.chatElement = null;
			if (null != this.self)
			{
				this.self.OnRecycle();
			}
			if (null != this.other)
			{
				this.other.OnRecycle();
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00009160 File Offset: 0x00007560
		public void OnItemVisible(ChatData chatData, int index, List<ChatData> chatDatas)
		{
			this.chatData = chatData;
			this._TryLoadChatResource();
			if (chatData.objid == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				this.canvas = this.canvasSelf;
				this.chatElement = this.self;
				if (null != this.canvasOther)
				{
					this.canvasOther.alpha = 0f;
					this.canvasOther.interactable = false;
					this.canvasOther.blocksRaycasts = false;
				}
			}
			else
			{
				this.canvas = this.canvasOther;
				this.chatElement = this.other;
				if (null != this.canvasSelf)
				{
					this.canvasSelf.alpha = 0f;
					this.canvasSelf.interactable = false;
					this.canvasSelf.blocksRaycasts = false;
				}
			}
			if (null != this.canvas)
			{
				this.canvas.blocksRaycasts = true;
				this.canvas.alpha = 1f;
				this.canvas.interactable = true;
			}
			else
			{
				Logger.LogErrorFormat("canvas is null for chat frame,how could this happened!!!", new object[0]);
			}
			if (null != this.chatElement)
			{
				this.chatElement.OnItemVisible(chatData, index, chatDatas);
			}
			else
			{
				Logger.LogErrorFormat("chatElement is null for chat frame,how could this happened!!!", new object[0]);
			}
		}

		// Token: 0x04000093 RID: 147
		private string ms_chat_prefab_self = "UIFlatten/Prefabs/Chat/ChatPrefabSelf";

		// Token: 0x04000094 RID: 148
		private string ms_chat_prefab_other = "UIFlatten/Prefabs/Chat/ChatPrefabOther";

		// Token: 0x04000095 RID: 149
		private CanvasGroup canvasSelf;

		// Token: 0x04000096 RID: 150
		private CanvasGroup canvasOther;

		// Token: 0x04000097 RID: 151
		private ComChatElementNew self;

		// Token: 0x04000098 RID: 152
		private ComChatElementNew other;

		// Token: 0x04000099 RID: 153
		private CanvasGroup canvas;

		// Token: 0x0400009A RID: 154
		private ComChatElementNew chatElement;

		// Token: 0x0400009B RID: 155
		private ChatData chatData;

		// Token: 0x0400009C RID: 156
		private RelationFriendFrame relationFriendFrame;
	}
}
