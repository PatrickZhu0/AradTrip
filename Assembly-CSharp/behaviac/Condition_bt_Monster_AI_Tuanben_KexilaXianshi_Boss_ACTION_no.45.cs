using System;

namespace behaviac
{
	// Token: 0x02003A71 RID: 14961
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node89 : Condition
	{
		// Token: 0x06015CAB RID: 89259 RVA: 0x0069499B File Offset: 0x00692D9B
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node89()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570036;
		}

		// Token: 0x06015CAC RID: 89260 RVA: 0x006949BC File Offset: 0x00692DBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5E2 RID: 62946
		private BE_Target opl_p0;

		// Token: 0x0400F5E3 RID: 62947
		private BE_Equal opl_p1;

		// Token: 0x0400F5E4 RID: 62948
		private int opl_p2;
	}
}
