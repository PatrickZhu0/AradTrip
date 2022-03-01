using System;

namespace behaviac
{
	// Token: 0x02002847 RID: 10311
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node8 : Condition
	{
		// Token: 0x060139CC RID: 80332 RVA: 0x005D9AEE File Offset: 0x005D7EEE
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node8()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060139CD RID: 80333 RVA: 0x005D9B24 File Offset: 0x005D7F24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D424 RID: 54308
		private int opl_p0;

		// Token: 0x0400D425 RID: 54309
		private int opl_p1;

		// Token: 0x0400D426 RID: 54310
		private int opl_p2;

		// Token: 0x0400D427 RID: 54311
		private int opl_p3;
	}
}
