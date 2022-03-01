using System;

namespace behaviac
{
	// Token: 0x02001F85 RID: 8069
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node14 : Condition
	{
		// Token: 0x060128AA RID: 75946 RVA: 0x0056E071 File Offset: 0x0056C471
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node14()
		{
			this.opl_p0 = 2509;
		}

		// Token: 0x060128AB RID: 75947 RVA: 0x0056E084 File Offset: 0x0056C484
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C29D RID: 49821
		private int opl_p0;
	}
}
