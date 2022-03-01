using System;

namespace behaviac
{
	// Token: 0x020035C1 RID: 13761
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node11 : Condition
	{
		// Token: 0x060153AE RID: 86958 RVA: 0x00666234 File Offset: 0x00664634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int zhaohuan = ((BTAgent)pAgent).zhaohuan;
			int num = 1;
			bool flag = zhaohuan == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
