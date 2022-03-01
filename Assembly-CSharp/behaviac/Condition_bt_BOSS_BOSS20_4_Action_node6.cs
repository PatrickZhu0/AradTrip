using System;

namespace behaviac
{
	// Token: 0x020029E5 RID: 10725
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node6 : Condition
	{
		// Token: 0x06013CFD RID: 81149 RVA: 0x005EE0DB File Offset: 0x005EC4DB
		public Condition_bt_BOSS_BOSS20_4_Action_node6()
		{
			this.opl_p0 = 5520;
		}

		// Token: 0x06013CFE RID: 81150 RVA: 0x005EE0F0 File Offset: 0x005EC4F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D771 RID: 55153
		private int opl_p0;
	}
}
