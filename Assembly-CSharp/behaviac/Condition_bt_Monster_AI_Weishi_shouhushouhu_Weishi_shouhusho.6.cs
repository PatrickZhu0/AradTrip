using System;

namespace behaviac
{
	// Token: 0x02003DD5 RID: 15829
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node10 : Condition
	{
		// Token: 0x06016339 RID: 90937 RVA: 0x006B63B8 File Offset: 0x006B47B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
