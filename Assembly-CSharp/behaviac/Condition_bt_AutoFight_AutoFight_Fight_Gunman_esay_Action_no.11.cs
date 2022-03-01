using System;

namespace behaviac
{
	// Token: 0x020020CE RID: 8398
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node27 : Condition
	{
		// Token: 0x06012B32 RID: 76594 RVA: 0x0057DB1E File Offset: 0x0057BF1E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node27()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06012B33 RID: 76595 RVA: 0x0057DB34 File Offset: 0x0057BF34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C525 RID: 50469
		private float opl_p0;
	}
}
