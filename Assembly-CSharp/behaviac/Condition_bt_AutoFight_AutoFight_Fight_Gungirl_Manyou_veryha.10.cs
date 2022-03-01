using System;

namespace behaviac
{
	// Token: 0x02002073 RID: 8307
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node23 : Condition
	{
		// Token: 0x06012A7F RID: 76415 RVA: 0x00579473 File Offset: 0x00577873
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012A80 RID: 76416 RVA: 0x005794A8 File Offset: 0x005778A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C471 RID: 50289
		private int opl_p0;

		// Token: 0x0400C472 RID: 50290
		private int opl_p1;

		// Token: 0x0400C473 RID: 50291
		private int opl_p2;

		// Token: 0x0400C474 RID: 50292
		private int opl_p3;
	}
}
