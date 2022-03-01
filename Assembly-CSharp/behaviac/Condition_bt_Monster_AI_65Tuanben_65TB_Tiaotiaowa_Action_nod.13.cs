using System;

namespace behaviac
{
	// Token: 0x02002CEB RID: 11499
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node20 : Condition
	{
		// Token: 0x060142C6 RID: 82630 RVA: 0x0060EEBD File Offset: 0x0060D2BD
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node20()
		{
			this.opl_p0 = 20748;
		}

		// Token: 0x060142C7 RID: 82631 RVA: 0x0060EED0 File Offset: 0x0060D2D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC74 RID: 56436
		private int opl_p0;
	}
}
