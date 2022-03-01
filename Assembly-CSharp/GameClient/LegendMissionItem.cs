using System;

namespace GameClient
{
	// Token: 0x02001719 RID: 5913
	internal class LegendMissionItem : CachedNormalObject<LegendMissionItemData>
	{
		// Token: 0x0600E85D RID: 59485 RVA: 0x003D6E87 File Offset: 0x003D5287
		public override void Initialize()
		{
			this.comLegendLinkMissionItem = Utility.FindComponent<ComLegendLinkMissionItem>(this.goLocal, string.Empty, true);
		}

		// Token: 0x0600E85E RID: 59486 RVA: 0x003D6EA0 File Offset: 0x003D52A0
		public override void UnInitialize()
		{
			this.comLegendLinkMissionItem = null;
		}

		// Token: 0x0600E85F RID: 59487 RVA: 0x003D6EA9 File Offset: 0x003D52A9
		public new void SetSiblingIndex(int iIndex)
		{
			if (null != this.goLocal)
			{
				this.goLocal.transform.SetSiblingIndex(iIndex);
			}
		}

		// Token: 0x0600E860 RID: 59488 RVA: 0x003D6ECD File Offset: 0x003D52CD
		public override void OnUpdate()
		{
			if (base.Value != null && base.Value.missionValue != null)
			{
				this.comLegendLinkMissionItem.SetMissionData(base.Value.missionValue, base.Value.LegendId);
			}
		}

		// Token: 0x04008CE1 RID: 36065
		public ComLegendLinkMissionItem comLegendLinkMissionItem;
	}
}
