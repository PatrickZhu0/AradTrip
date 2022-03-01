using System;

namespace behaviac
{
	// Token: 0x02003C81 RID: 15489
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node5 : Condition
	{
		// Token: 0x060160A9 RID: 90281 RVA: 0x006A9247 File Offset: 0x006A7647
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node5()
		{
			this.opl_p0 = 10000;
		}

		// Token: 0x060160AA RID: 90282 RVA: 0x006A925C File Offset: 0x006A765C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckYDis(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F93F RID: 63807
		private int opl_p0;
	}
}
