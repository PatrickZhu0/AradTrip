using System;

namespace behaviac
{
	// Token: 0x02003B65 RID: 15205
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node27 : Condition
	{
		// Token: 0x06015E7F RID: 89727 RVA: 0x0069DE63 File Offset: 0x0069C263
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node27()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06015E80 RID: 89728 RVA: 0x0069DE78 File Offset: 0x0069C278
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F746 RID: 63302
		private float opl_p0;
	}
}
