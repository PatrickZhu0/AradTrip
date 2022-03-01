using System;

namespace behaviac
{
	// Token: 0x0200317F RID: 12671
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node52 : Condition
	{
		// Token: 0x06014B95 RID: 84885 RVA: 0x0063D6DD File Offset: 0x0063BADD
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node52()
		{
			this.opl_p0 = 21541;
		}

		// Token: 0x06014B96 RID: 84886 RVA: 0x0063D6F0 File Offset: 0x0063BAF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E501 RID: 58625
		private int opl_p0;
	}
}
