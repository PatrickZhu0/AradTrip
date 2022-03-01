using System;

namespace behaviac
{
	// Token: 0x020040CB RID: 16587
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_ActionBT_node1 : Condition
	{
		// Token: 0x060168EC RID: 92396 RVA: 0x006D4CEB File Offset: 0x006D30EB
		public Condition_bt_ActionBT_node1()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060168ED RID: 92397 RVA: 0x006D4D20 File Offset: 0x006D3120
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010131 RID: 65841
		private int opl_p0;

		// Token: 0x04010132 RID: 65842
		private int opl_p1;

		// Token: 0x04010133 RID: 65843
		private int opl_p2;

		// Token: 0x04010134 RID: 65844
		private int opl_p3;
	}
}
