using System;

namespace behaviac
{
	// Token: 0x02003E49 RID: 15945
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node16 : Condition
	{
		// Token: 0x06016418 RID: 91160 RVA: 0x006BA898 File Offset: 0x006B8C98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shifangjineng = ((BTAgent)pAgent).shifangjineng3;
			int num = 0;
			bool flag = shifangjineng == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
