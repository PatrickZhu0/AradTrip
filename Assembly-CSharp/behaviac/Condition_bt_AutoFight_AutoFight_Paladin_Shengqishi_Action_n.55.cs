using System;

namespace behaviac
{
	// Token: 0x0200285B RID: 10331
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node106 : Condition
	{
		// Token: 0x060139F4 RID: 80372 RVA: 0x005DA372 File Offset: 0x005D8772
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node106()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060139F5 RID: 80373 RVA: 0x005DA3A8 File Offset: 0x005D87A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D44C RID: 54348
		private int opl_p0;

		// Token: 0x0400D44D RID: 54349
		private int opl_p1;

		// Token: 0x0400D44E RID: 54350
		private int opl_p2;

		// Token: 0x0400D44F RID: 54351
		private int opl_p3;
	}
}
