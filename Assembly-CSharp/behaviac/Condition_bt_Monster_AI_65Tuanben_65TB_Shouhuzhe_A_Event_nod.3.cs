using System;

namespace behaviac
{
	// Token: 0x02002C41 RID: 11329
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node7 : Condition
	{
		// Token: 0x0601417E RID: 82302 RVA: 0x00608C4F File Offset: 0x0060704F
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521984;
		}

		// Token: 0x0601417F RID: 82303 RVA: 0x00608C70 File Offset: 0x00607070
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB40 RID: 56128
		private BE_Target opl_p0;

		// Token: 0x0400DB41 RID: 56129
		private BE_Equal opl_p1;

		// Token: 0x0400DB42 RID: 56130
		private int opl_p2;
	}
}
