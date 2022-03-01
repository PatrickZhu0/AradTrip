using System;

namespace behaviac
{
	// Token: 0x02003F9F RID: 16287
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node27 : Condition
	{
		// Token: 0x060166A8 RID: 91816 RVA: 0x006C7E29 File Offset: 0x006C6229
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node27()
		{
			this.opl_p0 = 5112;
		}

		// Token: 0x060166A9 RID: 91817 RVA: 0x006C7E3C File Offset: 0x006C623C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEFC RID: 65276
		private int opl_p0;
	}
}
