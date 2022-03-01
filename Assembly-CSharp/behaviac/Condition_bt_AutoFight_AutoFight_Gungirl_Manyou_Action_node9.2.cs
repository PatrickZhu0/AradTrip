using System;

namespace behaviac
{
	// Token: 0x020024CE RID: 9422
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node91 : Condition
	{
		// Token: 0x060132E6 RID: 78566 RVA: 0x005B218B File Offset: 0x005B058B
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node91()
		{
			this.opl_p0 = 2528;
		}

		// Token: 0x060132E7 RID: 78567 RVA: 0x005B21A0 File Offset: 0x005B05A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD04 RID: 52484
		private int opl_p0;
	}
}
