using System;

namespace behaviac
{
	// Token: 0x020021BF RID: 8639
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node38 : Condition
	{
		// Token: 0x06012D0D RID: 77069 RVA: 0x00588E9F File Offset: 0x0058729F
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node38()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012D0E RID: 77070 RVA: 0x00588ED4 File Offset: 0x005872D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6FF RID: 50943
		private int opl_p0;

		// Token: 0x0400C700 RID: 50944
		private int opl_p1;

		// Token: 0x0400C701 RID: 50945
		private int opl_p2;

		// Token: 0x0400C702 RID: 50946
		private int opl_p3;
	}
}
