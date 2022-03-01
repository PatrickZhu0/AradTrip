using System;

namespace behaviac
{
	// Token: 0x020038CA RID: 14538
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node19 : Condition
	{
		// Token: 0x06015973 RID: 88435 RVA: 0x0068436B File Offset: 0x0068276B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node19()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521642;
		}

		// Token: 0x06015974 RID: 88436 RVA: 0x0068438C File Offset: 0x0068278C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F326 RID: 62246
		private BE_Target opl_p0;

		// Token: 0x0400F327 RID: 62247
		private BE_Equal opl_p1;

		// Token: 0x0400F328 RID: 62248
		private int opl_p2;
	}
}
