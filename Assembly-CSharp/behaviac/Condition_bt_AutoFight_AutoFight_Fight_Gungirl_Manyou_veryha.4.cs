using System;

namespace behaviac
{
	// Token: 0x02002067 RID: 8295
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node8 : Condition
	{
		// Token: 0x06012A67 RID: 76391 RVA: 0x00578EEF File Offset: 0x005772EF
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node8()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012A68 RID: 76392 RVA: 0x00578F24 File Offset: 0x00577324
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C459 RID: 50265
		private int opl_p0;

		// Token: 0x0400C45A RID: 50266
		private int opl_p1;

		// Token: 0x0400C45B RID: 50267
		private int opl_p2;

		// Token: 0x0400C45C RID: 50268
		private int opl_p3;
	}
}
