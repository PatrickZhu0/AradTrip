using System;

namespace behaviac
{
	// Token: 0x0200256C RID: 9580
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node5 : Condition
	{
		// Token: 0x06013420 RID: 78880 RVA: 0x005B9A2A File Offset: 0x005B7E2A
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013421 RID: 78881 RVA: 0x005B9A40 File Offset: 0x005B7E40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE46 RID: 52806
		private float opl_p0;
	}
}
