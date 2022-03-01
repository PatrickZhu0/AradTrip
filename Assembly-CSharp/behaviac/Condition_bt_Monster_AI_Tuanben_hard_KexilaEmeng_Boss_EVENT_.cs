using System;

namespace behaviac
{
	// Token: 0x02003BC5 RID: 15301
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node50 : Condition
	{
		// Token: 0x06015F37 RID: 89911 RVA: 0x006A25D5 File Offset: 0x006A09D5
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node50()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570215;
		}

		// Token: 0x06015F38 RID: 89912 RVA: 0x006A25F8 File Offset: 0x006A09F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7C4 RID: 63428
		private BE_Target opl_p0;

		// Token: 0x0400F7C5 RID: 63429
		private BE_Equal opl_p1;

		// Token: 0x0400F7C6 RID: 63430
		private int opl_p2;
	}
}
