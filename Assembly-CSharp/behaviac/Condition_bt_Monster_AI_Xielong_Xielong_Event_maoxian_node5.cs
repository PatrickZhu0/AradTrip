using System;

namespace behaviac
{
	// Token: 0x02003E2C RID: 15916
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node5 : Condition
	{
		// Token: 0x060163DF RID: 91103 RVA: 0x006B9A24 File Offset: 0x006B7E24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shifangjineng = ((BTAgent)pAgent).shifangjineng;
			int num = 0;
			bool flag = shifangjineng == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
