using System;

namespace behaviac
{
	// Token: 0x0200262A RID: 9770
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node81 : Condition
	{
		// Token: 0x0601359A RID: 79258 RVA: 0x005C17BB File Offset: 0x005BFBBB
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node81()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601359B RID: 79259 RVA: 0x005C17F0 File Offset: 0x005BFBF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFE7 RID: 53223
		private int opl_p0;

		// Token: 0x0400CFE8 RID: 53224
		private int opl_p1;

		// Token: 0x0400CFE9 RID: 53225
		private int opl_p2;

		// Token: 0x0400CFEA RID: 53226
		private int opl_p3;
	}
}
