using System;

namespace behaviac
{
	// Token: 0x02002EB0 RID: 11952
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node36 : Condition
	{
		// Token: 0x0601463B RID: 83515 RVA: 0x00621E90 File Offset: 0x00620290
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
