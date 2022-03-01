using System;

namespace behaviac
{
	// Token: 0x02002823 RID: 10275
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node51 : Condition
	{
		// Token: 0x06013984 RID: 80260 RVA: 0x005D8BCA File Offset: 0x005D6FCA
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node51()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 370400;
		}

		// Token: 0x06013985 RID: 80261 RVA: 0x005D8BEC File Offset: 0x005D6FEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3DE RID: 54238
		private BE_Target opl_p0;

		// Token: 0x0400D3DF RID: 54239
		private BE_Equal opl_p1;

		// Token: 0x0400D3E0 RID: 54240
		private int opl_p2;
	}
}
