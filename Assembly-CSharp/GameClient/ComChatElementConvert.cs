using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200001F RID: 31
	internal class ComChatElementConvert : MonoBehaviour
	{
		// Token: 0x060000BF RID: 191 RVA: 0x00008B5C File Offset: 0x00006F5C
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
						this.self = gameObject.GetComponent<ComChatElement>();
						this.canvasSelf = gameObject.GetComponent<CanvasGroup>();
						if (null != this.self)
						{
							this.self.OnCreate(this.chatFrame);
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
					this.other = gameObject2.GetComponent<ComChatElement>();
					this.canvasOther = gameObject2.GetComponent<CanvasGroup>();
					if (null != this.other)
					{
						this.other.OnCreate(this.chatFrame);
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

		// Token: 0x060000C0 RID: 192 RVA: 0x00008CDA File Offset: 0x000070DA
		public void OnCreate(ClientFrame chatFrame)
		{
			this.chatFrame = (chatFrame as ChatFrame);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00008CE8 File Offset: 0x000070E8
		public void OnRecycle()
		{
			this.chatData = null;
			this.chatFrame = null;
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

		// Token: 0x060000C2 RID: 194 RVA: 0x00008DA4 File Offset: 0x000071A4
		public void OnItemVisible(ChatData chatData)
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
				this.chatElement.OnItemVisible(chatData);
			}
			else
			{
				Logger.LogErrorFormat("chatElement is null for chat frame,how could this happened!!!", new object[0]);
			}
		}

		// Token: 0x04000089 RID: 137
		private string ms_chat_prefab_self = "UIFlatten/Prefabs/Chat/PrefabSelf";

		// Token: 0x0400008A RID: 138
		private string ms_chat_prefab_other = "UIFlatten/Prefabs/Chat/PrefabOther";

		// Token: 0x0400008B RID: 139
		private CanvasGroup canvasSelf;

		// Token: 0x0400008C RID: 140
		private CanvasGroup canvasOther;

		// Token: 0x0400008D RID: 141
		private ComChatElement self;

		// Token: 0x0400008E RID: 142
		private ComChatElement other;

		// Token: 0x0400008F RID: 143
		private CanvasGroup canvas;

		// Token: 0x04000090 RID: 144
		private ComChatElement chatElement;

		// Token: 0x04000091 RID: 145
		private ChatData chatData;

		// Token: 0x04000092 RID: 146
		private ChatFrame chatFrame;
	}
}
