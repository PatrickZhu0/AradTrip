using System;

namespace behaviac
{
	// Token: 0x02002390 RID: 9104
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node61 : Condition
	{
		// Token: 0x06013087 RID: 77959 RVA: 0x005A1483 File Offset: 0x0059F883
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node61()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013088 RID: 77960 RVA: 0x005A14B8 File Offset: 0x0059F8B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA9D RID: 51869
		private int opl_p0;

		// Token: 0x0400CA9E RID: 51870
		private int opl_p1;

		// Token: 0x0400CA9F RID: 51871
		private int opl_p2;

		// Token: 0x0400CAA0 RID: 51872
		private int opl_p3;
	}
}
