using System;

namespace behaviac
{
	// Token: 0x02002631 RID: 9777
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node37 : Condition
	{
		// Token: 0x060135A8 RID: 79272 RVA: 0x005C1ADA File Offset: 0x005BFEDA
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node37()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x060135A9 RID: 79273 RVA: 0x005C1AF0 File Offset: 0x005BFEF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFF6 RID: 53238
		private float opl_p0;
	}
}
