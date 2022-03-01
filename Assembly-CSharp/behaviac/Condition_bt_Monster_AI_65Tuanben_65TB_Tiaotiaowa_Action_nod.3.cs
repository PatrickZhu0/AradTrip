using System;

namespace behaviac
{
	// Token: 0x02002CD7 RID: 11479
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node2 : Condition
	{
		// Token: 0x0601429E RID: 82590 RVA: 0x0060E73D File Offset: 0x0060CB3D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node2()
		{
			this.opl_p0 = 20742;
		}

		// Token: 0x0601429F RID: 82591 RVA: 0x0060E750 File Offset: 0x0060CB50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC51 RID: 56401
		private int opl_p0;
	}
}
