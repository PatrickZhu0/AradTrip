using System;

namespace behaviac
{
	// Token: 0x02002DB7 RID: 11703
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node26 : Condition
	{
		// Token: 0x0601444D RID: 83021 RVA: 0x0061750A File Offset: 0x0061590A
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node26()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570300;
		}

		// Token: 0x0601444E RID: 83022 RVA: 0x0061752C File Offset: 0x0061592C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE13 RID: 56851
		private BE_Target opl_p0;

		// Token: 0x0400DE14 RID: 56852
		private BE_Equal opl_p1;

		// Token: 0x0400DE15 RID: 56853
		private int opl_p2;
	}
}
