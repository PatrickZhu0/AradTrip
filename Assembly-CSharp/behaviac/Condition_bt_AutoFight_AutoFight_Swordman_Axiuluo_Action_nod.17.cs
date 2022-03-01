using System;

namespace behaviac
{
	// Token: 0x020028AE RID: 10414
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node19 : Condition
	{
		// Token: 0x06013A96 RID: 80534 RVA: 0x005DF125 File Offset: 0x005DD525
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node19()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013A97 RID: 80535 RVA: 0x005DF138 File Offset: 0x005DD538
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4F4 RID: 54516
		private float opl_p0;
	}
}
