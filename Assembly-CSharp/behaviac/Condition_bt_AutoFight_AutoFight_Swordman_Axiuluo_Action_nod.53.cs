using System;

namespace behaviac
{
	// Token: 0x020028DD RID: 10461
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node85 : Condition
	{
		// Token: 0x06013AF4 RID: 80628 RVA: 0x005E0726 File Offset: 0x005DEB26
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node85()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013AF5 RID: 80629 RVA: 0x005E073C File Offset: 0x005DEB3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D558 RID: 54616
		private float opl_p0;
	}
}
