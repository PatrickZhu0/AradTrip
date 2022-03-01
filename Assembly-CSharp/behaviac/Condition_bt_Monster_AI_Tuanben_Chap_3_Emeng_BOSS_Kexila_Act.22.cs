using System;

namespace behaviac
{
	// Token: 0x02003858 RID: 14424
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node37 : Condition
	{
		// Token: 0x06015896 RID: 88214 RVA: 0x0067F946 File Offset: 0x0067DD46
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node37()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06015897 RID: 88215 RVA: 0x0067F95C File Offset: 0x0067DD5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F24B RID: 62027
		private float opl_p0;
	}
}
