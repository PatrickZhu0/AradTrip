using System;

namespace behaviac
{
	// Token: 0x02002EA6 RID: 11942
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node35 : Condition
	{
		// Token: 0x06014627 RID: 83495 RVA: 0x0062103E File Offset: 0x0061F43E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node35()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570308;
		}

		// Token: 0x06014628 RID: 83496 RVA: 0x00621060 File Offset: 0x0061F460
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF9F RID: 57247
		private BE_Target opl_p0;

		// Token: 0x0400DFA0 RID: 57248
		private BE_Equal opl_p1;

		// Token: 0x0400DFA1 RID: 57249
		private int opl_p2;
	}
}
