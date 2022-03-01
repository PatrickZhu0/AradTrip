using System;

namespace behaviac
{
	// Token: 0x020029F0 RID: 10736
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node19 : Condition
	{
		// Token: 0x06013D13 RID: 81171 RVA: 0x005EE5B1 File Offset: 0x005EC9B1
		public Condition_bt_BOSS_BOSS20_4_Action_node19()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013D14 RID: 81172 RVA: 0x005EE5C4 File Offset: 0x005EC9C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D788 RID: 55176
		private float opl_p0;
	}
}
