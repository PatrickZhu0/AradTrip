using System;

namespace behaviac
{
	// Token: 0x02003E62 RID: 15970
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node5 : Condition
	{
		// Token: 0x06016448 RID: 91208 RVA: 0x006BBA28 File Offset: 0x006B9E28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shifangjineng = ((BTAgent)pAgent).shifangjineng;
			int num = 0;
			bool flag = shifangjineng == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
