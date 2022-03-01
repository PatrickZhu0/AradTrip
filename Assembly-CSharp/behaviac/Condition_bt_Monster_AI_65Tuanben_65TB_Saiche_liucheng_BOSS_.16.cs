using System;

namespace behaviac
{
	// Token: 0x02002BFC RID: 11260
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node79 : Condition
	{
		// Token: 0x060140F8 RID: 82168 RVA: 0x006059E8 File Offset: 0x00603DE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 6;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
