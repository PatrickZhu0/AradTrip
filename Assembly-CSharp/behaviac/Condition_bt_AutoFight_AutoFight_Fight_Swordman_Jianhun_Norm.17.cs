using System;

namespace behaviac
{
	// Token: 0x020022FF RID: 8959
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node13 : Condition
	{
		// Token: 0x06012F77 RID: 77687 RVA: 0x0059AFE1 File Offset: 0x005993E1
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node13()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06012F78 RID: 77688 RVA: 0x0059AFF4 File Offset: 0x005993F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C994 RID: 51604
		private float opl_p0;
	}
}
