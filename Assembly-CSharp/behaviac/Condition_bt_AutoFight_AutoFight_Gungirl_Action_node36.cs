using System;

namespace behaviac
{
	// Token: 0x020024B9 RID: 9401
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node36 : Condition
	{
		// Token: 0x060132BD RID: 78525 RVA: 0x005B0B6E File Offset: 0x005AEF6E
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node36()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060132BE RID: 78526 RVA: 0x005B0B84 File Offset: 0x005AEF84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCD7 RID: 52439
		private float opl_p0;
	}
}
