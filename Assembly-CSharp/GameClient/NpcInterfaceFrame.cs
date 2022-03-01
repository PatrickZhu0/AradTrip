using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004610 RID: 17936
	public sealed class NpcInterfaceFrame : ClientFrame
	{
		// Token: 0x06019372 RID: 103282 RVA: 0x007FA164 File Offset: 0x007F8564
		public static void TryCloseFrame(int curNpcId, ulong curNpcGuid = 0UL)
		{
			if (NpcInterfaceFrame.NpcGuid == curNpcGuid && NpcInterfaceFrame.NpcId == curNpcId)
			{
				NpcInterfaceFrame.NpcGuid = 0UL;
				NpcInterfaceFrame.NpcId = 0;
				NpcInterfaceFrame.Datas = null;
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<NpcInterfaceFrame>(null, false);
				NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(curNpcId, string.Empty, string.Empty);
				if (tableItem != null && tableItem.Function == NpcTable.eFunction.Chiji)
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiHandInEquipmentFrame>(null, false);
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiNpcDialogFrame>(null, false);
				}
			}
		}

		// Token: 0x06019373 RID: 103283 RVA: 0x007FA1EC File Offset: 0x007F85EC
		public static void OpenFrame(int curNpcId, List<NpcInteractionData> curDatas, ulong curNpcGuid = 0UL)
		{
			if (NpcInterfaceFrame.NpcGuid != 0UL || NpcInterfaceFrame.NpcId != 0)
			{
				return;
			}
			if (curNpcGuid != NpcInterfaceFrame.NpcGuid || curNpcId != NpcInterfaceFrame.NpcId || curDatas != NpcInterfaceFrame.Datas || !Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<NpcInterfaceFrame>(null))
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<NpcInterfaceFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<NpcInterfaceFrame>(null, false);
				}
				NpcInterfaceFrame.NpcGuid = curNpcGuid;
				NpcInterfaceFrame.NpcId = curNpcId;
				NpcInterfaceFrame.Datas = curDatas;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<NpcInterfaceFrame>(FrameLayer.Bottom, curDatas, string.Empty);
			}
		}

		// Token: 0x06019374 RID: 103284 RVA: 0x007FA281 File Offset: 0x007F8681
		protected sealed override bool GetNeedOpenSound()
		{
			return false;
		}

		// Token: 0x06019375 RID: 103285 RVA: 0x007FA284 File Offset: 0x007F8684
		protected sealed override bool GetNeedCloseSound()
		{
			return false;
		}

		// Token: 0x06019376 RID: 103286 RVA: 0x007FA287 File Offset: 0x007F8687
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FunctionFrame/NpcInterfaceFrame";
		}

		// Token: 0x06019377 RID: 103287 RVA: 0x007FA28E File Offset: 0x007F868E
		private void OnNpcRelationMissionChanged(UIEvent uiEvent)
		{
			if ((int)uiEvent.Param1 == NpcInterfaceFrame.NpcId)
			{
				this._RefreshNpcInteractionItems();
			}
		}

		// Token: 0x06019378 RID: 103288 RVA: 0x007FA2AB File Offset: 0x007F86AB
		protected override void _OnOpenFrame()
		{
			this._functionDatas = (this.userData as List<NpcInteractionData>);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NpcRelationMissionChanged, new ClientEventSystem.UIEventHandler(this.OnNpcRelationMissionChanged));
			this._RefreshNpcInteractionItems();
		}

		// Token: 0x06019379 RID: 103289 RVA: 0x007FA2DF File Offset: 0x007F86DF
		protected override void _OnCloseFrame()
		{
			NpcInterfaceFrame.NpcGuid = 0UL;
			NpcInterfaceFrame.NpcId = 0;
			NpcInterfaceFrame.Datas = null;
			this.m_akNpcInteractionItems.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NpcRelationMissionChanged, new ClientEventSystem.UIEventHandler(this.OnNpcRelationMissionChanged));
		}

		// Token: 0x0601937A RID: 103290 RVA: 0x007FA31C File Offset: 0x007F871C
		private void _RefreshNpcInteractionItems()
		{
			if (this._functionDatas != null)
			{
				GameObject gameObject = Utility.FindChild(this.frame, "FunctionItem");
				if (gameObject != null)
				{
					gameObject.CustomActive(false);
					this.m_akNpcInteractionItems.RecycleAllObject();
					for (int i = 0; i < this._functionDatas.Count; i++)
					{
						this.m_akNpcInteractionItems.Create(new object[]
						{
							gameObject.transform.parent.gameObject,
							gameObject,
							this._functionDatas[i],
							this
						});
					}
				}
			}
		}

		// Token: 0x04012115 RID: 74005
		public static ulong NpcGuid;

		// Token: 0x04012116 RID: 74006
		public static int NpcId;

		// Token: 0x04012117 RID: 74007
		public static List<NpcInteractionData> Datas;

		// Token: 0x04012118 RID: 74008
		private List<NpcInteractionData> _functionDatas;

		// Token: 0x04012119 RID: 74009
		private Button button;

		// Token: 0x0401211A RID: 74010
		private Image kIcon;

		// Token: 0x0401211B RID: 74011
		private CachedObjectListManager<NpcInteractionItem> m_akNpcInteractionItems = new CachedObjectListManager<NpcInteractionItem>();
	}
}
