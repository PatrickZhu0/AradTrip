using System;

namespace behaviac
{
	// Token: 0x020021D6 RID: 8662
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node17 : Condition
	{
		// Token: 0x06012D3A RID: 77114 RVA: 0x0058A602 File Offset: 0x00588A02
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node17()
		{
			this.opl_p0 = 0.54f;
		}

		// Token: 0x06012D3B RID: 77115 RVA: 0x0058A618 File Offset: 0x00588A18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C72D RID: 50989
		private float opl_p0;
	}
}
