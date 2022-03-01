using System;

namespace behaviac
{
	// Token: 0x020021D2 RID: 8658
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node12 : Condition
	{
		// Token: 0x06012D32 RID: 77106 RVA: 0x0058A3B6 File Offset: 0x005887B6
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node12()
		{
			this.opl_p0 = 0.51f;
		}

		// Token: 0x06012D33 RID: 77107 RVA: 0x0058A3CC File Offset: 0x005887CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C725 RID: 50981
		private float opl_p0;
	}
}
