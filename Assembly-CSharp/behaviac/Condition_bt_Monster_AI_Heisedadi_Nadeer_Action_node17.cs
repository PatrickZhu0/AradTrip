using System;

namespace behaviac
{
	// Token: 0x020034DF RID: 13535
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node17 : Condition
	{
		// Token: 0x06015203 RID: 86531 RVA: 0x0065DB0F File Offset: 0x0065BF0F
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06015204 RID: 86532 RVA: 0x0065DB44 File Offset: 0x0065BF44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB1A RID: 60186
		private int opl_p0;

		// Token: 0x0400EB1B RID: 60187
		private int opl_p1;

		// Token: 0x0400EB1C RID: 60188
		private int opl_p2;

		// Token: 0x0400EB1D RID: 60189
		private int opl_p3;
	}
}
