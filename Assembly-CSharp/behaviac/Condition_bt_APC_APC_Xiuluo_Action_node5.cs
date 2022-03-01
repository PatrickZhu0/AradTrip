using System;

namespace behaviac
{
	// Token: 0x02001E38 RID: 7736
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Xiuluo_Action_node5 : Condition
	{
		// Token: 0x0601261E RID: 75294 RVA: 0x0055EFDF File Offset: 0x0055D3DF
		public Condition_bt_APC_APC_Xiuluo_Action_node5()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601261F RID: 75295 RVA: 0x0055EFFC File Offset: 0x0055D3FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C005 RID: 49157
		private BE_Target opl_p0;

		// Token: 0x0400C006 RID: 49158
		private BE_Equal opl_p1;

		// Token: 0x0400C007 RID: 49159
		private BE_State opl_p2;
	}
}
