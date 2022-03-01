using System;

namespace behaviac
{
	// Token: 0x020021DA RID: 8666
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node22 : Condition
	{
		// Token: 0x06012D42 RID: 77122 RVA: 0x0058A84E File Offset: 0x00588C4E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node22()
		{
			this.opl_p0 = 0.57f;
		}

		// Token: 0x06012D43 RID: 77123 RVA: 0x0058A864 File Offset: 0x00588C64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C735 RID: 50997
		private float opl_p0;
	}
}
