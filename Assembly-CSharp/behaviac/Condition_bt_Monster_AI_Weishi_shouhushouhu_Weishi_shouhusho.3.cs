using System;

namespace behaviac
{
	// Token: 0x02003DD0 RID: 15824
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node5 : Condition
	{
		// Token: 0x0601632F RID: 90927 RVA: 0x006B6234 File Offset: 0x006B4634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
