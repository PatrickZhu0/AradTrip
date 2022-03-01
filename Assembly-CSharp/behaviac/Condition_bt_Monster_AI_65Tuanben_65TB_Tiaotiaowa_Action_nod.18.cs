using System;

namespace behaviac
{
	// Token: 0x02002CF5 RID: 11509
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node45 : Condition
	{
		// Token: 0x060142DA RID: 82650 RVA: 0x0060F23D File Offset: 0x0060D63D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node45()
		{
			this.opl_p0 = 20743;
		}

		// Token: 0x060142DB RID: 82651 RVA: 0x0060F250 File Offset: 0x0060D650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC85 RID: 56453
		private int opl_p0;
	}
}
