using System;

namespace behaviac
{
	// Token: 0x02002ED7 RID: 11991
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node14 : Condition
	{
		// Token: 0x06014688 RID: 83592 RVA: 0x00622C0D File Offset: 0x0062100D
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node14()
		{
			this.opl_p0 = 21600;
		}

		// Token: 0x06014689 RID: 83593 RVA: 0x00622C20 File Offset: 0x00621020
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFFA RID: 57338
		private int opl_p0;
	}
}
