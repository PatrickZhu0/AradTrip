using System;

namespace behaviac
{
	// Token: 0x02003B4D RID: 15181
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node0 : Condition
	{
		// Token: 0x06015E4F RID: 89679 RVA: 0x0069D6BF File Offset: 0x0069BABF
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node0()
		{
			this.opl_p0 = 21081;
		}

		// Token: 0x06015E50 RID: 89680 RVA: 0x0069D6D4 File Offset: 0x0069BAD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F71D RID: 63261
		private int opl_p0;
	}
}
