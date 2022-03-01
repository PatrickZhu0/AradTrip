using System;

namespace behaviac
{
	// Token: 0x020025F4 RID: 9716
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node3 : Condition
	{
		// Token: 0x0601352E RID: 79150 RVA: 0x005BFF57 File Offset: 0x005BE357
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node3()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601352F RID: 79151 RVA: 0x005BFF8C File Offset: 0x005BE38C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF75 RID: 53109
		private int opl_p0;

		// Token: 0x0400CF76 RID: 53110
		private int opl_p1;

		// Token: 0x0400CF77 RID: 53111
		private int opl_p2;

		// Token: 0x0400CF78 RID: 53112
		private int opl_p3;
	}
}
