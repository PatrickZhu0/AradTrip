using System;

namespace behaviac
{
	// Token: 0x02003D4D RID: 15693
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node21 : Condition
	{
		// Token: 0x06016230 RID: 90672 RVA: 0x006B0CB7 File Offset: 0x006AF0B7
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node21()
		{
			this.opl_p0 = 21081;
		}

		// Token: 0x06016231 RID: 90673 RVA: 0x006B0CCC File Offset: 0x006AF0CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA91 RID: 64145
		private int opl_p0;
	}
}
