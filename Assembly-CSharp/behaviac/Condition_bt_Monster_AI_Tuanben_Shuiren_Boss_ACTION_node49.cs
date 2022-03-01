using System;

namespace behaviac
{
	// Token: 0x02003B6E RID: 15214
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node49 : Condition
	{
		// Token: 0x06015E91 RID: 89745 RVA: 0x0069E21B File Offset: 0x0069C61B
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node49()
		{
			this.opl_p0 = 21083;
		}

		// Token: 0x06015E92 RID: 89746 RVA: 0x0069E230 File Offset: 0x0069C630
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F757 RID: 63319
		private int opl_p0;
	}
}
