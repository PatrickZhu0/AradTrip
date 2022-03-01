using System;

namespace behaviac
{
	// Token: 0x020024FF RID: 9471
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node11 : Condition
	{
		// Token: 0x06013348 RID: 78664 RVA: 0x005B3945 File Offset: 0x005B1D45
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node11()
		{
			this.opl_p0 = 2519;
		}

		// Token: 0x06013349 RID: 78665 RVA: 0x005B3958 File Offset: 0x005B1D58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD69 RID: 52585
		private int opl_p0;
	}
}
