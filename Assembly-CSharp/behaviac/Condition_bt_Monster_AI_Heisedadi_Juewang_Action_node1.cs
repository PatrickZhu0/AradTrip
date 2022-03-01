using System;

namespace behaviac
{
	// Token: 0x0200346D RID: 13421
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node1 : Condition
	{
		// Token: 0x06015125 RID: 86309 RVA: 0x00659717 File Offset: 0x00657B17
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 560001;
		}

		// Token: 0x06015126 RID: 86310 RVA: 0x00659738 File Offset: 0x00657B38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA26 RID: 59942
		private BE_Target opl_p0;

		// Token: 0x0400EA27 RID: 59943
		private BE_Equal opl_p1;

		// Token: 0x0400EA28 RID: 59944
		private int opl_p2;
	}
}
