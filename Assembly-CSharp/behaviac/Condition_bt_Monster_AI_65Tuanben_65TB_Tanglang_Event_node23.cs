using System;

namespace behaviac
{
	// Token: 0x02002CAF RID: 11439
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node23 : Condition
	{
		// Token: 0x06014253 RID: 82515 RVA: 0x0060CE20 File Offset: 0x0060B220
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node23()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521946;
		}

		// Token: 0x06014254 RID: 82516 RVA: 0x0060CE44 File Offset: 0x0060B244
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC0B RID: 56331
		private BE_Target opl_p0;

		// Token: 0x0400DC0C RID: 56332
		private BE_Equal opl_p1;

		// Token: 0x0400DC0D RID: 56333
		private int opl_p2;
	}
}
