using System;

namespace behaviac
{
	// Token: 0x020022A3 RID: 8867
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node20 : Condition
	{
		// Token: 0x06012EC2 RID: 77506 RVA: 0x005952A4 File Offset: 0x005936A4
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node20()
		{
			this.opl_p0 = 0.75f;
		}

		// Token: 0x06012EC3 RID: 77507 RVA: 0x005952B8 File Offset: 0x005936B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8CD RID: 51405
		private float opl_p0;
	}
}
