using System;

namespace behaviac
{
	// Token: 0x02002709 RID: 9993
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node79 : Condition
	{
		// Token: 0x06013754 RID: 79700 RVA: 0x005CC32F File Offset: 0x005CA72F
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node79()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 230300;
		}

		// Token: 0x06013755 RID: 79701 RVA: 0x005CC350 File Offset: 0x005CA750
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1AC RID: 53676
		private BE_Target opl_p0;

		// Token: 0x0400D1AD RID: 53677
		private BE_Equal opl_p1;

		// Token: 0x0400D1AE RID: 53678
		private int opl_p2;
	}
}
