using System;

namespace behaviac
{
	// Token: 0x02003A0A RID: 14858
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node20 : Condition
	{
		// Token: 0x06015BE1 RID: 89057 RVA: 0x00690F08 File Offset: 0x0068F308
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node20()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570151;
		}

		// Token: 0x06015BE2 RID: 89058 RVA: 0x00690F2C File Offset: 0x0068F32C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F501 RID: 62721
		private BE_Target opl_p0;

		// Token: 0x0400F502 RID: 62722
		private BE_Equal opl_p1;

		// Token: 0x0400F503 RID: 62723
		private int opl_p2;
	}
}
