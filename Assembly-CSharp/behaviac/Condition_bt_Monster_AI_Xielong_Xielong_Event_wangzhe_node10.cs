using System;

namespace behaviac
{
	// Token: 0x02003E56 RID: 15958
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node10 : Condition
	{
		// Token: 0x06016431 RID: 91185 RVA: 0x006BB190 File Offset: 0x006B9590
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shifangjineng = ((BTAgent)pAgent).shifangjineng2;
			int num = 0;
			bool flag = shifangjineng == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
