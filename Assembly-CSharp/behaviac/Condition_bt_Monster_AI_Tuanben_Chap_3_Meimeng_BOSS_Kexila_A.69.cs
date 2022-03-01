using System;

namespace behaviac
{
	// Token: 0x02003938 RID: 14648
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node44 : Condition
	{
		// Token: 0x06015A4B RID: 88651 RVA: 0x006888B6 File Offset: 0x00686CB6
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node44()
		{
			this.opl_p0 = 0.19f;
		}

		// Token: 0x06015A4C RID: 88652 RVA: 0x006888CC File Offset: 0x00686CCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3DD RID: 62429
		private float opl_p0;
	}
}
