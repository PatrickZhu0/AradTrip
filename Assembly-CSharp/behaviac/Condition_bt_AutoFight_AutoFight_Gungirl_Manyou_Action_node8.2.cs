using System;

namespace behaviac
{
	// Token: 0x020024CA RID: 9418
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node86 : Condition
	{
		// Token: 0x060132DE RID: 78558 RVA: 0x005B1FEF File Offset: 0x005B03EF
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node86()
		{
			this.opl_p0 = 2524;
		}

		// Token: 0x060132DF RID: 78559 RVA: 0x005B2004 File Offset: 0x005B0404
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCFC RID: 52476
		private int opl_p0;
	}
}
