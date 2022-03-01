using System;

namespace behaviac
{
	// Token: 0x02002D05 RID: 11525
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node65 : Condition
	{
		// Token: 0x060142FA RID: 82682 RVA: 0x0060F83D File Offset: 0x0060DC3D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node65()
		{
			this.opl_p0 = 20748;
		}

		// Token: 0x060142FB RID: 82683 RVA: 0x0060F850 File Offset: 0x0060DC50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCA1 RID: 56481
		private int opl_p0;
	}
}
