using System;

namespace behaviac
{
	// Token: 0x02002910 RID: 10512
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node34 : Condition
	{
		// Token: 0x06013B56 RID: 80726 RVA: 0x005E3DB9 File Offset: 0x005E21B9
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node34()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013B57 RID: 80727 RVA: 0x005E3DCC File Offset: 0x005E21CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5BC RID: 54716
		private float opl_p0;
	}
}
