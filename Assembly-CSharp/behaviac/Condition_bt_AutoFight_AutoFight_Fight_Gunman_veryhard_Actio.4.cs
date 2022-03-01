using System;

namespace behaviac
{
	// Token: 0x020021E7 RID: 8679
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node8 : Condition
	{
		// Token: 0x06012D5B RID: 77147 RVA: 0x0058B523 File Offset: 0x00589923
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D5C RID: 77148 RVA: 0x0058B558 File Offset: 0x00589958
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C74D RID: 51021
		private int opl_p0;

		// Token: 0x0400C74E RID: 51022
		private int opl_p1;

		// Token: 0x0400C74F RID: 51023
		private int opl_p2;

		// Token: 0x0400C750 RID: 51024
		private int opl_p3;
	}
}
