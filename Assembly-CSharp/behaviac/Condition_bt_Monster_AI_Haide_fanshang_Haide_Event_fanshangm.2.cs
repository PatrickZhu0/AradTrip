using System;

namespace behaviac
{
	// Token: 0x020033C4 RID: 13252
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node4 : Condition
	{
		// Token: 0x06014FDF RID: 85983 RVA: 0x00653437 File Offset: 0x00651837
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2502;
		}

		// Token: 0x06014FE0 RID: 85984 RVA: 0x00653458 File Offset: 0x00651858
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8C8 RID: 59592
		private BE_Target opl_p0;

		// Token: 0x0400E8C9 RID: 59593
		private BE_Equal opl_p1;

		// Token: 0x0400E8CA RID: 59594
		private int opl_p2;
	}
}
