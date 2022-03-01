using System;

namespace behaviac
{
	// Token: 0x020024E6 RID: 9446
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node38 : Condition
	{
		// Token: 0x06013316 RID: 78614 RVA: 0x005B2BC9 File Offset: 0x005B0FC9
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node38()
		{
			this.opl_p0 = 2504;
		}

		// Token: 0x06013317 RID: 78615 RVA: 0x005B2BDC File Offset: 0x005B0FDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD34 RID: 52532
		private int opl_p0;
	}
}
