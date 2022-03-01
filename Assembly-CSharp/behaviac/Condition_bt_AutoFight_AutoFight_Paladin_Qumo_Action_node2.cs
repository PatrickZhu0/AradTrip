using System;

namespace behaviac
{
	// Token: 0x020027B3 RID: 10163
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node2 : Condition
	{
		// Token: 0x060138A5 RID: 80037 RVA: 0x005D405E File Offset: 0x005D245E
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 360702;
		}

		// Token: 0x060138A6 RID: 80038 RVA: 0x005D4080 File Offset: 0x005D2480
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D304 RID: 54020
		private BE_Target opl_p0;

		// Token: 0x0400D305 RID: 54021
		private BE_Equal opl_p1;

		// Token: 0x0400D306 RID: 54022
		private int opl_p2;
	}
}
