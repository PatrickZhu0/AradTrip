using System;

namespace behaviac
{
	// Token: 0x020026B5 RID: 9909
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node77 : Condition
	{
		// Token: 0x060136AD RID: 79533 RVA: 0x005C8856 File Offset: 0x005C6C56
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node77()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060136AE RID: 79534 RVA: 0x005C888C File Offset: 0x005C6C8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D101 RID: 53505
		private int opl_p0;

		// Token: 0x0400D102 RID: 53506
		private int opl_p1;

		// Token: 0x0400D103 RID: 53507
		private int opl_p2;

		// Token: 0x0400D104 RID: 53508
		private int opl_p3;
	}
}
