using System;

namespace behaviac
{
	// Token: 0x02003E3E RID: 15934
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node5 : Condition
	{
		// Token: 0x06016402 RID: 91138 RVA: 0x006BA4D0 File Offset: 0x006B88D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shifangjineng = ((BTAgent)pAgent).shifangjineng;
			int num = 0;
			bool flag = shifangjineng == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
