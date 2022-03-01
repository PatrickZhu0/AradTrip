using System;

namespace behaviac
{
	// Token: 0x02003902 RID: 14594
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node68 : Condition
	{
		// Token: 0x060159DF RID: 88543 RVA: 0x006871DF File Offset: 0x006855DF
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node68()
		{
			this.opl_p0 = 0.14f;
		}

		// Token: 0x060159E0 RID: 88544 RVA: 0x006871F4 File Offset: 0x006855F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F37F RID: 62335
		private float opl_p0;
	}
}
