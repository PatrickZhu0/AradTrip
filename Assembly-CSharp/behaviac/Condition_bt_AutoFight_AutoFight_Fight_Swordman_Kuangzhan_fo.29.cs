using System;

namespace behaviac
{
	// Token: 0x0200235C RID: 9052
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node56 : Condition
	{
		// Token: 0x06013025 RID: 77861 RVA: 0x0059F01D File Offset: 0x0059D41D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node56()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013026 RID: 77862 RVA: 0x0059F03C File Offset: 0x0059D43C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA3D RID: 51773
		private BE_Target opl_p0;

		// Token: 0x0400CA3E RID: 51774
		private BE_Equal opl_p1;

		// Token: 0x0400CA3F RID: 51775
		private BE_State opl_p2;
	}
}
