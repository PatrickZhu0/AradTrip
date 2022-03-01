using System;

namespace behaviac
{
	// Token: 0x020028B5 RID: 10421
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node37 : Condition
	{
		// Token: 0x06013AA4 RID: 80548 RVA: 0x005DF40E File Offset: 0x005DD80E
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node37()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013AA5 RID: 80549 RVA: 0x005DF424 File Offset: 0x005DD824
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D500 RID: 54528
		private float opl_p0;
	}
}
