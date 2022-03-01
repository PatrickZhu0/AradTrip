using System;

namespace behaviac
{
	// Token: 0x020028A4 RID: 10404
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node29 : Condition
	{
		// Token: 0x06013A82 RID: 80514 RVA: 0x005DEC8A File Offset: 0x005DD08A
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node29()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013A83 RID: 80515 RVA: 0x005DECA0 File Offset: 0x005DD0A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4DD RID: 54493
		private float opl_p0;
	}
}
