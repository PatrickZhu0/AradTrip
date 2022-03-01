using System;

namespace behaviac
{
	// Token: 0x020021A3 RID: 8611
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node3 : Condition
	{
		// Token: 0x06012CD5 RID: 77013 RVA: 0x005881FB File Offset: 0x005865FB
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node3()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012CD6 RID: 77014 RVA: 0x00588230 File Offset: 0x00586630
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6C7 RID: 50887
		private int opl_p0;

		// Token: 0x0400C6C8 RID: 50888
		private int opl_p1;

		// Token: 0x0400C6C9 RID: 50889
		private int opl_p2;

		// Token: 0x0400C6CA RID: 50890
		private int opl_p3;
	}
}
