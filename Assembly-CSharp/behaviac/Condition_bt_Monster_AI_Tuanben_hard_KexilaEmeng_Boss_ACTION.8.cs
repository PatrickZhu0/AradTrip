using System;

namespace behaviac
{
	// Token: 0x02003B95 RID: 15253
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node98 : Condition
	{
		// Token: 0x06015EDA RID: 89818 RVA: 0x006A02D7 File Offset: 0x0069E6D7
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node98()
		{
			this.opl_p0 = 21174;
		}

		// Token: 0x06015EDB RID: 89819 RVA: 0x006A02EC File Offset: 0x0069E6EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F78D RID: 63373
		private int opl_p0;
	}
}
