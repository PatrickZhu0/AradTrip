using System;

namespace behaviac
{
	// Token: 0x020026EE RID: 9966
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node11 : Condition
	{
		// Token: 0x0601371F RID: 79647 RVA: 0x005CA07A File Offset: 0x005C847A
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node11()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013720 RID: 79648 RVA: 0x005CA0B0 File Offset: 0x005C84B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D175 RID: 53621
		private int opl_p0;

		// Token: 0x0400D176 RID: 53622
		private int opl_p1;

		// Token: 0x0400D177 RID: 53623
		private int opl_p2;

		// Token: 0x0400D178 RID: 53624
		private int opl_p3;
	}
}
