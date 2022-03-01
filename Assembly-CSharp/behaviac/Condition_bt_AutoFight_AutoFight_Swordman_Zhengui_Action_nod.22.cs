using System;

namespace behaviac
{
	// Token: 0x02002999 RID: 10649
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node127 : Condition
	{
		// Token: 0x06013C66 RID: 80998 RVA: 0x005EA42E File Offset: 0x005E882E
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node127()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 181101;
		}

		// Token: 0x06013C67 RID: 80999 RVA: 0x005EA450 File Offset: 0x005E8850
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6D0 RID: 54992
		private BE_Target opl_p0;

		// Token: 0x0400D6D1 RID: 54993
		private BE_Equal opl_p1;

		// Token: 0x0400D6D2 RID: 54994
		private int opl_p2;
	}
}
