using System;

namespace behaviac
{
	// Token: 0x02003B9A RID: 15258
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node32 : Condition
	{
		// Token: 0x06015EE4 RID: 89828 RVA: 0x006A047B File Offset: 0x0069E87B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node32()
		{
			this.opl_p0 = 21176;
		}

		// Token: 0x06015EE5 RID: 89829 RVA: 0x006A0490 File Offset: 0x0069E890
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F793 RID: 63379
		private int opl_p0;
	}
}
