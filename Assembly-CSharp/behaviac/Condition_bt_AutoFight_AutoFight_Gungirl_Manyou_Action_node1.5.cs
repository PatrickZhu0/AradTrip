using System;

namespace behaviac
{
	// Token: 0x02002503 RID: 9475
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node17 : Condition
	{
		// Token: 0x06013350 RID: 78672 RVA: 0x005B3C05 File Offset: 0x005B2005
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node17()
		{
			this.opl_p0 = 2507;
		}

		// Token: 0x06013351 RID: 78673 RVA: 0x005B3C18 File Offset: 0x005B2018
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD71 RID: 52593
		private int opl_p0;
	}
}
