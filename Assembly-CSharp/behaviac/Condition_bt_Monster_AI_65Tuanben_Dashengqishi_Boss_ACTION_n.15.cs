using System;

namespace behaviac
{
	// Token: 0x02002D9D RID: 11677
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node36 : Condition
	{
		// Token: 0x0601441B RID: 82971 RVA: 0x00615CDF File Offset: 0x006140DF
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node36()
		{
			this.opl_p0 = 21645;
		}

		// Token: 0x0601441C RID: 82972 RVA: 0x00615CF4 File Offset: 0x006140F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDE3 RID: 56803
		private int opl_p0;
	}
}
