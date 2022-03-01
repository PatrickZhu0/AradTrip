using System;

namespace behaviac
{
	// Token: 0x0200328D RID: 12941
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node12 : Condition
	{
		// Token: 0x06014D94 RID: 85396 RVA: 0x00647D09 File Offset: 0x00646109
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node12()
		{
			this.opl_p0 = 570173;
		}

		// Token: 0x06014D95 RID: 85397 RVA: 0x00647D1C File Offset: 0x0064611C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E699 RID: 59033
		private int opl_p0;
	}
}
