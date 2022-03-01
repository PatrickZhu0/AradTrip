using System;

namespace behaviac
{
	// Token: 0x020036FF RID: 14079
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node13 : Assignment
	{
		// Token: 0x0601560E RID: 87566 RVA: 0x00673194 File Offset: 0x00671594
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int zhaohuan = 2;
			((BTAgent)pAgent).zhaohuan = zhaohuan;
			return result;
		}
	}
}
