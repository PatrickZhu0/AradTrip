using System;

namespace behaviac
{
	// Token: 0x02002BD0 RID: 11216
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node22 : Condition
	{
		// Token: 0x060140A0 RID: 82080 RVA: 0x00604DA4 File Offset: 0x006031A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
