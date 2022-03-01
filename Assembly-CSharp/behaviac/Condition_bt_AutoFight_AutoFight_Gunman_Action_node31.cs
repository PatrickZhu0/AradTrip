using System;

namespace behaviac
{
	// Token: 0x0200257E RID: 9598
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node31 : Condition
	{
		// Token: 0x06013444 RID: 78916 RVA: 0x005BA3EA File Offset: 0x005B87EA
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node31()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013445 RID: 78917 RVA: 0x005BA400 File Offset: 0x005B8800
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE6D RID: 52845
		private float opl_p0;
	}
}
