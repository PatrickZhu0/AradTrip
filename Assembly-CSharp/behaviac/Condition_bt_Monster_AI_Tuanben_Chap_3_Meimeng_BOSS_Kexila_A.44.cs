using System;

namespace behaviac
{
	// Token: 0x02003914 RID: 14612
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node92 : Condition
	{
		// Token: 0x06015A03 RID: 88579 RVA: 0x00687946 File Offset: 0x00685D46
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node92()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015A04 RID: 88580 RVA: 0x0068795C File Offset: 0x00685D5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F397 RID: 62359
		private float opl_p0;
	}
}
