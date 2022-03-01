using System;

namespace behaviac
{
	// Token: 0x02002CC4 RID: 11460
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node12 : Condition
	{
		// Token: 0x0601427C RID: 82556 RVA: 0x0060DAE1 File Offset: 0x0060BEE1
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node12()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601427D RID: 82557 RVA: 0x0060DB18 File Offset: 0x0060BF18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC2E RID: 56366
		private int opl_p0;

		// Token: 0x0400DC2F RID: 56367
		private int opl_p1;

		// Token: 0x0400DC30 RID: 56368
		private int opl_p2;

		// Token: 0x0400DC31 RID: 56369
		private int opl_p3;
	}
}
