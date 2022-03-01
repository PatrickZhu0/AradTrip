using System;

namespace behaviac
{
	// Token: 0x0200207F RID: 8319
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node38 : Condition
	{
		// Token: 0x06012A97 RID: 76439 RVA: 0x005799F7 File Offset: 0x00577DF7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node38()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012A98 RID: 76440 RVA: 0x00579A2C File Offset: 0x00577E2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C489 RID: 50313
		private int opl_p0;

		// Token: 0x0400C48A RID: 50314
		private int opl_p1;

		// Token: 0x0400C48B RID: 50315
		private int opl_p2;

		// Token: 0x0400C48C RID: 50316
		private int opl_p3;
	}
}
