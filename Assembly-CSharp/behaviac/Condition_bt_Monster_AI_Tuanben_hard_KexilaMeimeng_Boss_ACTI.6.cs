using System;

namespace behaviac
{
	// Token: 0x02003C0E RID: 15374
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node48 : Condition
	{
		// Token: 0x06015FC7 RID: 90055 RVA: 0x006A4C08 File Offset: 0x006A3008
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node48()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x06015FC8 RID: 90056 RVA: 0x006A4C2C File Offset: 0x006A302C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F84A RID: 63562
		private BE_Target opl_p0;

		// Token: 0x0400F84B RID: 63563
		private BE_Equal opl_p1;

		// Token: 0x0400F84C RID: 63564
		private int opl_p2;
	}
}
