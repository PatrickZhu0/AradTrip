using System;

namespace behaviac
{
	// Token: 0x020036FC RID: 14076
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node10 : Condition
	{
		// Token: 0x06015608 RID: 87560 RVA: 0x00673094 File Offset: 0x00671494
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int zhaohuan = ((BTAgent)pAgent).zhaohuan;
			int num = 1;
			bool flag = zhaohuan == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
