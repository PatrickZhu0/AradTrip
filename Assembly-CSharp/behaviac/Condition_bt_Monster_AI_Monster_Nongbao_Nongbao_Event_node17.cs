using System;

namespace behaviac
{
	// Token: 0x020036E2 RID: 14050
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node17 : Condition
	{
		// Token: 0x060155DA RID: 87514 RVA: 0x0067215F File Offset: 0x0067055F
		public Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node17()
		{
			this.opl_p0 = 20389;
		}

		// Token: 0x060155DB RID: 87515 RVA: 0x00672174 File Offset: 0x00670574
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFAE RID: 61358
		private int opl_p0;
	}
}
