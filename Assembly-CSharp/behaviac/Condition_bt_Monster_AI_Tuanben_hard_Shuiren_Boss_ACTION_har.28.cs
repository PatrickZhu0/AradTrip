using System;

namespace behaviac
{
	// Token: 0x02003D67 RID: 15719
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node48 : Condition
	{
		// Token: 0x06016264 RID: 90724 RVA: 0x006B15C2 File Offset: 0x006AF9C2
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node48()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x06016265 RID: 90725 RVA: 0x006B15D8 File Offset: 0x006AF9D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FABF RID: 64191
		private float opl_p0;
	}
}
