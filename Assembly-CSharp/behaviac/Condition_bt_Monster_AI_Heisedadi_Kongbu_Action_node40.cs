using System;

namespace behaviac
{
	// Token: 0x020034A3 RID: 13475
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node40 : Condition
	{
		// Token: 0x0601518E RID: 86414 RVA: 0x0065B7FA File Offset: 0x00659BFA
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node40()
		{
			this.opl_p0 = 900000;
			this.opl_p1 = 900000;
			this.opl_p2 = 900000;
			this.opl_p3 = 900000;
		}

		// Token: 0x0601518F RID: 86415 RVA: 0x0065B830 File Offset: 0x00659C30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA8F RID: 60047
		private int opl_p0;

		// Token: 0x0400EA90 RID: 60048
		private int opl_p1;

		// Token: 0x0400EA91 RID: 60049
		private int opl_p2;

		// Token: 0x0400EA92 RID: 60050
		private int opl_p3;
	}
}
