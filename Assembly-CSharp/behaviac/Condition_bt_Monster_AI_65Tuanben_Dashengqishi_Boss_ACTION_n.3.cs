using System;

namespace behaviac
{
	// Token: 0x02002D89 RID: 11657
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node15 : Condition
	{
		// Token: 0x060143F3 RID: 82931 RVA: 0x006155D3 File Offset: 0x006139D3
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node15()
		{
			this.opl_p0 = 21646;
		}

		// Token: 0x060143F4 RID: 82932 RVA: 0x006155E8 File Offset: 0x006139E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDC4 RID: 56772
		private int opl_p0;
	}
}
