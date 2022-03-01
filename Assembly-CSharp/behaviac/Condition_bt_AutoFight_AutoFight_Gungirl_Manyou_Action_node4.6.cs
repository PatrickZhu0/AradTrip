using System;

namespace behaviac
{
	// Token: 0x02002506 RID: 9478
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node47 : Condition
	{
		// Token: 0x06013356 RID: 78678 RVA: 0x005B3D3F File Offset: 0x005B213F
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node47()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013357 RID: 78679 RVA: 0x005B3D74 File Offset: 0x005B2174
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD75 RID: 52597
		private int opl_p0;

		// Token: 0x0400CD76 RID: 52598
		private int opl_p1;

		// Token: 0x0400CD77 RID: 52599
		private int opl_p2;

		// Token: 0x0400CD78 RID: 52600
		private int opl_p3;
	}
}
