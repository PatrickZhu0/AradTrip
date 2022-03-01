using System;

namespace behaviac
{
	// Token: 0x020033C3 RID: 13251
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node3 : Condition
	{
		// Token: 0x06014FDD RID: 85981 RVA: 0x006533D5 File Offset: 0x006517D5
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2402;
		}

		// Token: 0x06014FDE RID: 85982 RVA: 0x006533F8 File Offset: 0x006517F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8C5 RID: 59589
		private BE_Target opl_p0;

		// Token: 0x0400E8C6 RID: 59590
		private BE_Equal opl_p1;

		// Token: 0x0400E8C7 RID: 59591
		private int opl_p2;
	}
}
