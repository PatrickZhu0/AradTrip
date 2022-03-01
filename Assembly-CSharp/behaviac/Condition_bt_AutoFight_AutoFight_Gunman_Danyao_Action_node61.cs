using System;

namespace behaviac
{
	// Token: 0x020025DE RID: 9694
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node61 : Condition
	{
		// Token: 0x06013503 RID: 79107 RVA: 0x005BDA81 File Offset: 0x005BBE81
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node61()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x06013504 RID: 79108 RVA: 0x005BDA94 File Offset: 0x005BBE94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF49 RID: 53065
		private float opl_p0;
	}
}
