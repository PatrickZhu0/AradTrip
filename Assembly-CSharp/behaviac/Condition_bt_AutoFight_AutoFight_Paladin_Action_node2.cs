using System;

namespace behaviac
{
	// Token: 0x02002787 RID: 10119
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node2 : Condition
	{
		// Token: 0x0601384E RID: 79950 RVA: 0x005D2058 File Offset: 0x005D0458
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 350801;
		}

		// Token: 0x0601384F RID: 79951 RVA: 0x005D207C File Offset: 0x005D047C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2AE RID: 53934
		private BE_Target opl_p0;

		// Token: 0x0400D2AF RID: 53935
		private BE_Equal opl_p1;

		// Token: 0x0400D2B0 RID: 53936
		private int opl_p2;
	}
}
