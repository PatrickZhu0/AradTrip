using System;

namespace behaviac
{
	// Token: 0x02003B53 RID: 15187
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node21 : Condition
	{
		// Token: 0x06015E5B RID: 89691 RVA: 0x0069D8C7 File Offset: 0x0069BCC7
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node21()
		{
			this.opl_p0 = 21081;
		}

		// Token: 0x06015E5C RID: 89692 RVA: 0x0069D8DC File Offset: 0x0069BCDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F728 RID: 63272
		private int opl_p0;
	}
}
