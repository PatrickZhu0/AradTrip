using System;

namespace behaviac
{
	// Token: 0x020034A0 RID: 13472
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node45 : Condition
	{
		// Token: 0x06015188 RID: 86408 RVA: 0x0065B68E File Offset: 0x00659A8E
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node45()
		{
			this.opl_p0 = 900000;
			this.opl_p1 = 900000;
			this.opl_p2 = 900000;
			this.opl_p3 = 900000;
		}

		// Token: 0x06015189 RID: 86409 RVA: 0x0065B6C4 File Offset: 0x00659AC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA88 RID: 60040
		private int opl_p0;

		// Token: 0x0400EA89 RID: 60041
		private int opl_p1;

		// Token: 0x0400EA8A RID: 60042
		private int opl_p2;

		// Token: 0x0400EA8B RID: 60043
		private int opl_p3;
	}
}
