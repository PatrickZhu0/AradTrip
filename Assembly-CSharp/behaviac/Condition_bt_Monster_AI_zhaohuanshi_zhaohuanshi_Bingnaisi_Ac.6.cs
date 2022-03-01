using System;

namespace behaviac
{
	// Token: 0x02003F7F RID: 16255
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node12 : Condition
	{
		// Token: 0x0601666A RID: 91754 RVA: 0x006C6BA9 File Offset: 0x006C4FA9
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node12()
		{
			this.opl_p0 = 5355;
		}

		// Token: 0x0601666B RID: 91755 RVA: 0x006C6BBC File Offset: 0x006C4FBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEC0 RID: 65216
		private int opl_p0;
	}
}
