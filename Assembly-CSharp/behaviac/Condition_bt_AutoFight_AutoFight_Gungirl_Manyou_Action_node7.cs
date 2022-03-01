using System;

namespace behaviac
{
	// Token: 0x020024D6 RID: 9430
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node7 : Condition
	{
		// Token: 0x060132F6 RID: 78582 RVA: 0x005B24F5 File Offset: 0x005B08F5
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node7()
		{
			this.opl_p0 = 2518;
		}

		// Token: 0x060132F7 RID: 78583 RVA: 0x005B2508 File Offset: 0x005B0908
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD14 RID: 52500
		private int opl_p0;
	}
}
