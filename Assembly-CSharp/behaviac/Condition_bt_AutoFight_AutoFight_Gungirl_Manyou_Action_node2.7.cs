using System;

namespace behaviac
{
	// Token: 0x020024DE RID: 9438
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node28 : Condition
	{
		// Token: 0x06013306 RID: 78598 RVA: 0x005B285D File Offset: 0x005B0C5D
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node28()
		{
			this.opl_p0 = 2522;
		}

		// Token: 0x06013307 RID: 78599 RVA: 0x005B2870 File Offset: 0x005B0C70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD24 RID: 52516
		private int opl_p0;
	}
}
