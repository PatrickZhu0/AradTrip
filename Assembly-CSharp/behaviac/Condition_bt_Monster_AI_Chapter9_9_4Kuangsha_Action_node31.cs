using System;

namespace behaviac
{
	// Token: 0x02003189 RID: 12681
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node31 : Condition
	{
		// Token: 0x06014BA9 RID: 84905 RVA: 0x0063DB05 File Offset: 0x0063BF05
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node31()
		{
			this.opl_p0 = 21544;
		}

		// Token: 0x06014BAA RID: 84906 RVA: 0x0063DB18 File Offset: 0x0063BF18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E517 RID: 58647
		private int opl_p0;
	}
}
