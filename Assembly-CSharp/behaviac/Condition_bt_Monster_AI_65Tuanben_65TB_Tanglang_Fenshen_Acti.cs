using System;

namespace behaviac
{
	// Token: 0x02002CBC RID: 11452
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node1 : Condition
	{
		// Token: 0x0601426C RID: 82540 RVA: 0x0060D7E1 File Offset: 0x0060BBE1
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node1()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601426D RID: 82541 RVA: 0x0060D818 File Offset: 0x0060BC18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC20 RID: 56352
		private int opl_p0;

		// Token: 0x0400DC21 RID: 56353
		private int opl_p1;

		// Token: 0x0400DC22 RID: 56354
		private int opl_p2;

		// Token: 0x0400DC23 RID: 56355
		private int opl_p3;
	}
}
