using System;

namespace behaviac
{
	// Token: 0x020029F5 RID: 10741
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node25 : Condition
	{
		// Token: 0x06013D1D RID: 81181 RVA: 0x005EE7AB File Offset: 0x005ECBAB
		public Condition_bt_BOSS_BOSS20_4_Action_node25()
		{
			this.opl_p0 = 5313;
		}

		// Token: 0x06013D1E RID: 81182 RVA: 0x005EE7C0 File Offset: 0x005ECBC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D791 RID: 55185
		private int opl_p0;
	}
}
