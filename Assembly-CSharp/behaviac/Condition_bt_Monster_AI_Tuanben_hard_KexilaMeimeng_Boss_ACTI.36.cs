using System;

namespace behaviac
{
	// Token: 0x02003C3E RID: 15422
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node7 : Condition
	{
		// Token: 0x06016026 RID: 90150 RVA: 0x006A6A8E File Offset: 0x006A4E8E
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x06016027 RID: 90151 RVA: 0x006A6AB0 File Offset: 0x006A4EB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F89C RID: 63644
		private BE_Target opl_p0;

		// Token: 0x0400F89D RID: 63645
		private BE_Equal opl_p1;

		// Token: 0x0400F89E RID: 63646
		private int opl_p2;
	}
}
