using System;

namespace behaviac
{
	// Token: 0x02003C2F RID: 15407
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node48 : Condition
	{
		// Token: 0x06016008 RID: 90120 RVA: 0x006A6507 File Offset: 0x006A4907
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node48()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x06016009 RID: 90121 RVA: 0x006A6528 File Offset: 0x006A4928
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F884 RID: 63620
		private BE_Target opl_p0;

		// Token: 0x0400F885 RID: 63621
		private BE_Equal opl_p1;

		// Token: 0x0400F886 RID: 63622
		private int opl_p2;
	}
}
