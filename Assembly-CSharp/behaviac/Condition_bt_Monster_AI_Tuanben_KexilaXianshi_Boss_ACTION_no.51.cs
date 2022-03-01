using System;

namespace behaviac
{
	// Token: 0x02003A78 RID: 14968
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node69 : Condition
	{
		// Token: 0x06015CB9 RID: 89273 RVA: 0x00694C87 File Offset: 0x00693087
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node69()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06015CBA RID: 89274 RVA: 0x00694C9C File Offset: 0x0069309C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5F4 RID: 62964
		private float opl_p0;
	}
}
