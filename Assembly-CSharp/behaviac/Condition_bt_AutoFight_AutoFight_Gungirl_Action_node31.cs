using System;

namespace behaviac
{
	// Token: 0x020024B5 RID: 9397
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node31 : Condition
	{
		// Token: 0x060132B5 RID: 78517 RVA: 0x005B09BA File Offset: 0x005AEDBA
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node31()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060132B6 RID: 78518 RVA: 0x005B09D0 File Offset: 0x005AEDD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCCF RID: 52431
		private float opl_p0;
	}
}
