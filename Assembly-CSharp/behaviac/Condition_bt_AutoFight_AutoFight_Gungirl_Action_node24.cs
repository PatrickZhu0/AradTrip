using System;

namespace behaviac
{
	// Token: 0x020024AD RID: 9389
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node24 : Condition
	{
		// Token: 0x060132A5 RID: 78501 RVA: 0x005B04F2 File Offset: 0x005AE8F2
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node24()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060132A6 RID: 78502 RVA: 0x005B0508 File Offset: 0x005AE908
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCBF RID: 52415
		private float opl_p0;
	}
}
