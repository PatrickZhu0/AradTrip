using System;

namespace behaviac
{
	// Token: 0x02003DEB RID: 15851
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node10 : Condition
	{
		// Token: 0x06016363 RID: 90979 RVA: 0x006B6FC8 File Offset: 0x006B53C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
