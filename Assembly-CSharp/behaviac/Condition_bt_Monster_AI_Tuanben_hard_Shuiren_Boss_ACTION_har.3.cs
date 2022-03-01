using System;

namespace behaviac
{
	// Token: 0x02003D3D RID: 15677
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node64 : Condition
	{
		// Token: 0x06016211 RID: 90641 RVA: 0x006B0858 File Offset: 0x006AEC58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
