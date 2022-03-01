using System;

namespace behaviac
{
	// Token: 0x02003C05 RID: 15365
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node46 : Condition
	{
		// Token: 0x06015FB5 RID: 90037 RVA: 0x006A48CB File Offset: 0x006A2CCB
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node46()
		{
			this.opl_p0 = 21164;
		}

		// Token: 0x06015FB6 RID: 90038 RVA: 0x006A48E0 File Offset: 0x006A2CE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F839 RID: 63545
		private int opl_p0;
	}
}
