using System;

namespace behaviac
{
	// Token: 0x02003D47 RID: 15687
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node0 : Condition
	{
		// Token: 0x06016224 RID: 90660 RVA: 0x006B0AAF File Offset: 0x006AEEAF
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node0()
		{
			this.opl_p0 = 21081;
		}

		// Token: 0x06016225 RID: 90661 RVA: 0x006B0AC4 File Offset: 0x006AEEC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA86 RID: 64134
		private int opl_p0;
	}
}
