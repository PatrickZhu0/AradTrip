using System;

namespace behaviac
{
	// Token: 0x020026CE RID: 9934
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node84 : Condition
	{
		// Token: 0x060136DF RID: 79583 RVA: 0x005C931D File Offset: 0x005C771D
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node84()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060136E0 RID: 79584 RVA: 0x005C9330 File Offset: 0x005C7730
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D137 RID: 53559
		private float opl_p0;
	}
}
