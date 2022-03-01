using System;

namespace behaviac
{
	// Token: 0x02001F97 RID: 8087
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node12 : Condition
	{
		// Token: 0x060128CD RID: 75981 RVA: 0x0056F052 File Offset: 0x0056D452
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node12()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060128CE RID: 75982 RVA: 0x0056F068 File Offset: 0x0056D468
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2BF RID: 49855
		private float opl_p0;
	}
}
