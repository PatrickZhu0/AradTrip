using System;

namespace behaviac
{
	// Token: 0x020024D2 RID: 9426
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node96 : Condition
	{
		// Token: 0x060132EE RID: 78574 RVA: 0x005B2341 File Offset: 0x005B0741
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node96()
		{
			this.opl_p0 = 2534;
		}

		// Token: 0x060132EF RID: 78575 RVA: 0x005B2354 File Offset: 0x005B0754
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD0C RID: 52492
		private int opl_p0;
	}
}
