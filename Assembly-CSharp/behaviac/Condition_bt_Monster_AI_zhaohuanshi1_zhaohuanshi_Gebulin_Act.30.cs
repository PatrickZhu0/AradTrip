using System;

namespace behaviac
{
	// Token: 0x0200405C RID: 16476
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node52 : Condition
	{
		// Token: 0x06016817 RID: 92183 RVA: 0x006CF889 File Offset: 0x006CDC89
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node52()
		{
			this.opl_p0 = 5112;
		}

		// Token: 0x06016818 RID: 92184 RVA: 0x006CF89C File Offset: 0x006CDC9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010063 RID: 65635
		private int opl_p0;
	}
}
