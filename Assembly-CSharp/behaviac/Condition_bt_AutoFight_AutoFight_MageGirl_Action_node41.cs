using System;

namespace behaviac
{
	// Token: 0x020026AD RID: 9901
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node41 : Condition
	{
		// Token: 0x0601369E RID: 79518 RVA: 0x005C7747 File Offset: 0x005C5B47
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node41()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601369F RID: 79519 RVA: 0x005C777C File Offset: 0x005C5B7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0F0 RID: 53488
		private int opl_p0;

		// Token: 0x0400D0F1 RID: 53489
		private int opl_p1;

		// Token: 0x0400D0F2 RID: 53490
		private int opl_p2;

		// Token: 0x0400D0F3 RID: 53491
		private int opl_p3;
	}
}
