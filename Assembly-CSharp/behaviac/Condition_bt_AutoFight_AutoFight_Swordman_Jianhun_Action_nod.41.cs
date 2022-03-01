using System;

namespace behaviac
{
	// Token: 0x0200293B RID: 10555
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node26 : Condition
	{
		// Token: 0x06013BAC RID: 80812 RVA: 0x005E5571 File Offset: 0x005E3971
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node26()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013BAD RID: 80813 RVA: 0x005E5584 File Offset: 0x005E3984
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D613 RID: 54803
		private float opl_p0;
	}
}
