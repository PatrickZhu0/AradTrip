using System;

namespace behaviac
{
	// Token: 0x0200270E RID: 9998
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node98 : Condition
	{
		// Token: 0x0601375E RID: 79710 RVA: 0x005CC52B File Offset: 0x005CA92B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node98()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 230700;
		}

		// Token: 0x0601375F RID: 79711 RVA: 0x005CC54C File Offset: 0x005CA94C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1B6 RID: 53686
		private BE_Target opl_p0;

		// Token: 0x0400D1B7 RID: 53687
		private BE_Equal opl_p1;

		// Token: 0x0400D1B8 RID: 53688
		private int opl_p2;
	}
}
