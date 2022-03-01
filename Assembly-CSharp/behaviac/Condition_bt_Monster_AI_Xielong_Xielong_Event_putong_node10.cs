using System;

namespace behaviac
{
	// Token: 0x02003E44 RID: 15940
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node10 : Condition
	{
		// Token: 0x0601640E RID: 91150 RVA: 0x006BA6E4 File Offset: 0x006B8AE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shifangjineng = ((BTAgent)pAgent).shifangjineng2;
			int num = 0;
			bool flag = shifangjineng == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
