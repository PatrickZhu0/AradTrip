using System;

namespace behaviac
{
	// Token: 0x020021FA RID: 8698
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_hard_Move_node2 : Condition
	{
		// Token: 0x06012D80 RID: 77184 RVA: 0x0058C5A6 File Offset: 0x0058A9A6
		public Condition_bt_AutoFight_AutoFight_Fight_hard_Move_node2()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06012D81 RID: 77185 RVA: 0x0058C5BC File Offset: 0x0058A9BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C773 RID: 51059
		private float opl_p0;
	}
}
