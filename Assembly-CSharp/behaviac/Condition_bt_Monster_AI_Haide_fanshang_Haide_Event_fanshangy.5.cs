using System;

namespace behaviac
{
	// Token: 0x020033EA RID: 13290
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node8 : Condition
	{
		// Token: 0x06015028 RID: 86056 RVA: 0x006547D3 File Offset: 0x00652BD3
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2403;
		}

		// Token: 0x06015029 RID: 86057 RVA: 0x006547F4 File Offset: 0x00652BF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E915 RID: 59669
		private BE_Target opl_p0;

		// Token: 0x0400E916 RID: 59670
		private BE_Equal opl_p1;

		// Token: 0x0400E917 RID: 59671
		private int opl_p2;
	}
}
