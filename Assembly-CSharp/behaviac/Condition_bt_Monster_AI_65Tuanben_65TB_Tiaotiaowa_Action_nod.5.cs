using System;

namespace behaviac
{
	// Token: 0x02002CDB RID: 11483
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node4 : Condition
	{
		// Token: 0x060142A6 RID: 82598 RVA: 0x0060E8BD File Offset: 0x0060CCBD
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node4()
		{
			this.opl_p0 = 20743;
		}

		// Token: 0x060142A7 RID: 82599 RVA: 0x0060E8D0 File Offset: 0x0060CCD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC58 RID: 56408
		private int opl_p0;
	}
}
