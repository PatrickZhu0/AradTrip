using System;

namespace behaviac
{
	// Token: 0x020026E6 RID: 9958
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node42 : Condition
	{
		// Token: 0x0601370F RID: 79631 RVA: 0x005C9D12 File Offset: 0x005C8112
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node42()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013710 RID: 79632 RVA: 0x005C9D48 File Offset: 0x005C8148
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D165 RID: 53605
		private int opl_p0;

		// Token: 0x0400D166 RID: 53606
		private int opl_p1;

		// Token: 0x0400D167 RID: 53607
		private int opl_p2;

		// Token: 0x0400D168 RID: 53608
		private int opl_p3;
	}
}
