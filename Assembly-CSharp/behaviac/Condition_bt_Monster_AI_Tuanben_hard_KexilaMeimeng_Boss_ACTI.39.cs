using System;

namespace behaviac
{
	// Token: 0x02003C42 RID: 15426
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node26 : Condition
	{
		// Token: 0x0601602E RID: 90158 RVA: 0x006A6C5E File Offset: 0x006A505E
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node26()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x0601602F RID: 90159 RVA: 0x006A6C80 File Offset: 0x006A5080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8A6 RID: 63654
		private BE_Target opl_p0;

		// Token: 0x0400F8A7 RID: 63655
		private BE_Equal opl_p1;

		// Token: 0x0400F8A8 RID: 63656
		private int opl_p2;
	}
}
