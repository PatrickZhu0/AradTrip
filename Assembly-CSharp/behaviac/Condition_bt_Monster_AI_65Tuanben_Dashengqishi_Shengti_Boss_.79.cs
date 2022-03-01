using System;

namespace behaviac
{
	// Token: 0x02002E54 RID: 11860
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node177 : Condition
	{
		// Token: 0x06014585 RID: 83333 RVA: 0x0061B639 File Offset: 0x00619A39
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node177()
		{
			this.opl_p0 = 21624;
		}

		// Token: 0x06014586 RID: 83334 RVA: 0x0061B64C File Offset: 0x00619A4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF19 RID: 57113
		private int opl_p0;
	}
}
