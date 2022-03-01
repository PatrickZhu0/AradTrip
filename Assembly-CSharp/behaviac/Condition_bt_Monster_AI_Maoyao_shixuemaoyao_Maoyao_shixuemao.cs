using System;

namespace behaviac
{
	// Token: 0x020035BC RID: 13756
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node6 : Condition
	{
		// Token: 0x060153A4 RID: 86948 RVA: 0x00666080 File Offset: 0x00664480
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int zhaohuan = ((BTAgent)pAgent).zhaohuan;
			int num = 0;
			bool flag = zhaohuan == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
