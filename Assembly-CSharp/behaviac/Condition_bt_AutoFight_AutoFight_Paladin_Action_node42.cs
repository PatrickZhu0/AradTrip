using System;

namespace behaviac
{
	// Token: 0x020027AF RID: 10159
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node42 : Condition
	{
		// Token: 0x0601389E RID: 80030 RVA: 0x005D31A6 File Offset: 0x005D15A6
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node42()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601389F RID: 80031 RVA: 0x005D31DC File Offset: 0x005D15DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2FD RID: 54013
		private int opl_p0;

		// Token: 0x0400D2FE RID: 54014
		private int opl_p1;

		// Token: 0x0400D2FF RID: 54015
		private int opl_p2;

		// Token: 0x0400D300 RID: 54016
		private int opl_p3;
	}
}
