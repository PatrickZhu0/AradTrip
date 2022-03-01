using System;

namespace behaviac
{
	// Token: 0x02002F4A RID: 12106
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node15 : Condition
	{
		// Token: 0x06014764 RID: 83812 RVA: 0x006280E1 File Offset: 0x006264E1
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node15()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014765 RID: 83813 RVA: 0x006280F4 File Offset: 0x006264F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0D5 RID: 57557
		private float opl_p0;
	}
}
