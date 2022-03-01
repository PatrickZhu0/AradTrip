using System;

namespace behaviac
{
	// Token: 0x02002EBE RID: 11966
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node55 : Condition
	{
		// Token: 0x06014656 RID: 83542 RVA: 0x00622357 File Offset: 0x00620757
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node55()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06014657 RID: 83543 RVA: 0x00622368 File Offset: 0x00620768
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFC6 RID: 57286
		private int opl_p0;
	}
}
