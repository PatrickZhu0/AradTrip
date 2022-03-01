using System;

namespace behaviac
{
	// Token: 0x02003E37 RID: 15927
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node16 : Condition
	{
		// Token: 0x060163F5 RID: 91125 RVA: 0x006B9DEC File Offset: 0x006B81EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shifangjineng = ((BTAgent)pAgent).shifangjineng3;
			int num = 0;
			bool flag = shifangjineng == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
