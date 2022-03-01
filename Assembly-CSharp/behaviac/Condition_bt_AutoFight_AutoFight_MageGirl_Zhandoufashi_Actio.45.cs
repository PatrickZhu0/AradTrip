using System;

namespace behaviac
{
	// Token: 0x0200273C RID: 10044
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node69 : Condition
	{
		// Token: 0x060137BA RID: 79802 RVA: 0x005CD8F2 File Offset: 0x005CBCF2
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node69()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 800;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060137BB RID: 79803 RVA: 0x005CD928 File Offset: 0x005CBD28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D213 RID: 53779
		private int opl_p0;

		// Token: 0x0400D214 RID: 53780
		private int opl_p1;

		// Token: 0x0400D215 RID: 53781
		private int opl_p2;

		// Token: 0x0400D216 RID: 53782
		private int opl_p3;
	}
}
