using System;

namespace behaviac
{
	// Token: 0x020038C9 RID: 14537
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node18 : Condition
	{
		// Token: 0x06015971 RID: 88433 RVA: 0x00684309 File Offset: 0x00682709
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node18()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521636;
		}

		// Token: 0x06015972 RID: 88434 RVA: 0x0068432C File Offset: 0x0068272C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F323 RID: 62243
		private BE_Target opl_p0;

		// Token: 0x0400F324 RID: 62244
		private BE_Equal opl_p1;

		// Token: 0x0400F325 RID: 62245
		private int opl_p2;
	}
}
