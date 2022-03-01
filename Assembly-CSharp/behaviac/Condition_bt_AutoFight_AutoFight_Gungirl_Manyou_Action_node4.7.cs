using System;

namespace behaviac
{
	// Token: 0x02002507 RID: 9479
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node49 : Condition
	{
		// Token: 0x06013358 RID: 78680 RVA: 0x005B3DB9 File Offset: 0x005B21B9
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node49()
		{
			this.opl_p0 = 2509;
		}

		// Token: 0x06013359 RID: 78681 RVA: 0x005B3DCC File Offset: 0x005B21CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD79 RID: 52601
		private int opl_p0;
	}
}
