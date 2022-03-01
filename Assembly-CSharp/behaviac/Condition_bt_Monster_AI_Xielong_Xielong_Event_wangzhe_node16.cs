using System;

namespace behaviac
{
	// Token: 0x02003E5B RID: 15963
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node16 : Condition
	{
		// Token: 0x0601643B RID: 91195 RVA: 0x006BB344 File Offset: 0x006B9744
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shifangjineng = ((BTAgent)pAgent).shifangjineng3;
			int num = 0;
			bool flag = shifangjineng == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
