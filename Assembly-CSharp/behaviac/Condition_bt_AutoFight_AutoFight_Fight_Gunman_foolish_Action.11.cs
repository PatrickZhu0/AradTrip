using System;

namespace behaviac
{
	// Token: 0x020020E6 RID: 8422
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node27 : Condition
	{
		// Token: 0x06012B61 RID: 76641 RVA: 0x0057EDDE File Offset: 0x0057D1DE
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node27()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06012B62 RID: 76642 RVA: 0x0057EDF4 File Offset: 0x0057D1F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C554 RID: 50516
		private float opl_p0;
	}
}
