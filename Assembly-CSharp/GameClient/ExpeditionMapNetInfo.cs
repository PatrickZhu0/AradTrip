using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x020011D4 RID: 4564
	public class ExpeditionMapNetInfo
	{
		// Token: 0x0600AF02 RID: 44802 RVA: 0x00264089 File Offset: 0x00262489
		public ExpeditionMapNetInfo(byte id)
		{
			this.mapId = id;
			this.mapStatus = ExpeditionStatus.EXPEDITION_STATUS_PREPARE;
			this.durationOfExpedition = 0U;
			this.endTimeOfExpedition = 0U;
			this.roles = new List<ExpeditionMemberInfo>();
		}

		// Token: 0x0600AF03 RID: 44803 RVA: 0x002640B8 File Offset: 0x002624B8
		public ExpeditionMapNetInfo()
		{
			this.mapId = 1;
			this.mapStatus = ExpeditionStatus.EXPEDITION_STATUS_PREPARE;
			this.durationOfExpedition = 0U;
			this.endTimeOfExpedition = 0U;
			this.roles = new List<ExpeditionMemberInfo>();
		}

		// Token: 0x0600AF04 RID: 44804 RVA: 0x002640E7 File Offset: 0x002624E7
		public void Clear()
		{
			if (this.roles != null)
			{
				this.roles.Clear();
			}
		}

		// Token: 0x040061FF RID: 25087
		public byte mapId;

		// Token: 0x04006200 RID: 25088
		public ExpeditionStatus mapStatus;

		// Token: 0x04006201 RID: 25089
		public uint durationOfExpedition;

		// Token: 0x04006202 RID: 25090
		public uint endTimeOfExpedition;

		// Token: 0x04006203 RID: 25091
		public List<ExpeditionMemberInfo> roles;
	}
}
