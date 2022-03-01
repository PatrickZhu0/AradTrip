using System;

namespace behaviac
{
	// Token: 0x0200394A RID: 14666
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3 : Condition
	{
		// Token: 0x06015A6E RID: 88686 RVA: 0x0068A6CB File Offset: 0x00688ACB
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06015A6F RID: 88687 RVA: 0x0068A6EC File Offset: 0x00688AEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3FC RID: 62460
		private HMType opl_p0;

		// Token: 0x0400F3FD RID: 62461
		private BE_Operation opl_p1;

		// Token: 0x0400F3FE RID: 62462
		private float opl_p2;
	}
}
