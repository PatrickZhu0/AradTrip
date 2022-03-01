using System;

namespace behaviac
{
	// Token: 0x020024BD RID: 9405
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node41 : Condition
	{
		// Token: 0x060132C5 RID: 78533 RVA: 0x005B0D22 File Offset: 0x005AF122
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node41()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060132C6 RID: 78534 RVA: 0x005B0D38 File Offset: 0x005AF138
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCDF RID: 52447
		private float opl_p0;
	}
}
