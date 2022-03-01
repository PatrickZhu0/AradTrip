using System;

namespace behaviac
{
	// Token: 0x020026C1 RID: 9921
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node59 : Condition
	{
		// Token: 0x060136C5 RID: 79557 RVA: 0x005C8D86 File Offset: 0x005C7186
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node59()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060136C6 RID: 79558 RVA: 0x005C8DBC File Offset: 0x005C71BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D11B RID: 53531
		private int opl_p0;

		// Token: 0x0400D11C RID: 53532
		private int opl_p1;

		// Token: 0x0400D11D RID: 53533
		private int opl_p2;

		// Token: 0x0400D11E RID: 53534
		private int opl_p3;
	}
}
