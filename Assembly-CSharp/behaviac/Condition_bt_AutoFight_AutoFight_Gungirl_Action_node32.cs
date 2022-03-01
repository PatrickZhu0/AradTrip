using System;

namespace behaviac
{
	// Token: 0x020024B6 RID: 9398
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node32 : Condition
	{
		// Token: 0x060132B7 RID: 78519 RVA: 0x005B0A03 File Offset: 0x005AEE03
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node32()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060132B8 RID: 78520 RVA: 0x005B0A38 File Offset: 0x005AEE38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCD0 RID: 52432
		private int opl_p0;

		// Token: 0x0400CCD1 RID: 52433
		private int opl_p1;

		// Token: 0x0400CCD2 RID: 52434
		private int opl_p2;

		// Token: 0x0400CCD3 RID: 52435
		private int opl_p3;
	}
}
