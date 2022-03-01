using System;

namespace behaviac
{
	// Token: 0x02003A7B RID: 14971
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node60 : Condition
	{
		// Token: 0x06015CBF RID: 89279 RVA: 0x00694DF5 File Offset: 0x006931F5
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node60()
		{
			this.opl_p0 = 21052;
		}

		// Token: 0x06015CC0 RID: 89280 RVA: 0x00694E08 File Offset: 0x00693208
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5FB RID: 62971
		private int opl_p0;
	}
}
