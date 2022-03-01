using System;

namespace behaviac
{
	// Token: 0x02003DF1 RID: 15857
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node5 : Condition
	{
		// Token: 0x0601636E RID: 90990 RVA: 0x006B744C File Offset: 0x006B584C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
