using System;

namespace behaviac
{
	// Token: 0x02003868 RID: 14440
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node3 : Condition
	{
		// Token: 0x060158B4 RID: 88244 RVA: 0x00680D74 File Offset: 0x0067F174
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.55f;
		}

		// Token: 0x060158B5 RID: 88245 RVA: 0x00680D98 File Offset: 0x0067F198
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F25E RID: 62046
		private HMType opl_p0;

		// Token: 0x0400F25F RID: 62047
		private BE_Operation opl_p1;

		// Token: 0x0400F260 RID: 62048
		private float opl_p2;
	}
}
