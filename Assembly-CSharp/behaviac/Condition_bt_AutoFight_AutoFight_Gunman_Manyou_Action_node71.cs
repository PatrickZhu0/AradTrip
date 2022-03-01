using System;

namespace behaviac
{
	// Token: 0x0200261E RID: 9758
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node71 : Condition
	{
		// Token: 0x06013582 RID: 79234 RVA: 0x005C124F File Offset: 0x005BF64F
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node71()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 800;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013583 RID: 79235 RVA: 0x005C1284 File Offset: 0x005BF684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFCB RID: 53195
		private int opl_p0;

		// Token: 0x0400CFCC RID: 53196
		private int opl_p1;

		// Token: 0x0400CFCD RID: 53197
		private int opl_p2;

		// Token: 0x0400CFCE RID: 53198
		private int opl_p3;
	}
}
