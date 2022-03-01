using System;

namespace behaviac
{
	// Token: 0x020021CA RID: 8650
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node2 : Condition
	{
		// Token: 0x06012D22 RID: 77090 RVA: 0x00589FCE File Offset: 0x005883CE
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node2()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06012D23 RID: 77091 RVA: 0x00589FE4 File Offset: 0x005883E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C715 RID: 50965
		private float opl_p0;
	}
}
