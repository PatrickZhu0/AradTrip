using System;

namespace behaviac
{
	// Token: 0x02003BE4 RID: 15332
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node55 : Condition
	{
		// Token: 0x06015F75 RID: 89973 RVA: 0x006A2F2F File Offset: 0x006A132F
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node55()
		{
			this.opl_p0 = 21170;
		}

		// Token: 0x06015F76 RID: 89974 RVA: 0x006A2F44 File Offset: 0x006A1344
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F811 RID: 63505
		private int opl_p0;
	}
}
