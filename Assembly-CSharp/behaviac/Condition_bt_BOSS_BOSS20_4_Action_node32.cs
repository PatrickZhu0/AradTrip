using System;

namespace behaviac
{
	// Token: 0x020029E9 RID: 10729
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node32 : Condition
	{
		// Token: 0x06013D05 RID: 81157 RVA: 0x005EE28F File Offset: 0x005EC68F
		public Condition_bt_BOSS_BOSS20_4_Action_node32()
		{
			this.opl_p0 = 5519;
		}

		// Token: 0x06013D06 RID: 81158 RVA: 0x005EE2A4 File Offset: 0x005EC6A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D779 RID: 55161
		private int opl_p0;
	}
}
