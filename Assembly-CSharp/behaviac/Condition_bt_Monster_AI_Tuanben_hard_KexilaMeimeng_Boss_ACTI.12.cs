using System;

namespace behaviac
{
	// Token: 0x02003C16 RID: 15382
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node29 : Condition
	{
		// Token: 0x06015FD7 RID: 90071 RVA: 0x006A4EBD File Offset: 0x006A32BD
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node29()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06015FD8 RID: 90072 RVA: 0x006A4EE0 File Offset: 0x006A32E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F856 RID: 63574
		private HMType opl_p0;

		// Token: 0x0400F857 RID: 63575
		private BE_Operation opl_p1;

		// Token: 0x0400F858 RID: 63576
		private float opl_p2;
	}
}
