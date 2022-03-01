using System;

namespace behaviac
{
	// Token: 0x02002610 RID: 9744
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node53 : Condition
	{
		// Token: 0x06013566 RID: 79206 RVA: 0x005C0BEB File Offset: 0x005BEFEB
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node53()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x06013567 RID: 79207 RVA: 0x005C0C20 File Offset: 0x005BF020
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFB1 RID: 53169
		private int opl_p0;

		// Token: 0x0400CFB2 RID: 53170
		private int opl_p1;

		// Token: 0x0400CFB3 RID: 53171
		private int opl_p2;

		// Token: 0x0400CFB4 RID: 53172
		private int opl_p3;
	}
}
