using System;

namespace behaviac
{
	// Token: 0x02002704 RID: 9988
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node10 : Condition
	{
		// Token: 0x0601374A RID: 79690 RVA: 0x005CC11B File Offset: 0x005CA51B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node10()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 211301;
		}

		// Token: 0x0601374B RID: 79691 RVA: 0x005CC13C File Offset: 0x005CA53C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1A1 RID: 53665
		private BE_Target opl_p0;

		// Token: 0x0400D1A2 RID: 53666
		private BE_Equal opl_p1;

		// Token: 0x0400D1A3 RID: 53667
		private int opl_p2;
	}
}
