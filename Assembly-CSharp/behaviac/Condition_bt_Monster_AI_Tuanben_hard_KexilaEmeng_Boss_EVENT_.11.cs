using System;

namespace behaviac
{
	// Token: 0x02003BDD RID: 15325
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node62 : Condition
	{
		// Token: 0x06015F67 RID: 89959 RVA: 0x006A2D43 File Offset: 0x006A1143
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node62()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.05f;
		}

		// Token: 0x06015F68 RID: 89960 RVA: 0x006A2D64 File Offset: 0x006A1164
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F802 RID: 63490
		private HMType opl_p0;

		// Token: 0x0400F803 RID: 63491
		private BE_Operation opl_p1;

		// Token: 0x0400F804 RID: 63492
		private float opl_p2;
	}
}
