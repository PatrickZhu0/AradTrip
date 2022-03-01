using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200191D RID: 6429
	public class RecommendedDungeonsFrame : ClientFrame
	{
		// Token: 0x0600FA42 RID: 64066 RVA: 0x00448271 File Offset: 0x00446671
		protected sealed override void _bindExUI()
		{
			this.mItem = this.mBind.GetGameObject("Item");
			this.mContent = this.mBind.GetGameObject("content");
		}

		// Token: 0x0600FA43 RID: 64067 RVA: 0x0044829F File Offset: 0x0044669F
		protected sealed override void _unbindExUI()
		{
			this.mItem = null;
			this.mContent = null;
		}

		// Token: 0x0600FA44 RID: 64068 RVA: 0x004482AF File Offset: 0x004466AF
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/RecommendedDungeonsFrame/RecommendedDungeonsFrame";
		}

		// Token: 0x0600FA45 RID: 64069 RVA: 0x004482B6 File Offset: 0x004466B6
		protected sealed override void _OnOpenFrame()
		{
			this.ids = (this.userData as List<int>);
			this.Initialize();
		}

		// Token: 0x0600FA46 RID: 64070 RVA: 0x004482CF File Offset: 0x004466CF
		protected sealed override void _OnCloseFrame()
		{
			this.ids.Clear();
		}

		// Token: 0x0600FA47 RID: 64071 RVA: 0x004482DC File Offset: 0x004466DC
		private void Initialize()
		{
			this.mItem.CustomActive(false);
			if (this.ids != null)
			{
				for (int i = 0; i < this.ids.Count; i++)
				{
					AcquiredMethodTable linkItem = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(this.ids[i], string.Empty, string.Empty);
					if (linkItem != null)
					{
						GameObject gameObject = Object.Instantiate<GameObject>(this.mItem);
						Utility.AttachTo(gameObject, this.mContent, false);
						gameObject.CustomActive(true);
						ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
						Text com = component.GetCom<Text>("Name");
						Text com2 = component.GetCom<Text>("LinkZone");
						Button com3 = component.GetCom<Button>("Go");
						if (com != null)
						{
							com.text = linkItem.Name;
						}
						if (com2 != null)
						{
							com2.text = linkItem.LinkZone;
						}
						if (com3 != null)
						{
							com3.onClick.RemoveAllListeners();
							com3.onClick.AddListener(delegate()
							{
								DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(linkItem.LinkInfo, null, false);
								this.frameMgr.CloseFrame<RecommendedDungeonsFrame>(this, false);
								if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null))
								{
									Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
								}
							});
						}
					}
				}
			}
		}

		// Token: 0x04009C41 RID: 40001
		private GameObject mItem;

		// Token: 0x04009C42 RID: 40002
		private GameObject mContent;

		// Token: 0x04009C43 RID: 40003
		private List<int> ids = new List<int>();
	}
}
