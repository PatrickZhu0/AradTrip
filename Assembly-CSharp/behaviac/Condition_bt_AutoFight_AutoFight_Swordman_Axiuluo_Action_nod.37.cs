using System;

namespace behaviac
{
	// Token: 0x020028C8 RID: 10440
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node94 : Condition
	{
		// Token: 0x06013ACA RID: 80586 RVA: 0x005DFC5A File Offset: 0x005DE05A
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node94()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013ACB RID: 80587 RVA: 0x005DFC70 File Offset: 0x005DE070
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D529 RID: 54569
		private float opl_p0;
	}
}
