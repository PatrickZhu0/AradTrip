using System;

namespace behaviac
{
	// Token: 0x02002412 RID: 9234
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node12 : Condition
	{
		// Token: 0x06013180 RID: 78208 RVA: 0x005A99AB File Offset: 0x005A7DAB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013181 RID: 78209 RVA: 0x005A99C8 File Offset: 0x005A7DC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBAB RID: 52139
		private BE_Target opl_p0;

		// Token: 0x0400CBAC RID: 52140
		private BE_Equal opl_p1;

		// Token: 0x0400CBAD RID: 52141
		private BE_State opl_p2;
	}
}
