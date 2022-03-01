using System;

namespace behaviac
{
	// Token: 0x020021BB RID: 8635
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node33 : Condition
	{
		// Token: 0x06012D05 RID: 77061 RVA: 0x00588D03 File Offset: 0x00587103
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node33()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D06 RID: 77062 RVA: 0x00588D38 File Offset: 0x00587138
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6F7 RID: 50935
		private int opl_p0;

		// Token: 0x0400C6F8 RID: 50936
		private int opl_p1;

		// Token: 0x0400C6F9 RID: 50937
		private int opl_p2;

		// Token: 0x0400C6FA RID: 50938
		private int opl_p3;
	}
}
