using System;

namespace behaviac
{
	// Token: 0x020039FF RID: 14847
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node91 : Assignment
	{
		// Token: 0x06015BCD RID: 89037 RVA: 0x00690CDC File Offset: 0x0068F0DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
