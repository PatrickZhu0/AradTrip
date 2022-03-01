using System;

namespace behaviac
{
	// Token: 0x020033E4 RID: 13284
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node3 : Condition
	{
		// Token: 0x0601501C RID: 86044 RVA: 0x006545EC File Offset: 0x006529EC
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2403;
		}

		// Token: 0x0601501D RID: 86045 RVA: 0x00654610 File Offset: 0x00652A10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E907 RID: 59655
		private BE_Target opl_p0;

		// Token: 0x0400E908 RID: 59656
		private BE_Equal opl_p1;

		// Token: 0x0400E909 RID: 59657
		private int opl_p2;
	}
}
