using System;

namespace behaviac
{
	// Token: 0x02002EB3 RID: 11955
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node8 : Condition
	{
		// Token: 0x06014640 RID: 83520 RVA: 0x00621F7F File Offset: 0x0062037F
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node8()
		{
			this.opl_p0 = 21589;
		}

		// Token: 0x06014641 RID: 83521 RVA: 0x00621F94 File Offset: 0x00620394
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFB6 RID: 57270
		private int opl_p0;
	}
}
