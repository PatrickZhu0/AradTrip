using System;

namespace behaviac
{
	// Token: 0x020027A7 RID: 10151
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node32 : Condition
	{
		// Token: 0x0601388E RID: 80014 RVA: 0x005D2DE2 File Offset: 0x005D11E2
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node32()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601388F RID: 80015 RVA: 0x005D2E18 File Offset: 0x005D1218
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2ED RID: 53997
		private int opl_p0;

		// Token: 0x0400D2EE RID: 53998
		private int opl_p1;

		// Token: 0x0400D2EF RID: 53999
		private int opl_p2;

		// Token: 0x0400D2F0 RID: 54000
		private int opl_p3;
	}
}
