using System;

namespace behaviac
{
	// Token: 0x02004095 RID: 16533
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node6 : Condition
	{
		// Token: 0x06016885 RID: 92293 RVA: 0x006D2925 File Offset: 0x006D0D25
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node6()
		{
			this.opl_p0 = 5354;
		}

		// Token: 0x06016886 RID: 92294 RVA: 0x006D2938 File Offset: 0x006D0D38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100CF RID: 65743
		private int opl_p0;
	}
}
