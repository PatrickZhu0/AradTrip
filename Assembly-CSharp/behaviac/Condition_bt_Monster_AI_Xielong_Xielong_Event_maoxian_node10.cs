using System;

namespace behaviac
{
	// Token: 0x02003E32 RID: 15922
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node10 : Condition
	{
		// Token: 0x060163EB RID: 91115 RVA: 0x006B9C38 File Offset: 0x006B8038
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shifangjineng = ((BTAgent)pAgent).shifangjineng2;
			int num = 0;
			bool flag = shifangjineng == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
