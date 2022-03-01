using System;

namespace behaviac
{
	// Token: 0x02003BE5 RID: 15333
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node61 : Condition
	{
		// Token: 0x06015F77 RID: 89975 RVA: 0x006A2F77 File Offset: 0x006A1377
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node61()
		{
			this.opl_p0 = 21074;
		}

		// Token: 0x06015F78 RID: 89976 RVA: 0x006A2F8C File Offset: 0x006A138C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F812 RID: 63506
		private int opl_p0;
	}
}
