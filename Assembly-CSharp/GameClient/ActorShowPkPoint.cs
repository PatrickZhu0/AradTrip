using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013FD RID: 5117
	internal class ActorShowPkPoint : ClientFrame
	{
		// Token: 0x0600C641 RID: 50753 RVA: 0x002FD96B File Offset: 0x002FBD6B
		public static void Open(FrameLayer eLayer, object data)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ActorShowPkPoint>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActorShowPkPoint>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActorShowPkPoint>(eLayer, data, string.Empty);
		}

		// Token: 0x0600C642 RID: 50754 RVA: 0x002FD99B File Offset: 0x002FBD9B
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/ActorGroup/ActorShowPkPoint";
		}

		// Token: 0x0600C643 RID: 50755 RVA: 0x002FD9A4 File Offset: 0x002FBDA4
		protected override void _OnOpenFrame()
		{
			this.m_kButton = this.frame.GetComponent<Button>();
			this.m_kButton.onClick.RemoveAllListeners();
			this.m_kButton.onClick.AddListener(delegate()
			{
				this.frameMgr.CloseFrame<ActorShowPkPoint>(this, false);
			});
			this.m_goParent = Utility.FindChild(this.frame, "main/ItemArray");
			this.m_goPrefab = Utility.FindChild(this.m_goParent, "backItem");
			this.m_goPrefab.CustomActive(false);
			this.m_kData = (this.userData as ActorShowPkPointData);
			for (int i = 0; i < this.m_kData.akItemData.Count; i++)
			{
				SingleItemData singleItemData = this.m_kData.akItemData[i];
				GameObject gameObject = Object.Instantiate<GameObject>(this.m_goPrefab);
				Utility.AttachTo(gameObject, this.m_goParent, false);
				gameObject.CustomActive(true);
				Text text = Utility.FindComponent<Text>(gameObject, "Key", true);
				Text text2 = Utility.FindComponent<Text>(gameObject, "Value", true);
				Image component = gameObject.GetComponent<Image>();
				component.enabled = ((i & 1) > 0);
				text.text = singleItemData.key;
				text2.text = singleItemData.value;
			}
		}

		// Token: 0x0600C644 RID: 50756 RVA: 0x002FDAD3 File Offset: 0x002FBED3
		protected override void _OnCloseFrame()
		{
			this.m_kButton.onClick.RemoveAllListeners();
			this.m_kButton = null;
			this.m_kData = null;
		}

		// Token: 0x040071BA RID: 29114
		private Button m_kButton;

		// Token: 0x040071BB RID: 29115
		private ActorShowPkPointData m_kData;

		// Token: 0x040071BC RID: 29116
		private GameObject m_goParent;

		// Token: 0x040071BD RID: 29117
		private GameObject m_goPrefab;
	}
}
