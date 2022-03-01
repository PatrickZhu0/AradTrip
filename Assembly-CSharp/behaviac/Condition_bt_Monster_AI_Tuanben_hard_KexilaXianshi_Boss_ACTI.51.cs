using System;

namespace behaviac
{
	// Token: 0x02003CAA RID: 15530
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node69 : Condition
	{
		// Token: 0x060160FB RID: 90363 RVA: 0x006AA46F File Offset: 0x006A886F
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node69()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060160FC RID: 90364 RVA: 0x006AA484 File Offset: 0x006A8884
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9A2 RID: 63906
		private float opl_p0;
	}
}
