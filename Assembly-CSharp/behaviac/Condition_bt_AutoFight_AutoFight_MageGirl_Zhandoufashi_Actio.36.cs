using System;

namespace behaviac
{
	// Token: 0x02002730 RID: 10032
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node38 : Condition
	{
		// Token: 0x060137A2 RID: 79778 RVA: 0x005CD3D6 File Offset: 0x005CB7D6
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node38()
		{
			this.opl_p0 = 2200;
			this.opl_p1 = 800;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060137A3 RID: 79779 RVA: 0x005CD40C File Offset: 0x005CB80C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1FB RID: 53755
		private int opl_p0;

		// Token: 0x0400D1FC RID: 53756
		private int opl_p1;

		// Token: 0x0400D1FD RID: 53757
		private int opl_p2;

		// Token: 0x0400D1FE RID: 53758
		private int opl_p3;
	}
}
