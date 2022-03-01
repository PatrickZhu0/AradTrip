using System;

namespace behaviac
{
	// Token: 0x020020F6 RID: 8438
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node17 : Condition
	{
		// Token: 0x06012B80 RID: 76672 RVA: 0x0057FCB6 File Offset: 0x0057E0B6
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node17()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012B81 RID: 76673 RVA: 0x0057FCCC File Offset: 0x0057E0CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C573 RID: 50547
		private float opl_p0;
	}
}
