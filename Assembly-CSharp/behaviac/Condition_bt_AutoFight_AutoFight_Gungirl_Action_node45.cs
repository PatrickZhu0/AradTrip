using System;

namespace behaviac
{
	// Token: 0x020024C0 RID: 9408
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node45 : Condition
	{
		// Token: 0x060132CB RID: 78539 RVA: 0x005B0EE6 File Offset: 0x005AF2E6
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node45()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060132CC RID: 78540 RVA: 0x005B0EFC File Offset: 0x005AF2FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCE6 RID: 52454
		private float opl_p0;
	}
}
