using System;

namespace behaviac
{
	// Token: 0x02002CC8 RID: 11464
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node17 : Condition
	{
		// Token: 0x06014284 RID: 82564 RVA: 0x0060DC61 File Offset: 0x0060C061
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node17()
		{
			this.opl_p0 = 8500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06014285 RID: 82565 RVA: 0x0060DC98 File Offset: 0x0060C098
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC35 RID: 56373
		private int opl_p0;

		// Token: 0x0400DC36 RID: 56374
		private int opl_p1;

		// Token: 0x0400DC37 RID: 56375
		private int opl_p2;

		// Token: 0x0400DC38 RID: 56376
		private int opl_p3;
	}
}
