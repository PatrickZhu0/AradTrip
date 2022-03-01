using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016A4 RID: 5796
	internal class CommonGetItemFrame : ClientFrame
	{
		// Token: 0x0600E3A8 RID: 58280 RVA: 0x003AA9A6 File Offset: 0x003A8DA6
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/GetItem/CommonGetItem";
		}

		// Token: 0x0600E3A9 RID: 58281 RVA: 0x003AA9B0 File Offset: 0x003A8DB0
		protected override void _OnOpenFrame()
		{
			CommonGetItemData commonGetItemData = this.userData as CommonGetItemData;
			if (commonGetItemData == null)
			{
				Logger.LogError("open CommonGetItemFrame, userdata is invalid");
				return;
			}
			GameObject gameObject = Utility.FindGameObject(this.frame, "Title/EffUI_renwuwancheng_gai/EffUI_renwuwancheng_gaiDZ/zi", true);
			if (gameObject != null)
			{
				MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
				if (component != null)
				{
					Texture texture = Singleton<AssetLoader>.instance.LoadRes(commonGetItemData.title, typeof(Texture), true, 0U).obj as Texture;
					if (texture != null)
					{
						component.material.mainTexture = texture;
					}
				}
			}
			GameObject gameObject2 = Utility.FindGameObject(this.frame, "Item", true);
			if (gameObject2 != null)
			{
				this.m_comItem = base.CreateComItem(gameObject2);
			}
			Text componetInChild = Utility.GetComponetInChild<Text>(this.frame, "Desc");
			if (componetInChild != null)
			{
			}
		}

		// Token: 0x0600E3AA RID: 58282 RVA: 0x003AAA97 File Offset: 0x003A8E97
		protected override void _OnCloseFrame()
		{
			this.m_comItem = null;
		}

		// Token: 0x0600E3AB RID: 58283 RVA: 0x003AAAA0 File Offset: 0x003A8EA0
		[UIEventHandle("Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<CommonGetItemFrame>(this, false);
		}

		// Token: 0x0400889B RID: 34971
		private ComItem m_comItem;
	}
}
