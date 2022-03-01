using System;

namespace behaviac
{
	// Token: 0x020039CF RID: 14799
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node45 : Condition
	{
		// Token: 0x06015B6F RID: 88943 RVA: 0x0068F078 File Offset: 0x0068D478
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
