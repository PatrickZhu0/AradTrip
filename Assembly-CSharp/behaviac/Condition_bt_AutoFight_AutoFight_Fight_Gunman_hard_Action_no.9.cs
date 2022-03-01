using System;

namespace behaviac
{
	// Token: 0x020020FA RID: 8442
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node22 : Condition
	{
		// Token: 0x06012B88 RID: 76680 RVA: 0x0057FF02 File Offset: 0x0057E302
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node22()
		{
			this.opl_p0 = 0.65f;
		}

		// Token: 0x06012B89 RID: 76681 RVA: 0x0057FF18 File Offset: 0x0057E318
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C57B RID: 50555
		private float opl_p0;
	}
}
