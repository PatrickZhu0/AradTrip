using System;

namespace behaviac
{
	// Token: 0x020024AF RID: 9391
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node22 : Condition
	{
		// Token: 0x060132A9 RID: 78505 RVA: 0x005B05B5 File Offset: 0x005AE9B5
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node22()
		{
			this.opl_p0 = 2513;
		}

		// Token: 0x060132AA RID: 78506 RVA: 0x005B05C8 File Offset: 0x005AE9C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCC4 RID: 52420
		private int opl_p0;
	}
}
