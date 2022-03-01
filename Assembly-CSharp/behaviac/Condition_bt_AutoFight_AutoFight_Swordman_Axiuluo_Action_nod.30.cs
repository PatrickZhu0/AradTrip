using System;

namespace behaviac
{
	// Token: 0x020028BF RID: 10431
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node48 : Condition
	{
		// Token: 0x06013AB8 RID: 80568 RVA: 0x005DF836 File Offset: 0x005DDC36
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node48()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013AB9 RID: 80569 RVA: 0x005DF84C File Offset: 0x005DDC4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D516 RID: 54550
		private float opl_p0;
	}
}
