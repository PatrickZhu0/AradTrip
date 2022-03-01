using System;

namespace behaviac
{
	// Token: 0x020024B1 RID: 9393
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node26 : Condition
	{
		// Token: 0x060132AD RID: 78509 RVA: 0x005B0756 File Offset: 0x005AEB56
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node26()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060132AE RID: 78510 RVA: 0x005B076C File Offset: 0x005AEB6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCC7 RID: 52423
		private float opl_p0;
	}
}
