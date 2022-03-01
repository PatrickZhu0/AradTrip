using System;

namespace behaviac
{
	// Token: 0x02002CC0 RID: 11456
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node8 : Condition
	{
		// Token: 0x06014274 RID: 82548 RVA: 0x0060D961 File Offset: 0x0060BD61
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node8()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06014275 RID: 82549 RVA: 0x0060D998 File Offset: 0x0060BD98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC27 RID: 56359
		private int opl_p0;

		// Token: 0x0400DC28 RID: 56360
		private int opl_p1;

		// Token: 0x0400DC29 RID: 56361
		private int opl_p2;

		// Token: 0x0400DC2A RID: 56362
		private int opl_p3;
	}
}
