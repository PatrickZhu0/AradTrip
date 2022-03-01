using System;

namespace behaviac
{
	// Token: 0x020020D6 RID: 8406
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node7 : Condition
	{
		// Token: 0x06012B41 RID: 76609 RVA: 0x0057E60E File Offset: 0x0057CA0E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node7()
		{
			this.opl_p0 = 0.22f;
		}

		// Token: 0x06012B42 RID: 76610 RVA: 0x0057E624 File Offset: 0x0057CA24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C534 RID: 50484
		private float opl_p0;
	}
}
