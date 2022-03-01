using System;

namespace behaviac
{
	// Token: 0x02001E16 RID: 7702
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node5 : Condition
	{
		// Token: 0x060125DD RID: 75229 RVA: 0x0055D8CB File Offset: 0x0055BCCB
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node5()
		{
			this.opl_p0 = 8012;
		}

		// Token: 0x060125DE RID: 75230 RVA: 0x0055D8E0 File Offset: 0x0055BCE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFC7 RID: 49095
		private int opl_p0;
	}
}
