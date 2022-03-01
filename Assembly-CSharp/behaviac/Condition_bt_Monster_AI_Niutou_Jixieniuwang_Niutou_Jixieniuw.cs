using System;

namespace behaviac
{
	// Token: 0x020036F8 RID: 14072
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node6 : Condition
	{
		// Token: 0x06015600 RID: 87552 RVA: 0x00672F6C File Offset: 0x0067136C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int zhaohuan = ((BTAgent)pAgent).zhaohuan;
			int num = 0;
			bool flag = zhaohuan == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
