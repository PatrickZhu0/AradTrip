using System;

namespace behaviac
{
	// Token: 0x02003958 RID: 14680
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node50 : Condition
	{
		// Token: 0x06015A87 RID: 88711 RVA: 0x0068ADF5 File Offset: 0x006891F5
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node50()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570211;
		}

		// Token: 0x06015A88 RID: 88712 RVA: 0x0068AE18 File Offset: 0x00689218
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F41E RID: 62494
		private BE_Target opl_p0;

		// Token: 0x0400F41F RID: 62495
		private BE_Equal opl_p1;

		// Token: 0x0400F420 RID: 62496
		private int opl_p2;
	}
}
