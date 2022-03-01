using System;

namespace behaviac
{
	// Token: 0x020034A6 RID: 13478
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node28 : Condition
	{
		// Token: 0x06015194 RID: 86420 RVA: 0x0065B966 File Offset: 0x00659D66
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node28()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06015195 RID: 86421 RVA: 0x0065B99C File Offset: 0x00659D9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA96 RID: 60054
		private int opl_p0;

		// Token: 0x0400EA97 RID: 60055
		private int opl_p1;

		// Token: 0x0400EA98 RID: 60056
		private int opl_p2;

		// Token: 0x0400EA99 RID: 60057
		private int opl_p3;
	}
}
