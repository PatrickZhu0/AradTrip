using System;

namespace behaviac
{
	// Token: 0x02003E50 RID: 15952
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node5 : Condition
	{
		// Token: 0x06016425 RID: 91173 RVA: 0x006BAF7C File Offset: 0x006B937C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shifangjineng = ((BTAgent)pAgent).shifangjineng;
			int num = 0;
			bool flag = shifangjineng == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
