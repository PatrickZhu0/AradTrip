using System;

namespace behaviac
{
	// Token: 0x02002087 RID: 8327
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node48 : Condition
	{
		// Token: 0x06012AA7 RID: 76455 RVA: 0x00579E97 File Offset: 0x00578297
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node48()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012AA8 RID: 76456 RVA: 0x00579ECC File Offset: 0x005782CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C499 RID: 50329
		private int opl_p0;

		// Token: 0x0400C49A RID: 50330
		private int opl_p1;

		// Token: 0x0400C49B RID: 50331
		private int opl_p2;

		// Token: 0x0400C49C RID: 50332
		private int opl_p3;
	}
}
