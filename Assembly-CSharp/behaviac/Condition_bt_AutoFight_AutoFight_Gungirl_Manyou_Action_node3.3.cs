using System;

namespace behaviac
{
	// Token: 0x020024E2 RID: 9442
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node33 : Condition
	{
		// Token: 0x0601330E RID: 78606 RVA: 0x005B2A15 File Offset: 0x005B0E15
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node33()
		{
			this.opl_p0 = 2516;
		}

		// Token: 0x0601330F RID: 78607 RVA: 0x005B2A28 File Offset: 0x005B0E28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD2C RID: 52524
		private int opl_p0;
	}
}
