using System;

namespace behaviac
{
	// Token: 0x02002277 RID: 8823
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node27 : Condition
	{
		// Token: 0x06012E72 RID: 77426 RVA: 0x00593072 File Offset: 0x00591472
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node27()
		{
			this.opl_p0 = 1510;
		}

		// Token: 0x06012E73 RID: 77427 RVA: 0x00593088 File Offset: 0x00591488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C87F RID: 51327
		private int opl_p0;
	}
}
