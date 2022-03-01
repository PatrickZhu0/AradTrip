using System;

namespace behaviac
{
	// Token: 0x020036FB RID: 14075
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node9 : Assignment
	{
		// Token: 0x06015606 RID: 87558 RVA: 0x0067306C File Offset: 0x0067146C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int zhaohuan = 1;
			((BTAgent)pAgent).zhaohuan = zhaohuan;
			return result;
		}
	}
}
