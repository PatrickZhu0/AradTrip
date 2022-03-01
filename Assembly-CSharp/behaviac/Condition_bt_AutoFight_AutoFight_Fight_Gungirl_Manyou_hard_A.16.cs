using System;

namespace behaviac
{
	// Token: 0x0200202F RID: 8239
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node38 : Condition
	{
		// Token: 0x060129F9 RID: 76281 RVA: 0x00575DBF File Offset: 0x005741BF
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node38()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060129FA RID: 76282 RVA: 0x00575DF4 File Offset: 0x005741F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3EB RID: 50155
		private int opl_p0;

		// Token: 0x0400C3EC RID: 50156
		private int opl_p1;

		// Token: 0x0400C3ED RID: 50157
		private int opl_p2;

		// Token: 0x0400C3EE RID: 50158
		private int opl_p3;
	}
}
