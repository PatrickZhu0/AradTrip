using System;

namespace behaviac
{
	// Token: 0x02003C14 RID: 15380
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node49 : Condition
	{
		// Token: 0x06015FD3 RID: 90067 RVA: 0x006A4E22 File Offset: 0x006A3222
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node49()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x06015FD4 RID: 90068 RVA: 0x006A4E44 File Offset: 0x006A3244
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F853 RID: 63571
		private BE_Target opl_p0;

		// Token: 0x0400F854 RID: 63572
		private BE_Equal opl_p1;

		// Token: 0x0400F855 RID: 63573
		private int opl_p2;
	}
}
